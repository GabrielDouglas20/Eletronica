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
using static projeto_1.CadastroUsuarios;

namespace projeto_1

{
    public partial class FrmPecas : Form
    {
        Thread nt;
        public FrmPecas()
        {
            InitializeComponent();
           
        }
        private void CarregarDadosGrid()
        {
            CadastroUsuarios db = new CadastroUsuarios();
            dataGridView1.DataSource = db.Atualizarpeca();
            formatarGrid();
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
            string tipo_peca = txtTipoPeca.Text;
            string modelo = txtModelo.Text;
            string marca = txtMarca.Text;
            string estado = cmbEstado.Text;
            string quantidade_min = numQuantidademin.Text;
            string quantidade = txtquantidade.Text;
            

            if (string.IsNullOrWhiteSpace(tipo_peca))
            {
                MessageBox.Show("O campo nome é obrigatorio", "atenção", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtTipoPeca.Focus();
                return;
            }
            Cadastropeca db = new Cadastropeca();
            if (db.Adicionarpeca( tipo_peca, modelo, marca, estado, quantidade_min, quantidade))
            {
                MessageBox.Show("peça cadastrado com sucesso!", "sucesso",
                 MessageBoxButtons.OK, MessageBoxIcon.Information);
                LimparCampos();

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
            if (dgvPecas.SelectedRows.Count == 0)
            {
                MessageBox.Show("Por favor, selecione um cliente no grid antes de atualizar.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }


            string tipo_peca = txtTipoPeca.Text;
            string modelo = txtModelo.Text;
            string marca = txtMarca.Text;
            string estado = cmbEstado.Text;
            string quantidade_min = numQuantidademin.Text;
            string quantidade = txtquantidade.Text;


            Cadastropeca db = new Cadastropeca();
            if (db.Adicionarpeca(tipo_peca, modelo, marca, estado, quantidade_min, quantidade))
            {
                MessageBox.Show("Cliente atualizado com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LimparCampos();
                
            }
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
            txtquantidade.Clear();
            cmbEstado.SelectedIndex = -1;
            numQuantidademin.Value = 0;
        }

        private void Desligar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void BtnVoltar_Click(object sender, EventArgs e)
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
