using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using projeto_1.Data;

namespace projeto_1
{
    public partial class FrmNotificacoes : Form
    {
        // Instância estática para manter apenas uma janela aberta
        private static FrmNotificacoes instancia;

        public FrmNotificacoes()
        {
            InitializeComponent();
            this.Load += FrmNotificacoes_Load;

            // Tratar erros do DataGridView
            dgvNotificacoes.DataError += (s, e) => { e.ThrowException = false; };
        }

        // Método para obter a instância única
        public static FrmNotificacoes GetInstancia()
        {
            if (instancia == null || instancia.IsDisposed)
                instancia = new FrmNotificacoes();
            return instancia;
        }

        private void FrmNotificacoes_Load(object sender, EventArgs e)
        {
            CarregarNotificacoes();
        }

        private void CarregarNotificacoes()
        {
            try
            {
                using (var conn = Database.GetConnection())
                {
                    conn.Open();
                    string sql = @"
                        SELECT n.id, d.nome AS deposito, p.tipo_peca AS peca,
                               n.mensagem, n.criado_em, n.visto
                        FROM notificacoes n
                        INNER JOIN depositos d ON d.id = n.id_deposito
                        INNER JOIN pecas p ON p.id = n.id_peca
                        ORDER BY n.criado_em DESC";

                    MySqlCommand cmd = new MySqlCommand(sql, conn);
                    MySqlDataReader reader = cmd.ExecuteReader();

                    DataTable dt = new DataTable();
                    dt.Load(reader);
                    dgvNotificacoes.DataSource = dt;

                    // Ocultar colunas não usadas
                    if (dgvNotificacoes.Columns.Contains("id"))
                        dgvNotificacoes.Columns["id"].Visible = false;
                    if (dgvNotificacoes.Columns.Contains("visto"))
                        dgvNotificacoes.Columns["visto"].Visible = false;

                    // Criar coluna "Status" se não existir
                    if (!dgvNotificacoes.Columns.Contains("Status"))
                    {
                        DataGridViewTextBoxColumn statusCol = new DataGridViewTextBoxColumn();
                        statusCol.Name = "Status";
                        statusCol.HeaderText = "Status";
                        statusCol.ReadOnly = true;
                        dgvNotificacoes.Columns.Add(statusCol);
                    }

                    // Preencher coluna Status
                    foreach (DataGridViewRow row in dgvNotificacoes.Rows)
                    {
                        if (row.Cells["visto"].Value != null)
                        {
                            int visto = Convert.ToInt32(row.Cells["visto"].Value);
                            row.Cells["Status"].Value = (visto == 1) ? "Lida" : "Não lida";
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao carregar notificações: " + ex.Message);
            }
        }

        // Método para adicionar nova notificação
        public void AdicionarMensagem(string mensagem, int idDeposito, int idPeca)
        {
            try
            {
                using (var conn = Database.GetConnection())
                {
                    conn.Open();
                    string sql = @"INSERT INTO notificacoes (id_deposito, id_peca, mensagem, criado_em, visto)
                                   VALUES (@idDeposito, @idPeca, @mensagem, NOW(), 0)";
                    MySqlCommand cmd = new MySqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("@idDeposito", idDeposito);
                    cmd.Parameters.AddWithValue("@idPeca", idPeca);
                    cmd.Parameters.AddWithValue("@mensagem", mensagem);
                    cmd.ExecuteNonQuery();
                }

                // Atualiza DataGridView
                CarregarNotificacoes();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao adicionar notificação: " + ex.Message);
            }
        }

        private void btnAtualizar_Click(object sender, EventArgs e)
        {
            CarregarNotificacoes();
        }

        private void btnMarcarLida_Click(object sender, EventArgs e)
        {
            if (dgvNotificacoes.SelectedRows.Count == 0)
            {
                MessageBox.Show("Selecione ao menos uma notificação para marcar como lida!");
                return;
            }

            try
            {
                using (var conn = Database.GetConnection())
                {
                    conn.Open();

                    foreach (DataGridViewRow row in dgvNotificacoes.SelectedRows)
                    {
                        int idNotif = Convert.ToInt32(row.Cells["id"].Value);
                        string sql = "UPDATE notificacoes SET visto = 1 WHERE id = @id";
                        MySqlCommand cmd = new MySqlCommand(sql, conn);
                        cmd.Parameters.AddWithValue("@id", idNotif);
                        cmd.ExecuteNonQuery();

                        row.Cells["Status"].Value = "Lida";
                    }
                }

                MessageBox.Show("Notificação(ões) marcada(s) como lida(s)!");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao marcar notificação como lida: " + ex.Message);
            }
        }

        private void btnSair_Click(object sender, EventArgs e)
        {
            this.Hide(); // Mantém a instância ativa
        }
    }
}