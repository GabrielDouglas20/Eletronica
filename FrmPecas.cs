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
    public partial class FrmPecas : Form
    {
        public FrmPecas()
        {
            InitializeComponent();
            this.Load += FrmPecas_Load;
        }

        private void FrmPecas_Load(object sender, EventArgs e)
        {
            // Estado
            cmbEstado.Items.Clear();
            cmbEstado.Items.AddRange(new string[] { "NOVO", "USADO", "DEFEITO" });

            // Propriedades DGV (caso não tenha setado no designer)
            dgvPecas.ReadOnly = true;
            dgvPecas.AllowUserToAddRows = false;
            dgvPecas.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvPecas.MultiSelect = false;
            dgvPecas.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            CarregarPecas();
        }

        private void CarregarPecas()
        {
            try
            {
                using (var conn = Database.GetConnection())
                {
                    conn.Open();
                    string sql = "SELECT id, tipo_peca, modelo, marca, estado, quantidade_min FROM pecas";
                    using (MySqlDataAdapter da = new MySqlDataAdapter(sql, conn))
                    {
                        DataTable dt = new DataTable();
                        da.Fill(dt);
                        dgvPecas.DataSource = dt;
                    }

                    if (dgvPecas.Columns.Contains("id"))
                        dgvPecas.Columns["id"].Visible = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao carregar peças: " + ex.Message);
            }
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtTipoPeca.Text) || cmbEstado.SelectedItem == null)
            {
                MessageBox.Show("Preencha ao menos Tipo de Peça e Estado!");
                return;
            }

            try
            {
                using (var conn = Database.GetConnection())
                {
                    conn.Open();
                    string sql = @"INSERT INTO pecas (tipo_peca, modelo, marca, estado, quantidade_min) 
                                   VALUES (@tipo, @modelo, @marca, @estado, @qtd)";
                    using (MySqlCommand cmd = new MySqlCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@tipo", txtTipoPeca.Text.Trim());
                        cmd.Parameters.AddWithValue("@modelo", txtModelo.Text.Trim());
                        cmd.Parameters.AddWithValue("@marca", txtMarca.Text.Trim());
                        cmd.Parameters.AddWithValue("@estado", cmbEstado.SelectedItem.ToString());
                        cmd.Parameters.AddWithValue("@qtd", (int)numQuantidademin.Value);
                        cmd.ExecuteNonQuery();
                    }
                }

                MessageBox.Show("Peça cadastrada com sucesso!");
                LimparCampos();
                CarregarPecas();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao salvar peça: " + ex.Message);
            }
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            if (dgvPecas.SelectedRows.Count == 0)
            {
                MessageBox.Show("Selecione uma peça para excluir.");
                return;
            }

            int idPeca = Convert.ToInt32(dgvPecas.SelectedRows[0].Cells["id"].Value);

            if (MessageBox.Show("Tem certeza que deseja excluir esta peça?", "Confirmação",
                                MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                try
                {
                    using (var conn = Database.GetConnection())
                    {
                        conn.Open();
                        string sql = "DELETE FROM pecas WHERE id = @id";
                        using (MySqlCommand cmd = new MySqlCommand(sql, conn))
                        {
                            cmd.Parameters.AddWithValue("@id", idPeca);
                            cmd.ExecuteNonQuery();
                        }
                    }

                    MessageBox.Show("Peça excluída com sucesso!");
                    CarregarPecas();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Erro ao excluir peça: " + ex.Message);
                }
            }
        }

        private void btnAtualizar_Click(object sender, EventArgs e)
        {
            CarregarPecas();
        }

        private void btnSair_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void LimparCampos()
        {
            txtTipoPeca.Clear();
            txtModelo.Clear();
            txtMarca.Clear();
            cmbEstado.SelectedIndex = -1;
            numQuantidademin.Value = 0;
        }
    }
}
