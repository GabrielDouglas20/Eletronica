using MySql.Data.MySqlClient;
using projeto_1.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace projeto_1
{
    public partial class FrmMovimentacao : Form
    {
        Thread nt;
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

                    int estoqueAtual = 0;
                    int minEstoque = 0;

                    // 🔎 Pega estoque atual e mínimo
                    using (var cmdCheck = new MySqlCommand(
                        "SELECT quantidade, quantidade_min FROM pecas WHERE id = @idPeca", conn))
                    {
                        cmdCheck.Parameters.AddWithValue("@idPeca", pecaId);
                        using (var reader = cmdCheck.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                estoqueAtual = Convert.ToInt32(reader["quantidade"]);
                                minEstoque = Convert.ToInt32(reader["quantidade_min"]);
                            }
                        }
                    }

                    // 🔎 Verifica estoque se for SAÍDA
                    if (tipoMov == "SAIDA" && estoqueAtual < quantidade)
                    {
                        MessageBox.Show("⚠️ Estoque insuficiente para esta saída!",
                            "Aviso de Estoque", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    // ✅ Inserir movimentação
                    string sqlMov = @"INSERT INTO movimentacoes_pecas
                              (id_deposito, id_peca, tipo_movimentacao, quantidade, motivo, referencia)
                              VALUES (@idDep, @idPeca, @tipo, @qtd, @motivo, @ref)";
                    using (MySqlCommand cmd = new MySqlCommand(sqlMov, conn))
                    {
                        cmd.Parameters.AddWithValue("@idDep", depositoId);
                        cmd.Parameters.AddWithValue("@idPeca", pecaId);
                        cmd.Parameters.AddWithValue("@tipo", tipoMov);
                        cmd.Parameters.AddWithValue("@qtd", quantidade);
                        cmd.Parameters.AddWithValue("@motivo", motivo);
                        cmd.Parameters.AddWithValue("@ref", referencia);
                        cmd.ExecuteNonQuery();
                    }

                    // 🔔 Atualiza estoque na tabela pecas
                    if (tipoMov == "ENTRADA")
                        estoqueAtual += quantidade;
                    else
                        estoqueAtual -= quantidade;

                    using (var cmdUpdate = new MySqlCommand(
                        "UPDATE pecas SET quantidade = @qtd WHERE id = @idPeca", conn))
                    {
                        cmdUpdate.Parameters.AddWithValue("@qtd", estoqueAtual);
                        cmdUpdate.Parameters.AddWithValue("@idPeca", pecaId);
                        cmdUpdate.ExecuteNonQuery();
                    }

                    // 🔔 Criar notificação da movimentação
                    string msgMov = tipoMov == "ENTRADA"
                        ? $"Entrada de {quantidade} unidade(s) registrada."
                        : $"Saída de {quantidade} unidade(s) registrada.";

                    string sqlNotif = @"INSERT INTO notificacoes
                                (id_deposito, id_peca, mensagem, criado_em, visto)
                                VALUES (@idDep, @idPeca, @msg, NOW(), 0)";
                    using (MySqlCommand cmdNotif = new MySqlCommand(sqlNotif, conn))
                    {
                        cmdNotif.Parameters.AddWithValue("@idDep", depositoId);
                        cmdNotif.Parameters.AddWithValue("@idPeca", pecaId);
                        cmdNotif.Parameters.AddWithValue("@msg", msgMov);
                        cmdNotif.ExecuteNonQuery();
                    }

                    // 🔔 Criar notificação se estoque abaixo do mínimo
                    if (estoqueAtual <= minEstoque)
                    {
                        string msgMin = $"⚠️ Estoque da peça ID {pecaId} abaixo do mínimo ({minEstoque}).";
                        using (MySqlCommand cmdMin = new MySqlCommand(sqlNotif, conn))
                        {
                            cmdMin.Parameters.AddWithValue("@idDep", depositoId);
                            cmdMin.Parameters.AddWithValue("@idPeca", pecaId);
                            cmdMin.Parameters.AddWithValue("@msg", msgMin);
                            cmdMin.ExecuteNonQuery();
                        }
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
            Form menu = new Menu();
            Application.OpenForms.OfType<Menu>().FirstOrDefault();
            if (menu != null)
            {
                return;
            }
                ((Menu)menu).AtualizarBotaoNotificacoes();
        }

        private void btnNotificacao_Click(object sender, EventArgs e)
{
    if (cmbDeposito.SelectedValue == null || cmbPeca.SelectedValue == null ||
        string.IsNullOrWhiteSpace(txtQuantidade.Text) || cmbTipMov.SelectedItem == null)
    {
        MessageBox.Show("Preencha todos os campos obrigatórios antes de criar a notificação!");
        return;
    }

    int idDeposito = Convert.ToInt32(cmbDeposito.SelectedValue);
    int idPeca = Convert.ToInt32(cmbPeca.SelectedValue);
    string deposito = cmbDeposito.Text;
    string peca = cmbPeca.Text;
    string tipoMov = cmbTipMov.SelectedItem.ToString();
    string quantidade = txtQuantidade.Text;

    string mensagem = $"Movimentação registrada: Peça: {peca}, Depósito: {deposito}, Quantidade: {quantidade}, Tipo: {tipoMov}";

    // Mostrar alerta imediato
    MessageBox.Show(mensagem, "Notificação", MessageBoxButtons.OK, MessageBoxIcon.Information);

    // Abrir ou usar a instância existente do FrmNotificacoes
    FrmNotificacoes frmNotif = FrmNotificacoes.GetInstancia(); // se quiser versão avançada com janela única
    frmNotif.AdicionarMensagem(mensagem, idDeposito, idPeca);
    frmNotif.Show();
    frmNotif.BringToFront();
}

        private void btnSair_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnEntrar_Click(object sender, EventArgs e)
        {
            this.Close();
            nt = new Thread(novoFrmmenu);
            nt.SetApartmentState(ApartmentState.STA);
            nt.Start();
        }

        private void novoFrmmenu()
        {
            Application.Run(new Menu());
        }
    }
}