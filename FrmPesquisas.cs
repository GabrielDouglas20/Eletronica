
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
    public partial class FrmPesquisas : Form
    {
        public FrmPesquisas()
        {
            InitializeComponent();
        }

        private void FrmPesquisas_Load(object sender, EventArgs e)
        {
            MaskUsuarioP.Select();
            CarregarDadosdoGrid();
        }

        private void CarregarDadosdoGrid()
        {
            ClassPesquisas db = new ClassPesquisas();
            dataGridViewUsuP.DataSource = db.PesquisaUsu();
            formataroGrid();
        }

        private void formataroGrid()
        {
            if (dataGridViewUsuP.ColumnCount > 0)
            {
                dataGridViewUsuP.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                dataGridViewUsuP.Columns["id"].HeaderText = "id";
                dataGridViewUsuP.Columns["cpf"].HeaderText = "cpf";
                dataGridViewUsuP.Columns["nome"].HeaderText = "Nome do Usuario";
                dataGridViewUsuP.Columns["email"].HeaderText = "email";
                dataGridViewUsuP.Columns["telefone"].HeaderText = "telefone";
                dataGridViewUsuP.Columns["endereco"].HeaderText = "endereço";
                dataGridViewUsuP.Columns["cargo"].HeaderText = "cargo";
                dataGridViewUsuP.Columns["data_admissao"].HeaderText = "data_admissao";
                dataGridViewUsuP.Columns["data_nascimento"].HeaderText = "data_nascimento";
                dataGridViewUsuP.Columns["id"].Visible = false;

            }
        }

        private void dataGridViewUsuP_CellClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void BtnPesquisarUsuarioP_Click(object sender, EventArgs e)
        {

        }

        private void dataGridViewUsuP_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void MaskUsuarioP_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {

        }
    }
}
