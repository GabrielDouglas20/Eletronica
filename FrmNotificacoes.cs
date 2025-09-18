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
    public FrmNotificacoes()
    {
        InitializeComponent();
        this.Load += FrmNotificacoes_Load;

        // Tratar erros de DataGridView para evitar popup padrão
        dgvNotificacoes.DataError += (s, e) =>
        {
            e.ThrowException = false;
        };
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

                // Ocultar coluna ID e coluna booleana original
                if (dgvNotificacoes.Columns.Contains("id"))
                    dgvNotificacoes.Columns["id"].Visible = false;

                if (dgvNotificacoes.Columns.Contains("visto"))
                    dgvNotificacoes.Columns["visto"].Visible = false;

                // Criar coluna "Status" apenas para exibição
                if (!dgvNotificacoes.Columns.Contains("Status"))
                {
                    DataGridViewTextBoxColumn statusCol = new DataGridViewTextBoxColumn();
                    statusCol.Name = "Status";
                    statusCol.HeaderText = "Status";
                    statusCol.ReadOnly = true;
                    dgvNotificacoes.Columns.Add(statusCol);
                }

                // Preencher coluna "Status" com base no valor booleano
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

                    // Atualizar a coluna Status localmente
                    if (dgvNotificacoes.Columns.Contains("Status"))
                    {
                        row.Cells["Status"].Value = "Lida";
                    }
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
        this.Close();
    }

  }
}
