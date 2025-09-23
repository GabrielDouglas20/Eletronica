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
            this.Close();
        }

        private void Menu_Load(object sender, EventArgs e)
        {

        }


        private void btnNotificacoes_Click(object sender, EventArgs e)
        {
            try
            {
                using (var conn = Database.GetConnection())
                {
                    conn.Open();

                    string sql = @"
                SELECT p.id, p.tipo_peca, e.quantidade, p.quantidade_min
                FROM pecas p
                JOIN estoque e ON e.id_peca = p.id";

                    MySqlCommand cmd = new MySqlCommand(sql, conn);
                    MySqlDataReader reader = cmd.ExecuteReader();

                    rtbRelatorio.Clear();

                    // Cabeçalho
                    rtbRelatorio.AppendText(
                        string.Format("{0,-15} {1,-5} {2,-12} {3,-8} {4}\n",
                        "Peça", "ID", "Quantidade", "Mínimo", "Status")
                    );
                    rtbRelatorio.AppendText("---------------------------------------------------------------------------\n");

                    // Linhas
                    rtbRelatorio.AppendText(
                        string.Format("{0,15} {1,-20} {2,-30} {3,-20} {4}\n",
                        "", "", "", "", "")
                    );

                    bool temBaixa = false;

                    while (reader.Read())
                    {
                        string id = reader["id"].ToString();
                        string nomePeca = reader["tipo_peca"].ToString();
                        int quantidade = Convert.ToInt32(reader["quantidade"]);
                        int minimo = Convert.ToInt32(reader["quantidade_min"]);

                        string status = (quantidade < minimo) ? "⚠ Baixo" : "OK";

                        if (quantidade < minimo) temBaixa = true;

                        // Monta linha formatada (alinhamento de colunas)
                        rtbRelatorio.AppendText(
                            $"{nomePeca,-15} {id,-4} {quantidade,-12} {minimo,-8} {status}\n"
                        );
                    }

                    // Rodapé
                    rtbRelatorio.AppendText("\n");

                    if (!temBaixa)
                        rtbRelatorio.AppendText("Todas as peças estão com estoque suficiente.");
                    else
                        rtbRelatorio.AppendText("⚠ Existem peças abaixo do estoque mínimo!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao gerar relatório: " + ex.Message);
            }
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