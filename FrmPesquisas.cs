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
            CarregarPecasGrid(); // Carrega grid de peças ao iniciar
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
        private void CarregarPecasGrid()
        {
            ClassPesquisas db = new ClassPesquisas();
            dataGridViewPecasP.DataSource = db.PesquisaPecas();

            // Adiciona a coluna "quantidade" se não existir
            if (!dataGridViewPecasP.Columns.Contains("quantidade"))
            {
                DataGridViewTextBoxColumn colunaQuantidade = new DataGridViewTextBoxColumn();
                colunaQuantidade.Name = "quantidade";
                colunaQuantidade.HeaderText = "Quantidade";
                colunaQuantidade.ValueType = typeof(int);
                dataGridViewPecasP.Columns.Add(colunaQuantidade);

                // Opcional: preenche a coluna com valores padrão (exemplo: 0)
                foreach (DataGridViewRow row in dataGridViewPecasP.Rows)
                {
                    row.Cells["quantidade"].Value = 0;
                }
            }

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
                if (dataGridViewPecasP.Columns.Contains("quantidade"))
                    dataGridViewPecasP.Columns["quantidade"].HeaderText = "Quantidade (Visual)";
                if (dataGridViewPecasP.Columns.Contains("quantidade_estoque"))
                    dataGridViewPecasP.Columns["quantidade_estoque"].HeaderText = "Quantidade em Estoque";
            }
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

        private void maskePecaP_TextChanged(object sender, EventArgs e)
        {
            BtnPesquisarPecas_Click(sender, e); // Reaproveita o mesmo código de pesquisa
        }

        private void maskePecaP_MaskInputRejected(object sender, MaskInputRejectedEventArgs e) { }

        private void dataGridViewPecasP_CellContentClick(object sender, DataGridViewCellEventArgs e) { }
    }
}
