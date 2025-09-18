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
    public partial class FrmLogin : Form
    {
        Thread ntcli;
        public FrmLogin()
        {
            InitializeComponent();
        }

        private void btnentrar_Click(object sender, EventArgs e)
        {
            string cpf = txtcpf.Text;
            string senha = txtsenha.Text;
            if (string.IsNullOrWhiteSpace(cpf)  || string.IsNullOrWhiteSpace(senha))

            {
                MessageBox.Show("Preencha os campos por favor.", "Campos vazios", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            CadastroUsuarios db = new CadastroUsuarios();

            if (db.loginUsuario(cpf, senha))
            {
                MessageBox.Show("Login realizado com sucesso", "Bem vindo!", MessageBoxButtons.OK, MessageBoxIcon.Information);

                Menu menu = new Menu();

                menu.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("cpf e senha incorretos. tente novamente!", " Falha no login", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void novoFrmmenu()
        {
            Application.Run(new Menu());
        }
    }
}
