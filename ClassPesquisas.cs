using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data; // Necessário para usar o DataTable
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace projeto_1
{
    public class ClassPesquisas
    {
        private readonly string stringDeConexao = "Server=localhost;Database=eletronica;User=root;Password=123456;";


        public DataTable PesquisaUsu()
        {

            DataTable dataTable = new DataTable();
            using (MySqlConnection conexao = new MySqlConnection(stringDeConexao))
            {
                try
                {
                    conexao.Open();
                    string comandoSql = "SELECT id, cpf, nome, email, telefone, endereco, cargo, data_admissao, data_nascimento, senha From  cadastro ORDER BY cpf ASC";
                    using (MySqlDataAdapter adapter = new MySqlDataAdapter(comandoSql, conexao))
                    {
                        adapter.Fill(dataTable);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Erro ao Listar usuario:" + ex.Message, "Erro",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            return dataTable;



        }
        // --- MÉTODO PARA PESQUISAR CONTATOS POR UM CRITÉRIO (NOME OU CPF) ---
        public DataTable PesquisarUsuarioo(string criterio)
        {
            DataTable dataTable = new DataTable();
            using (MySqlConnection conexao = new MySqlConnection(stringDeConexao))
            {
                try
                {
                    conexao.Open();
                    string comandoSql = "SELECT id, cpf, nome, email, telefone, endereco, cargo, data_admissao, data_nascimento, senha FROM cadastro WHERE nome LIKE @criterio OR cpf LIKE @criterio ORDER BY nome ASC";
                    using (MySqlDataAdapter adapter = new MySqlDataAdapter(comandoSql, conexao))
                    {
                        adapter.SelectCommand.Parameters.AddWithValue("@criterio", "%" + criterio + "%");
                        adapter.Fill(dataTable);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Erro ao pesquisar usuario: " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            return dataTable;
        }
        // --- MÉTODO PARA PESQUISAR PEÇAS ---
        public DataTable PesquisaPecas()
        {
            DataTable dataTable = new DataTable();
            using (MySqlConnection conexao = new MySqlConnection(stringDeConexao))
            {
                try
                {
                    conexao.Open();
                    string comandoSql = "SELECT id, tipo_peca, marca, estado, quantidade_min, modelo From  pecas ORDER BY tipo_peca ASC";
                    using (MySqlDataAdapter adapter = new MySqlDataAdapter(comandoSql, conexao))
                    {
                        adapter.Fill(dataTable);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Erro ao Listar peças:" + ex.Message, "Erro",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }
            return dataTable;
        }
        // --- MÉTODO PARA PESQUISAR PEÇAS POR UM CRITÉRIO (TIPO OU MODELO) ---
        public DataTable PesquisaPecass(string criterio)
        {
            DataTable dataTable = new DataTable();
            using (MySqlConnection conexao = new MySqlConnection(stringDeConexao))
            {
                try
                {
                    conexao.Open();
                    string comandoSql = "SELECT id, tipo_peca, marca, estado, quantidade_min, modelo FROM pecas WHERE tipo_peca LIKE @criterio OR modelo LIKE @criterio ORDER BY tipo_peca ASC";
                    using (MySqlDataAdapter adapter = new MySqlDataAdapter(comandoSql, conexao))
                    {
                        adapter.SelectCommand.Parameters.AddWithValue("@criterio", "%" + criterio + "%");
                        adapter.Fill(dataTable);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Erro ao pesquisar peças: " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            return dataTable;
        }



    }

}