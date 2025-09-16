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
            this.Close();
            ntcli = new Thread(novoFrmmenu);
            ntcli.SetApartmentState(ApartmentState.STA);
            ntcli.Start();
        }

        private void novoFrmmenu()
        {
            Application.Run(new Frmmenu());
        }
    }
}
