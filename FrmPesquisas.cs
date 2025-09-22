
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
using MySql.Data.MySqlClient;


namespace projeto_1
{
    public partial class FrmPesquisas : Form
    {
        Thread nt;
        int id = 0;
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
                dataGridViewUsuP.Columns["data_admissao"].HeaderText = "data de admissao";
                dataGridViewUsuP.Columns["data_nascimento"].HeaderText = "data de nascimento";
                dataGridViewUsuP.Columns["id"].Visible = false;

            }
        }

        private void dataGridViewUsuP_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)// Garante que não seja o cabeçalho
            {

                DataGridViewRow row = dataGridViewUsuP.Rows[e.RowIndex];

                // Pega o valor do ID
                id = row.Cells["id"].Value is DBNull ? 0 : Convert.ToInt32(row.Cells["id"].Value);
            } 
        }

        private void MasKUsuarioP_TextChanged(object sender, EventArgs e)
        {
            string criterio = MaskUsuarioP.Text;
            if (string.IsNullOrEmpty(criterio))
            {
                CarregarDadosdoGrid();

            }
            else
            {
                ClassPesquisas db = new ClassPesquisas();
                dataGridViewUsuP.DataSource = db.PesquisarUsuarioo(criterio);
                formataroGrid();
            }
        }

        private void BtnPesquisarUsuarioP_Click(object sender, EventArgs e)
        {
            string Criterio = MaskUsuarioP.Text;
            ClassPesquisas db = new ClassPesquisas();
            dataGridViewUsuP.DataSource = db.PesquisarUsuarioo(Criterio);
            formataroGrid();
        }

        private void MaskUsuarioP_TextChanged(object sender, EventArgs e)
        {
            string criterio = MaskUsuarioP.Text;
            if (string.IsNullOrEmpty(criterio))
            {
                CarregarDadosdoGrid();

            }
            else
            {
                ClassPesquisas db = new ClassPesquisas();
                dataGridViewUsuP.DataSource = db.PesquisarUsuarioo(criterio);
                formataroGrid();
            }
        }

        private void dataGridViewUsuP_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

            if (e.RowIndex >= 0) // Garante que não seja o cabeçalho
            {
                DataGridViewRow row = dataGridViewUsuP.Rows[e.RowIndex];
                // Pega o valor do ID
                id = row.Cells["id"].Value is DBNull ? 0 : Convert.ToInt32(row.Cells["id"].Value);

                row.Cells["cpf"].Value.ToString();
                row.Cells["nome"].Value.ToString();
                row.Cells["email"].Value.ToString();
                row.Cells["telefone"].Value.ToString();
                row.Cells["endereco"].Value.ToString();
                row.Cells["cargo"].Value.ToString();
                row.Cells["data_admissao"].Value.ToString();
                row.Cells["data_nascimento"].Value.ToString();
                row.Cells["senha"].Value.ToString();
            } 

        }

        private void MaskUsuarioP_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {

        }

        private void dataGridViewPecasP_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void BtnPesquisarPecas_Click(object sender, EventArgs e)
        {
            string criterio = maskePecaP.Text;
            ClassPesquisas db = new ClassPesquisas();

            if (string.IsNullOrEmpty(criterio))
            {
                dataGridViewPecasP.DataSource = db.PesquisaPecas();
            }
            else
            {
                dataGridViewPecasP.DataSource = db.PesquisaPecass(criterio);
            }

            FormatarGridPecas();
        }

        private void maskePecaP_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {

        }



        private void CarregarPecasGrid()
        {
            ClassPesquisas db = new ClassPesquisas();
            dataGridViewPecasP.DataSource = db.PesquisaPecas();
            FormatarGridPecas();
        }

        private void FormatarGridPecas()
        {
            if (dataGridViewPecasP.ColumnCount > 0)
            {
                dataGridViewPecasP.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                dataGridViewPecasP.Columns["id"].Visible = false;
                dataGridViewPecasP.Columns["tipo_peca"].HeaderText = "Tipo da Peça";
                dataGridViewPecasP.Columns["marca"].HeaderText = "Marca";
                dataGridViewPecasP.Columns["estado"].HeaderText = "Estado";
                dataGridViewPecasP.Columns["quantidade_min"].HeaderText = "Quantidade Mínima";
                dataGridViewPecasP.Columns["modelo"].HeaderText = "Modelo";
            }





        }

        private void maskePecaP_TextChanged(object sender, EventArgs e)
        {
            string criterio = maskePecaP.Text;
            ClassPesquisas db = new ClassPesquisas();

            if (string.IsNullOrEmpty(criterio))
            {
                dataGridViewPecasP.DataSource = db.PesquisaPecas();
            }
            else
            {
                dataGridViewPecasP.DataSource = db.PesquisaPecass(criterio);
            }

            FormatarGridPecas();
        }


        




    }
}
