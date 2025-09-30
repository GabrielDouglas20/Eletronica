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
             // Carrega grid de peças ao iniciar
        }

        // ------------------- USUÁRIOS -------------------
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
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dataGridViewUsuP.Rows[e.RowIndex];
                id = row.Cells["id"].Value is DBNull ? 0 : Convert.ToInt32(row.Cells["id"].Value);
            }
        }

        private void MasKUsuarioP_TextChanged(object sender, EventArgs e)
        {
            string criterio = MaskUsuarioP.Text;
            ClassPesquisas db = new ClassPesquisas();
            if (string.IsNullOrEmpty(criterio))
            {
                CarregarDadosdoGrid();
            }
            else
            {
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
            MasKUsuarioP_TextChanged(sender, e);
        }

        private void dataGridViewUsuP_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dataGridViewUsuP.Rows[e.RowIndex];
                id = row.Cells["id"].Value is DBNull ? 0 : Convert.ToInt32(row.Cells["id"].Value);
            }
        }

        private void MaskUsuarioP_MaskInputRejected(object sender, MaskInputRejectedEventArgs e) { }

        // ------------------- PEÇAS -------------------
        //Gabriel fez alterações

        private void FormatarGridPecas()
        {
            if (dataGridViewPecasP.ColumnCount > 0)
            {
                dataGridViewPecasP.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                dataGridViewPecasP.Columns["id"].HeaderText = "id";
                dataGridViewPecasP.Columns["tipo_peca"].HeaderText = "tipo_peca";
                dataGridViewPecasP.Columns["modelo"].HeaderText = "modelo";
                dataGridViewPecasP.Columns["marca"].HeaderText = "marca";
                dataGridViewPecasP.Columns["estado"].HeaderText = "estado";
                dataGridViewPecasP.Columns["quantidade_min"].HeaderText = "quantidade_min";
                dataGridViewPecasP.Columns["quantidade"].HeaderText = "quantidade";
                dataGridViewPecasP.Columns["id"].Visible = false;

            }
        }

        private void BtnPesquisarPecas_Click(object sender, EventArgs e)
        {
            string criterio = maskePecaP.Text;
            ClassPesquisas db = new ClassPesquisas();

            if (string.IsNullOrEmpty(criterio))
            {
                dataGridViewPecasP.DataSource = db.Pesquisarpeca();
            }
            else
            {
                dataGridViewPecasP.DataSource = db.PesquisaPecass(criterio);
            }

            FormatarGridPecas();
        }

        private void maskePecaP_TextChanged(object sender, EventArgs e)
        {
            BtnPesquisarPecas_Click(sender, e); // Reaproveita o mesmo código de pesquisa
        }

        private void maskePecaP_MaskInputRejected(object sender, MaskInputRejectedEventArgs e) { }

        private void dataGridViewPecasP_CellContentClick(object sender, DataGridViewCellEventArgs e) { }

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
