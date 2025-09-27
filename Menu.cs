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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;


namespace projeto_1
{
    public partial class Menu : Form
    {
        Thread ntclick, ntMovi, ntPeca, ntCad, ntPesquisa, nt;
        public Menu()
        {
            InitializeComponent();

        }
        private void Menu_Load_1(object sender, EventArgs e)
        {
            AtualizarBotaoNotificacoes();
        }

        public void AtualizarBotaoNotificacoes()
        {
            try
            {
                using (var conn = Data.Database.GetConnection())
                {
                    conn.Open();
                    string sql = "SELECT COUNT(*) FROM notificacoes WHERE visto = 0";
                    using (MySqlCommand cmd = new MySqlCommand(sql, conn))
                    {
                        int qtd = Convert.ToInt32(cmd.ExecuteScalar());
                        btnNotificacoes.Text = (qtd > 0) ? $"Notificações ({qtd})" : "Notificações";
                        btnNotificacoes.BackColor = (qtd > 0) ? Color.Red : SystemColors.Control;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao atualizar notificações: " + ex.Message);
            }
        }


        private void login_Click(object sender, EventArgs e)
        {
            this.Close();
            ntclick = new Thread(novoFrLogin);
            ntclick.SetApartmentState(ApartmentState.STA);
            ntclick.Start();
        }

        private void novoFrLogin()
        {
            Application.Run(new FrmLogin());
        }

        private void Desligar_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Menu_Load(object sender, EventArgs e)
        {

        }


        private void btnNotificacoes_Click(object sender, EventArgs e)
        {
            RelatorioEstoque rel = new RelatorioEstoque();
            var lista = rel.Gerar();

            rtbRelatorio.Clear();
            rtbRelatorio.AppendText($"{"ID",-5} {"Peça",-20} {"Qtd",-12} {"Mínimo",-10} Status\n");
            rtbRelatorio.AppendText("---------------------------------------------------------------\n");

            bool temBaixa = false;

            foreach (var item in lista)
            {
                string status = (item.quantidade < item.minimo) ? "⚠ Baixo" : "OK";
                if (item.quantidade < item.minimo) temBaixa = true;

                rtbRelatorio.AppendText(
                    $"{item.id,-5} {item.tipo,-20} {item.quantidade,-12} {item.minimo,-10} {status}\n"
                );
            }

            rtbRelatorio.AppendText("\n");
            rtbRelatorio.AppendText(temBaixa
                ? "⚠ Existem peças abaixo do estoque mínimo!"
                : "✅ Todas as peças estão com estoque suficiente.");
        }

        private void BtnMovi_Click(object sender, EventArgs e)
        {
            this.Close();
            ntMovi = new Thread(novoFrMovi);
            ntMovi.SetApartmentState(ApartmentState.STA);
            ntMovi.Start();
        }

        private void BtnCadPeca_Click(object sender, EventArgs e)
        {
            this.Close();
            ntPeca = new Thread(novoFrMovi1);
            ntPeca.SetApartmentState(ApartmentState.STA);
            ntPeca.Start();
        }

        private void novoFrMovi1()
        {
            Application.Run(new FrmPecas());
        }

        private void BtnPesquisar_Click(object sender, EventArgs e)
        {
            this.Close();
            ntPesquisa = new Thread(novoFrMovi3);
            ntPesquisa.SetApartmentState(ApartmentState.STA);
            ntPesquisa.Start();
        }

        private void BtnSair_Click(object sender, EventArgs e)
        {
            this.Close();
            nt = new Thread(novoFrmmenu);
            nt.SetApartmentState(ApartmentState.STA);
            nt.Start();
        }

        private void novoFrmmenu()
        {
            Application.Run(new FrmLogin());
        }
        

        private void novoFrMovi3()
        {
            Application.Run(new FrmPesquisas());
        }

        private void BtnCadUsu_Click(object sender, EventArgs e)
        {
            this.Close();
            ntCad = new Thread(novoFrMovi2);
            ntCad.SetApartmentState(ApartmentState.STA);
            ntCad.Start();
        }

        private void novoFrMovi2()
        {
            Application.Run(new FrmCadastro());
        }

        private void novoFrMovi()
        {
            Application.Run(new FrmMovimentacao());
        }
    }
}