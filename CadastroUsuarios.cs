//PARTE DE GABRIEL

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Data;
using System.Windows.Forms;

namespace projeto_1
{
    //CONEXÃO COM O BANCO PARA CADASTRAR UM USUARIO
    public class CadastroUsuarios
    {
        private readonly string stringDeConexao = "Server=localhost;Database=eletronica;User=root;Password=123456;";



        public bool AdicionarUsuario(int id, string cpf, string nome, string email, string telefone, string endereco, string cargo, string senha, string data_nascimento, string data_admissao)
        {
            using (MySqlConnection conexao = new MySqlConnection(stringDeConexao))
            {
                try
                {
                    conexao.Open();
                    string comandoSql = "INSERT INTO cadastro (cpf, nome, email, telefone, endereco, cargo, senha, data_nascimento, data_admissao) VALUES (@cpf,@nome,@email,@telefone,@endereco,@cargo,@senha,@data_nascimento,@data_admissao )";
                    using (MySqlCommand comand = new MySqlCommand(comandoSql, conexao))
                    {
                        comand.Parameters.AddWithValue("@cpf", cpf);
                        comand.Parameters.AddWithValue("@nome", nome);
                        comand.Parameters.AddWithValue("@email", email);
                        comand.Parameters.AddWithValue("@telefone", telefone);
                        comand.Parameters.AddWithValue("@endereco", endereco);
                        comand.Parameters.AddWithValue("@cargo", cargo);
                        comand.Parameters.AddWithValue("@senha", senha);
                        comand.Parameters.AddWithValue("@data_nascimento", data_nascimento);
                        comand.Parameters.AddWithValue("@data_admissao", data_admissao);

                        int linhasAfetadas = comand.ExecuteNonQuery();
                        return linhasAfetadas > 0;
                    }
                }
                catch (MySqlException ex)
                {
                    if (ex.Number == 1062)
                    {
                        MessageBox.Show("Erro ao cadastrar: o CPF informado já existe.", "Erro de Duplicidade", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                    {
                        MessageBox.Show("Erro de banco de dados: " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    return false;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Ocorreu um erro inesperado: " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
            }
        }
        //TABELA PARA PESQUISA
        public DataTable PesquisarUsuario()
        {
            DataTable dataTable = new DataTable();
            using (MySqlConnection conexao = new MySqlConnection(stringDeConexao))
            {
                try
                {
                    conexao.Open();
                    string comandoSql = "SELECT id,cpf, nome, email, telefone, endereco, cargo, senha, data_nascimento, data_admissao  From  cadastro ORDER BY cpf ASC";
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
        // -MÉTODO PARA PESQUISAR CONTATOS POR UM CRITÉRIO (NOME)
        public DataTable PesquisarUsuario(string criterio)
        {
            DataTable dataTable = new DataTable();
            using (MySqlConnection conexao = new MySqlConnection(stringDeConexao))
            {
                try
                {
                    conexao.Open();
                    string comandoSql = "SELECT id, cpf, nome, email, telefone, endereco, cargo, senha, data_nascimento, data_admissao FROM cadastro WHERE nome LIKE @criterio OR cpf LIKE @criterio ORDER BY nome ASC";
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


        // MÉTODO PARA ATUALIZAR UM USUARIO
        public bool AtualizarUsuario(int id, string cpf, string nome, string email, string telefone, string endereco, string cargo, string senha, string data_nascimento, string data_admissao)
        {
            using (MySqlConnection conexao = new MySqlConnection(stringDeConexao))
            {
                try
                {
                    conexao.Open();

                    // O comando UPDATE usa SET para definir os novos valores e WHERE para especificar QUAL registro atualizar.
                    // É CRUCIAL usar o WHERE id = @id, senão você atualizaria TODOS os contatos do banco!
                    string comandoSql = "UPDATE cadastro SET cpf = @cpf, nome = @nome, email = @email, telefone = @telefone, endereco = @endereco, cargo = @cargo, senha = @senha, data_nascimento = @data_nascimento, data_admissao = @data_admissao WHERE id = @id";

                    using (MySqlCommand comando = new MySqlCommand(comandoSql, conexao))
                    {
                        // Adiciona os parâmetros, incluindo o ID do registro a ser atualizado.
                        comando.Parameters.AddWithValue("@cpf", cpf);
                        comando.Parameters.AddWithValue("@nome", nome);
                        comando.Parameters.AddWithValue("@email", email);
                        comando.Parameters.AddWithValue("@telefone", telefone);
                        comando.Parameters.AddWithValue("@endereco", endereco);
                        comando.Parameters.AddWithValue("@cargo", cargo);
                        comando.Parameters.AddWithValue("@senha", senha);
                        comando.Parameters.AddWithValue("@data_nascimento", data_nascimento);
                        comando.Parameters.AddWithValue("@data_admissao", data_admissao);
                        comando.Parameters.AddWithValue("@id", id);

                        int linhasAfetadas = comando.ExecuteNonQuery();


                        return linhasAfetadas > 0;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Erro ao atualizar usuario: " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
            }
        }

        // MÉTODO PARA EXCLUIR UM USUARIO
        public bool ExcluirUsuario(int id)
        {
            using (MySqlConnection conexao = new MySqlConnection(stringDeConexao))
            {
                try
                {
                    conexao.Open();

                    // Comando SQL para deletar um registro específico.
                    string comandoSql = "DELETE FROM cadastro WHERE id = @id";

                    using (MySqlCommand comando = new MySqlCommand(comandoSql, conexao))
                    {
                        // Adiciona o parâmetro com o ID do registro a ser excluído
                        comando.Parameters.AddWithValue("@id", id);

                        // Executa o comando
                        int linhasAfetadas = comando.ExecuteNonQuery();

                        // Retorna true se uma linha foi afetada (excluída com sucesso)
                        return linhasAfetadas > 0;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Erro ao excluir usuario: " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
            }

        }

        // PARTE DE LOGIN

        public bool loginUsuario(string cpf, string senha)
        {
            using (MySqlConnection conexao = new MySqlConnection(stringDeConexao))
            {
                try
                {
                    conexao.Open();

                    string comandoSql = "SELECT COUNT(*) FROM cadastro WHERE cpf = @cpf AND senha = @senha";

                    using (MySqlCommand comando = new MySqlCommand(comandoSql, conexao))
                    {
                        //PARAMETROS PARA LOGIN
                        comando.Parameters.AddWithValue("@cpf", cpf);
                        comando.Parameters.AddWithValue("@senha", senha);

                        int count = Convert.ToInt32(comando.ExecuteScalar());

                        return count == 0; // true = login válido
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Erro ao efetuar login: " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false; // EM CASO DE ERRO RETORNAR
                }
            }
        }

        public class Cadastropeca
        {
            private readonly string stringDeConexao = "Server=localhost;Database=eletronica;User=root;Password=123456;";



            public bool Adicionarpeca(int id, string tipo_peca, string modelo, string marca, string estado, string quantidade_min, string quantidade)
            {
                using (MySqlConnection conexao = new MySqlConnection(stringDeConexao))
                {
                    try
                    {
                        conexao.Open();
                        string comandoSql = "INSERT INTO pecas (tipo_peca, modelo, marca, estado, quantidade_min, quantidade) VALUES (@tipo_peca,@modelo,@marca,@estado,@quantidade_min,@quantidade)";
                        using (MySqlCommand comand = new MySqlCommand(comandoSql, conexao))
                        {
                            comand.Parameters.AddWithValue("@tipo_peca", tipo_peca);
                            comand.Parameters.AddWithValue("@modelo", modelo);
                            comand.Parameters.AddWithValue("@marca", marca);
                            comand.Parameters.AddWithValue("@estado", estado);
                            comand.Parameters.AddWithValue("@quantidade_min", quantidade_min);
                            comand.Parameters.AddWithValue("@quantidade", quantidade);


                            int linhasAfetadas = comand.ExecuteNonQuery();
                            return linhasAfetadas > 0;
                        }
                    }
                   
                    catch (Exception ex)
                    {
                        MessageBox.Show("Ocorreu um erro inesperado: " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return false;
                    }
                }
            }
        }

        public class RelatorioEstoque
        {
            private string connString = "Server=localhost;Database=eletronica;User=root;Password=123456;";

            public List<(int id, string tipo, int quantidade, int minimo)> Gerar()
            {
                List<(int, string, int, int)> lista = new List<(int, string, int, int)>();

                using (var conn = new MySqlConnection(connString))
                {
                    conn.Open();
                    string sql = "SELECT id, tipo_peca, quantidade, quantidade_min FROM pecas";

                    MySqlCommand cmd = new MySqlCommand(sql, conn);
                    MySqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        int id = Convert.ToInt32(reader["id"]);
                        string tipo = reader["tipo_peca"].ToString();

                        int quantidade = 0;
                        int.TryParse(reader["quantidade"].ToString(), out quantidade);

                        int minimo = Convert.ToInt32(reader["quantidade_min"]);

                        lista.Add((id, tipo, quantidade, minimo));
                    }
                }

                return lista;
            }
        }
        public bool Atualizarpeca(int id, string tipo_peca, string modelo, string marca, string estado, string quantidade_min, string quantidade)
        {
            using (MySqlConnection conexao = new MySqlConnection(stringDeConexao))
            {
                try
                {
                    conexao.Open();

                    // O comando UPDATE usa SET para definir os novos valores e WHERE para especificar QUAL registro atualizar.
                    // É CRUCIAL usar o WHERE id = @id, senão você atualizaria TODOS os contatos do banco!
                    string comandoSql = "UPDATE pecas SET tipo_peca = @tipo_peca, modelo = @modelo, marca = @marca, estado = @estado, quantidade_min = @quantidade_min, quantidade = @quantidade WHERE id = @id";

                    using (MySqlCommand comando = new MySqlCommand(comandoSql, conexao))
                    {
                        // Adiciona os parâmetros, incluindo o ID do registro a ser atualizado.
                        comando.Parameters.AddWithValue("@tipo_peca", tipo_peca);
                        comando.Parameters.AddWithValue("@modelo", modelo);
                        comando.Parameters.AddWithValue("@marca", marca);
                        comando.Parameters.AddWithValue("@estado", estado);
                        comando.Parameters.AddWithValue("@quantidade_min", quantidade_min);
                        comando.Parameters.AddWithValue("@quantidade", quantidade);
                        comando.Parameters.AddWithValue("@id", id);

                        int linhasAfetadas = comando.ExecuteNonQuery();


                        return linhasAfetadas > 0;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Erro ao atualizar peça: " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
            }
        }
                 public bool Excluirpeca(int id)
        {
            using (MySqlConnection conexao = new MySqlConnection(stringDeConexao))
            {
                try
                {
                    conexao.Open();

                    // Comando SQL para deletar um registro específico.
                    string comandoSql = "DELETE FROM pecas WHERE id = @id";

                    using (MySqlCommand comando = new MySqlCommand(comandoSql, conexao))
                    {
                        // Adiciona o parâmetro com o ID do registro a ser excluído
                        comando.Parameters.AddWithValue("@id", id);

                        // Executa o comando
                        int linhasAfetadas = comando.ExecuteNonQuery();

                        // Retorna true se uma linha foi afetada (excluída com sucesso)
                        return linhasAfetadas > 0;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Erro ao excluir peça: " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
            }

        }
        public DataTable Pesquisarpeca(string criterio)
        {
            DataTable dataTable = new DataTable();
            using (MySqlConnection conexao = new MySqlConnection(stringDeConexao))
            {
                try
                {
                    conexao.Open();
                    string comandoSql = "SELECT id, tipo_peca, modelo, marca, estado, quantidade_min, quantidade FROM pecas WHERE tipo_peca LIKE @criterio OR modelo LIKE @criterio ORDER BY tipo_peca ASC";
                    using (MySqlDataAdapter adapter = new MySqlDataAdapter(comandoSql, conexao))
                    {
                        adapter.SelectCommand.Parameters.AddWithValue("@criterio", "%" + criterio + "%");
                        adapter.Fill(dataTable);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Erro ao pesquisar peça: " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            return dataTable;
        }
        public DataTable Pesquisarpeca()
        {
            DataTable dataTable = new DataTable();
            using (MySqlConnection conexao = new MySqlConnection(stringDeConexao))
            {
                try
                {
                    conexao.Open();
                    string comandoSql = "SELECT id, tipo_peca, modelo, marca, estado, quantidade_min, quantidade  From  pecas ORDER BY cpf ASC";
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
    }
        }

    

