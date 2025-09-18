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


namespace projeto_1
{
    public partial class Menu : Form
    {
        Thread ntclick;
        public Menu()
        {
            InitializeComponent();
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
    }
}
