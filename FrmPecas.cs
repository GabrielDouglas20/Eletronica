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
        int id = 0;
        public FrmPecas()
        {
            InitializeComponent();
           
        }
        private void FrmMovimentacao_Load(object sender, EventArgs e)
        {
            CadastroUsuarios db = new CadastroUsuarios();
            DataTable dt = db.Pesquisarpeca();
            dataGridView1.DataSource = dt;

            // preenche o combo direto por DataSource
            cmbEstado.DataSource = new string[] { "NOVO", "USADO", "DEFEITO" };

            CarregarDadosGrid();
        }
        private void CarregarDadosGrid()
        {
            CadastroUsuarios db = new CadastroUsuarios();
            dataGridView1.DataSource = db.Pesquisarpeca();
            formatarGrid();
        }

       

        private void formatarGrid()
        {
            if (dataGridView1.ColumnCount > 0)
            {
                dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                dataGridView1.Columns["id"].HeaderText = "id";
                dataGridView1.Columns["tipo_peca"].HeaderText = "tipo_peca";
                dataGridView1.Columns["modelo"].HeaderText = "modelo";
                dataGridView1.Columns["marca"].HeaderText = "marca";
                dataGridView1.Columns["estado"].HeaderText = "estado";
                dataGridView1.Columns["quantidade_min"].HeaderText = "quantidade_min";
                dataGridView1.Columns["quantidade"].HeaderText = "quantidade";
                dataGridView1.Columns["id"].Visible = false;

            }
        }
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0) // Garante que não seja o cabeçalho
            {
                DataGridViewRow row = dataGridView1.Rows[e.RowIndex];

                id = row.Cells["id"].Value is DBNull ? 0 : Convert.ToInt32(row.Cells["id"].Value);

                // Preenche os campos de texto com os valores da linha
                id = Convert.ToInt32(row.Cells["id"].Value); // pega o ID da linha
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
            if (db.Adicionarpeca(id, tipo_peca, modelo, marca, estado, quantidade_min, quantidade))
            {
                MessageBox.Show("peça cadastrado com sucesso!", "sucesso",
                 MessageBoxButtons.OK, MessageBoxIcon.Information);
                LimparCampos();

            }
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            if (id == 0)
            {
                MessageBox.Show("Por favor, selecione um usuario no grid para excluir.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            DialogResult confirmacao = MessageBox.Show(
               "Tem certeza que deseja excluir o cliente selecionado? Esta ação não pode ser desfeita.",
               "Confirmar Exclusão",
               MessageBoxButtons.YesNo,
               MessageBoxIcon.Warning
           );


            if (confirmacao == DialogResult.Yes)
            {
                // INSTANCIA DO BANCO
                CadastroUsuarios db = new CadastroUsuarios();


                if (db.Excluirpeca(id))

                {
                    MessageBox.Show("Cliente excluído com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    LimparCampos();       // Limpa os campos de texto
                    CarregarDadosGrid();  // Recarrega o grid para remover a linha do cliente excluído
                }


            }
        }

        private void btnAtualizar_Click(object sender, EventArgs e)
        {
            if (id == 0)

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
            if (db.Adicionarpeca(id, tipo_peca, modelo, marca, estado, quantidade_min, quantidade))
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

        private void btnpesquisar_Click(object sender, EventArgs e)
        {
            string Criterio = txtpesquisar.Text;
            CadastroUsuarios db = new CadastroUsuarios();
            dataGridView1.DataSource = db.Pesquisarpeca(Criterio);
            formatarGrid();
        }
    }
}
