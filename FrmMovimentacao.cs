using MySql.Data.MySqlClient;
using projeto_1.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace projeto_1
{
    public partial class FrmMovimentacao : Form
    {
        public FrmMovimentacao()
        {
            InitializeComponent();
            this.Load += FrmMovimentacao_Load;
        }

        private void FrmMovimentacao_Load(object sender, EventArgs e)
        {
            CarregarDepositos();
            CarregarPecas();

            // limpa antes de adicionar
            cmbTipMov.Items.Clear();
            cmbTipMov.Items.AddRange(new string[] { "ENTRADA", "SAIDA" });

            CarregarMovimentacoes();
        }
        private void CarregarDepositos()
        {
            try
            {
                using (var conn = Database.GetConnection())
                {
                    conn.Open();
                    MySqlCommand cmd = new MySqlCommand("SELECT id, nome FROM depositos WHERE ativo=1", conn);
                    MySqlDataReader reader = cmd.ExecuteReader();
                    DataTable dt = new DataTable();
                    dt.Load(reader);

                    cmbDeposito.DisplayMember = "nome";
                    cmbDeposito.ValueMember = "id";
                    cmbDeposito.DataSource = dt;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao carregar depósitos: " + ex.Message);
            }
        }

        private void CarregarPecas()
        {
            try
            {
                using (var conn = Database.GetConnection())
                {
                    conn.Open();
                    MySqlCommand cmd = new MySqlCommand("SELECT id, tipo_peca FROM pecas", conn);
                    MySqlDataReader reader = cmd.ExecuteReader();
                    DataTable dt = new DataTable();
                    dt.Load(reader);

                    cmbPeca.DisplayMember = "tipo_peca";
                    cmbPeca.ValueMember = "id";
                    cmbPeca.DataSource = dt;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao carregar peças: " + ex.Message);
            }
        }

        private void btnRegistrar_Click(object sender, EventArgs e)
        {
            if (cmbDeposito.SelectedValue == null || cmbPeca.SelectedValue == null ||
                string.IsNullOrWhiteSpace(txtQuantidade.Text) || cmbTipMov.SelectedItem == null)
            {
                MessageBox.Show("Preencha todos os campos obrigatórios!");
                return;
            }

            int depositoId = Convert.ToInt32(cmbDeposito.SelectedValue);
            int pecaId = Convert.ToInt32(cmbPeca.SelectedValue);
            int quantidade;
            if (!int.TryParse(txtQuantidade.Text, out quantidade))
            {
                MessageBox.Show("Quantidade inválida!");
                return;
            }
            string tipoMov = cmbTipMov.SelectedItem.ToString();
            string motivo = txtMotivo.Text;
            string referencia = txtReferencia.Text;

            try
            {
                using (var conn = Database.GetConnection())
                {
                    conn.Open();

                    // 1) Inserir movimentação normalmente
                    MySqlCommand cmd = new MySqlCommand(
                        "INSERT INTO movimentacoes_pecas (id_deposito, id_peca, tipo_movimentacao, quantidade, motivo, referencia) " +
                        "VALUES (@idDep, @idPeca, @tipo, @qtd, @motivo, @ref)", conn);
                    cmd.Parameters.AddWithValue("@idDep", depositoId);
                    cmd.Parameters.AddWithValue("@idPeca", pecaId);
                    cmd.Parameters.AddWithValue("@tipo", tipoMov);
                    cmd.Parameters.AddWithValue("@qtd", quantidade);
                    cmd.Parameters.AddWithValue("@motivo", motivo);
                    cmd.Parameters.AddWithValue("@ref", referencia);
                    cmd.ExecuteNonQuery();

                    // 2) Checar se houve notificação gerada pelo trigger
                    string sqlNotif = @"
                SELECT mensagem 
                FROM notificacoes 
                WHERE id_deposito = @idDep AND id_peca = @idPeca 
                ORDER BY criado_em DESC 
                LIMIT 1";

                    MySqlCommand cmdNotif = new MySqlCommand(sqlNotif, conn);
                    cmdNotif.Parameters.AddWithValue("@idDep", depositoId);
                    cmdNotif.Parameters.AddWithValue("@idPeca", pecaId);

                    object result = cmdNotif.ExecuteScalar();
                    if (result != null)
                    {
                        MessageBox.Show("⚠️ Notificação gerada: " + result.ToString(), "Aviso de Estoque", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }

                MessageBox.Show("Movimentação registrada com sucesso!");
                CarregarMovimentacoes();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao registrar movimentação: " + ex.Message);
            }
        }
        private void CarregarMovimentacoes()
        {
            try
            {
                using (var conn = Database.GetConnection())
                {
                    conn.Open();
                    MySqlDataAdapter da = new MySqlDataAdapter(
                        "SELECT m.id, d.nome AS deposito, p.tipo_peca AS peca, m.tipo_movimentacao, m.quantidade, m.motivo, m.referencia, m.criado_em " +
                        "FROM movimentacoes_pecas m " +
                        "INNER JOIN depositos d ON m.id_deposito = d.id " +
                        "INNER JOIN pecas p ON m.id_peca = p.id " +
                        "ORDER BY m.criado_em DESC LIMIT 20", conn);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    dgvMovimentacoes.DataSource = dt;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao carregar movimentações: " + ex.Message);
            }
        }

        private void btnSair_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}