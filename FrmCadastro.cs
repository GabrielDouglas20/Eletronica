//PARTE DE GABRIEL
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;

namespace projeto_1
{
    public partial class FrmCadastro : Form
    {
        Thread nt, ntLogin;
        int id = 0;
        public FrmCadastro()
        {
            InitializeComponent();
        }
        private void FrmCadastro_Load(Object sender, EventArgs e)
        {
            AskCpf.Select();
            CarregarDadosGrid();
        }
        private void CarregarDadosGrid()
        {
            CadastroUsuarios db = new CadastroUsuarios();
            dataGridView1.DataSource = db.PesquisarUsuario();
            formatarGrid();
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

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void txttelefone_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {

        }

        private void btnCadastrar_Click(object sender, EventArgs e)
        {
            string cpf = txtcpf.Text;
            string nome = txtnome.Text;
            string email = txtemail.Text;
            string telefone = txttelefone.Text;
            string endereco = txtendereco.Text;
            string cargo = txtcargo.Text;
            string senha = txtsenha.Text;
            string data_nascimento = txtdatanasci.Text;
            string data_admissao = txtdatadeadmissao.Text;

            if (string.IsNullOrWhiteSpace(nome))
            {
                MessageBox.Show("O campo nome é obrigatorio", "atenção", MessageBoxButtons.OK,MessageBoxIcon.Warning);
                txtnome.Focus();
                return;
            }
            CadastroUsuarios db = new CadastroUsuarios();
            if (db.AdicionarUsuario(id, cpf, nome, email, telefone, endereco, cargo, senha, data_nascimento, data_admissao))
            {
                MessageBox.Show("Cliente cadastrado com sucesso!", "sucesso",
                 MessageBoxButtons.OK, MessageBoxIcon.Information);
                LimparCampos();
                
            }
        }

        private void btnPesquisar_Click(object sender, EventArgs e)
        {
            string Criterio = AskCpf.Text;
            CadastroUsuarios db = new CadastroUsuarios();
            dataGridView1.DataSource = db.PesquisarUsuario(Criterio);
            formatarGrid();
        }
        private void formatarGrid()
        {
            if (dataGridView1.ColumnCount > 0)
            {
                dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                dataGridView1.Columns["id"].HeaderText = "id";
                dataGridView1.Columns["cpf"].HeaderText = "cpf";
                dataGridView1.Columns["nome"].HeaderText = "Nome do Usuario";
                dataGridView1.Columns["email"].HeaderText = "email";
                dataGridView1.Columns["telefone"].HeaderText = "telefone";
                dataGridView1.Columns["endereco"].HeaderText = "endereço";
                dataGridView1.Columns["cargo"].HeaderText = "cargo";
                dataGridView1.Columns["senha"].HeaderText = "senha";
                dataGridView1.Columns["data_nascimento"].HeaderText = "data_nascimento";
                dataGridView1.Columns["data_admissao"].HeaderText = "data_admissao";
                dataGridView1.Columns["id"].Visible = false;
            }
        }
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0) // Garante que não seja o cabeçalho
            {
                DataGridViewRow row = dataGridView1.Rows[e.RowIndex];

                // Pega o valor do ID
                id = row.Cells["id"].Value is DBNull ? 0 : Convert.ToInt32(row.Cells["id"].Value);

                // Preenche os campos de texto com os valores da linha
                txtcpf.Text = row.Cells["cpf"].Value.ToString();
                txtnome.Text = row.Cells["nome"].Value.ToString();
                txtemail.Text = row.Cells["email"].Value.ToString();
                txttelefone.Text = row.Cells["telefone"].Value.ToString();
                txtendereco.Text = row.Cells["endereco"].Value.ToString();
                txtcargo.Text = row.Cells["cargo"].Value.ToString();
                txtsenha.Text = row.Cells["senha"].Value.ToString();
                txtdatanasci.Text = row.Cells["data_nascimento"].Value.ToString();
                txtdatadeadmissao.Text = row.Cells["data_admissao"].Value.ToString();
            }
        }
        private void AskCpf_TextChanged(object sender, EventArgs e)
        {
            string criterio = AskCpf.Text;
            if (string.IsNullOrEmpty(criterio))
            {
                CarregarDadosGrid();

            }
            else
            {
                CadastroUsuarios db = new CadastroUsuarios();
                dataGridView1.DataSource = db.PesquisarUsuario(criterio);
                formatarGrid();
            }
        }

        private void btnAtualizar_Click(object sender, EventArgs e)
        {
             if (id == 0)
            {
                MessageBox.Show("Por favor, selecione um cliente no grid antes de atualizar.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

           
            string cpf = txtcpf.Text;
            string nome = txtnome.Text;
            string email = txtemail.Text;
            string telefone = txttelefone.Text;
            string endereco = txtendereco.Text;
            string cargo = txtcargo.Text;
            string senha = txtsenha.Text;
            string data_nascimento = txtdatanasci.Text;
            string data_admissao = txtdatadeadmissao.Text;

            CadastroUsuarios db = new CadastroUsuarios();
            if (db.AdicionarUsuario(id, cpf, nome, email, telefone, endereco, cargo, senha, data_nascimento, data_admissao))
            {
                MessageBox.Show("Cliente atualizado com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LimparCampos();
                CarregarDadosGrid();
            }
        }
        private void LimparCampos()
        {
            txtcpf.Clear();
            txtnome.Clear();
            txtemail.Clear();
            txttelefone.Clear();
            txtendereco.Clear();
            txtcargo.Clear();
            txtsenha.Clear();
            txtdatanasci.Clear();
            txtdatadeadmissao.Clear();

           id = 0; 
         
        }

        private void btnDeletar_Click(object sender, EventArgs e)
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

                
                if (db.ExcluirUsuario(id))
                
                    {
                        MessageBox.Show("Cliente excluído com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        LimparCampos();       // Limpa os campos de texto
                        CarregarDadosGrid();  // Recarrega o grid para remover a linha do cliente excluído
                    }


            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void BtnSair_Click(object sender, EventArgs e)
        {
            this.Close();
            ntLogin = new Thread(FrmSair);
            ntLogin.SetApartmentState(ApartmentState.STA);
            ntLogin.Start();
        }

        private void Desligar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        

       

        private void FrmSair()
        {
            Application.Run(new FrmLogin());
        }
    }
}

    
