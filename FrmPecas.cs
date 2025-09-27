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

        private void formatarGrid()
        {
            if (dataGridView1.ColumnCount > 0)
            {
                dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                dataGridView1.Columns["tipo_peca"].HeaderText = "tipo_peca";
                dataGridView1.Columns["modelo"].HeaderText = "modelo";
                dataGridView1.Columns["marca"].HeaderText = "marca";
                dataGridView1.Columns["estado"].HeaderText = "estado";
                dataGridView1.Columns["quantidade_min"].HeaderText = "quantidade_min";
                dataGridView1.Columns["quantidade"].HeaderText = "quantidade";

            }
        }
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0) // Garante que não seja o cabeçalho
            {
                DataGridViewRow row = dataGridView1.Rows[e.RowIndex];

                // Preenche os campos de texto com os valores da linha
                txtTipoPeca.Text = row.Cells["tipo_peca"].Value.ToString();
                txtModelo.Text = row.Cells["modelo"].Value.ToString();
                txtMarca.Text = row.Cells["marca"].Value.ToString();
                cmbEstado.Text = row.Cells["estado"].Value.ToString();
                numQuantidademin.Text = row.Cells["quantidade_min"].Value.ToString();
                txtquantidade.Text = row.Cells["quantidade"].Value.ToString();
                
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
