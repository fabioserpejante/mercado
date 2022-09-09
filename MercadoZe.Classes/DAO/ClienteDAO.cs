
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using MercadoZe.Classes;

namespace MercadoZe.Classes.DAO
{
    public class ClienteDAO
    {
        private string _connectionString = @"server=.\SQLexpress;initial catalog=MERCADO_ZE;integrated security=true;";

        public ClienteDAO()
        {
        }

        public void AdicionarCliente(Cliente novoCliente)
        {
            using (var conexao = new SqlConnection(_connectionString))
            {
                conexao.Open(); //ABRIR CONEXÃO

                using (var comando = new SqlCommand())
                {
                    comando.Connection = conexao; //CRIAR UM COMANDO

                    //CRIA SCRIPT
                    string sql = @"INSERT CLIENTE VALUES (@CPF, @DATA_NASCIMENTO, 
                    @PONTOS_FIDELIDADE, @RUA, @NUMERO, @BAIRRO, @CEP, @COMPLEMENTO, @NOME);";

                    //ADICIONANDO PARAMETROS
                    ConverterObjetoParaSql(novoCliente, comando);

                    //ATRIBUIR SCRIPT 
                    comando.CommandText = sql;

                    //EXECUTA SCRIPT
                    comando.ExecuteNonQuery();
                }
            }
        }

        public List<Cliente> BuscaTodos()
        {
            var listaCliente = new List<Cliente>(); //CRIA LISTA

            using (var conexao = new SqlConnection(_connectionString))
            {
                conexao.Open(); //ABRIR CONEXÃO

                using (var comando = new SqlCommand())
                {
                    comando.Connection = conexao; //CRIAR UM COMANDO

                    string sql = @"SELECT CPF, NOME, DATA_NASCIMENTO, 
                                     PONTOS_FIDELIDADE, RUA, NUMERO, 
                                     BAIRRO, CEP, COMPLEMENTO FROM CLIENTE;"; //CRIA SCRIPT

                    //ATRIBUIR SCRIPT 
                    comando.CommandText = sql;

                    SqlDataReader leitor = comando.ExecuteReader(); //EXECUTA SCRIPT

                    while (leitor.Read())
                    {
                        //ATRIBUI CLIENTE BUSCADO
                        Cliente clienteBuscado = ConverterSqlParaObjeto(leitor);

                        //ADICIONA NA LISTA
                        listaCliente.Add(clienteBuscado);
                    }
                }
            }

            return listaCliente;
        }

        public void DeletarCliente(Cliente clienteBuscado)
        {
            using (var conexao = new SqlConnection(_connectionString))
            {
                conexao.Open(); //ABRIR CONEXÃO

                using (var comando = new SqlCommand())
                {
                    comando.Connection = conexao; //CRIAR UM COMANDO

                    //CRIA SCRIPT
                    string sql = @"DELETE FROM PRODUTO WHERE CPF = @CPF_CLIENTE;";

                    //ADICIONAR PARAMETROS
                    comando.Parameters.AddWithValue("@CPF_CLIENTE", clienteBuscado.CPF);

                    //ATRIBUIR SCRIPT
                    comando.CommandText = sql;

                    //EXECUTAR SCRIPT
                    comando.ExecuteNonQuery();
                }
            }
        }

        public void AtualizarCliente(Cliente clienteBuscado)
        {
            using (var conexao = new SqlConnection(_connectionString))
            {
                conexao.Open(); //ABRIR CONEXÃO

                using (var comando = new SqlCommand())
                {
                    comando.Connection = conexao; //CRIAR UM COMANDO

                    //CRIA SCRIPT
                    string sql = @"UPDATE CLIENTE SET            
                                        NOME = @NOME,
                                        DATA_NASCIMENTO = @DATA_NASCIMENTO,
                                        PONTOS_FIDELIDADE = @PONTOS_FIDELIDADE,
                                        RUA = @RUA,
                                        NUMERO = @NUMERO,
                                        BAIRRO = @BAIRRO,
                                        CEP = @CEP,
                                        COMPLEMENTO = @COMPLEMENTO
                                 WHERE CPF = @CPF_CLIENTE;";

                    //ADICIONAR PARAMETROS
                    ConverterObjetoParaSql(clienteBuscado, comando);
                    comando.Parameters.AddWithValue("@CPF_CLIENTE", clienteBuscado.CPF);

                    //ATRIBUIR SCRIPT
                    comando.CommandText = sql;

                    //EXECUTAR SCRIPT
                    comando.ExecuteNonQuery();
                }
            }
        }

        public List<Cliente> BuscaPorTexto(string nome)
        {
            var listaCliente = new List<Cliente>(); //CRIA LISTA

            using (var conexao = new SqlConnection(_connectionString))
            {
                conexao.Open(); //ABRIR CONEXÃO

                using (var comando = new SqlCommand())
                {
                    comando.Connection = conexao; //CRIAR UM COMANDO

                    string sql = @"SELECT CPF, NOME, DATA_NASCIMENTO, 
                                     PONTOS_FIDELIDADE, RUA, NUMERO, 
                                     BAIRRO, CEP, COMPLEMENTO 
                                  FROM CLIENTE WHERE NOME LIKE @TEXTO;"; //CRIA SCRIPT

                    comando.Parameters.AddWithValue("@TEXTO", $"%{nome}%");

                    //ATRIBUIR SCRIPT 
                    comando.CommandText = sql;

                    SqlDataReader leitor = comando.ExecuteReader(); //EXECUTA SCRIPT

                    while (leitor.Read())
                    {
                        //ATRIBUI CLIENTE BUSCADO
                        var clienteBuscado = ConverterSqlParaObjeto(leitor);
                        //ADICIONA NA LISTA
                        listaCliente.Add(clienteBuscado);
                    }
                }
            }

            return listaCliente;
        }

        public Cliente BuscarPorCpf(long cpf)
        {
            var clienteBuscado = new Cliente();

            using (var conexao = new SqlConnection(_connectionString))
            {
                conexao.Open(); //ABRIR CONEXÃO

                using (var comando = new SqlCommand())
                {
                    comando.Connection = conexao; //CRIAR UM COMANDO

                    string sql = @"SELECT CPF, NOME, DATA_NASCIMENTO, 
                                     PONTOS_FIDELIDADE, RUA, NUMERO, 
                                     BAIRRO, CEP, COMPLEMENTO 
                                  FROM CLIENTE WHERE CPF = @CPF_CLIENTE;"; //CRIA SCRIPT

                    comando.Parameters.AddWithValue("@CPF_CLIENTE", cpf);

                    //ATRIBUIR SCRIPT 
                    comando.CommandText = sql;

                    SqlDataReader leitor = comando.ExecuteReader(); //EXECUTA SCRIPT

                    while (leitor.Read())
                    {
                        //ATRIBUI CLIENTE BUSCADO
                        clienteBuscado = ConverterSqlParaObjeto(leitor);
                    }
                }
            }

            return clienteBuscado;
        }

        private Cliente ConverterSqlParaObjeto(SqlDataReader leitor)
        {
            var cliente = new Cliente();
            cliente.CPF = long.Parse(leitor["CPF"].ToString());
            cliente.Nome = leitor["NOME"].ToString();
            cliente.DataNascimento = Convert.ToDateTime(leitor["DATA_NASCIMENTO"].ToString());
            cliente.PontosFidelidade = int.Parse(leitor["PONTOS_FIDELIDADE"].ToString());
            cliente.Endereco = new Endereco
            {
                Rua = leitor["RUA"].ToString(),
                Numero = int.Parse(leitor["NUMERO"].ToString()),
                Bairro = leitor["BAIRRO"].ToString(),
                Cep = leitor["CEP"].ToString(),
                Complemento = leitor["COMPLEMENTO"].ToString(),
            };

            return cliente;
        }

        private void ConverterObjetoParaSql(Cliente cliente, SqlCommand comando)
        {
            //ADICIONANDO PARAMETROS
            comando.Parameters.AddWithValue("@CPF", cliente.CPF);
            comando.Parameters.AddWithValue("@DATA_NASCIMENTO", cliente.DataNascimento);
            comando.Parameters.AddWithValue("@PONTOS_FIDELIDADE", cliente.PontosFidelidade);
            comando.Parameters.AddWithValue("@RUA", cliente.Endereco.Rua);
            comando.Parameters.AddWithValue("@NUMERO", cliente.Endereco.Numero);
            comando.Parameters.AddWithValue("@BAIRRO", cliente.Endereco.Bairro);
            comando.Parameters.AddWithValue("@CEP", cliente.Endereco.Cep);
            comando.Parameters.AddWithValue("@COMPLEMENTO", cliente.Endereco.Complemento);
            comando.Parameters.AddWithValue("@NOME", cliente.Nome);
        }
    }
}