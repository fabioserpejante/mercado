using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace MercadoZe.Classes.DAO
{
    public class PedidoDAO
    {
        private string _connectionString = @"server=.\SQLexpress;initial catalog=MERCADO_ZE;integrated security=true;";

        public PedidoDAO()
        {
        }

        public void AdicionarPedido(Pedido novoPedido)
        {
            using (var conexao = new SqlConnection(_connectionString))
            {
                conexao.Open(); //ABRIR CONEXÃO

                using (var comando = new SqlCommand())
                {
                    comando.Connection = conexao; //CRIAR UM COMANDO

                    //CRIA SCRIPT
                    string sql = @"INSERT INTO PEDIDO 
                                        VALUES 
                                            (@QUANTIDADE, 
                                            @DATAHORA, 
                                            @PRODUTO_ID, 
                                            @CLIENTE_ID, 
                                            @VALORTOTAL);";

                    comando.Parameters.AddWithValue("@QUANTIDADE", novoPedido.Quantidade);
                    comando.Parameters.AddWithValue("@DATAHORA", novoPedido.DataHora.Date);
                    comando.Parameters.AddWithValue("@PRODUTO_ID", novoPedido.Produto.Id);
                    comando.Parameters.AddWithValue("@CLIENTE_ID", novoPedido.Cliente.CPF);
                    comando.Parameters.AddWithValue("@VALORTOTAL", novoPedido.ValorTotal);

                    comando.CommandText = sql;

                    comando.ExecuteNonQuery(); 
                }
            }
        }

        public List<Pedido> BuscaTodos()
        {
            var listaPedido = new List<Pedido>(); //CRIA LISTA

            using (var conexao = new SqlConnection(_connectionString))
            {
                conexao.Open(); //ABRIR CONEXÃO

                using (var comando = new SqlCommand())
                {
                    comando.Connection = conexao; //CRIAR UM COMANDO

                    string sql = @"SELECT  PE.NUMERO, 
                                        PE.VALORTOTAL, 
                                        PE.QUANTIDADE, 
                                        PE.DATAHORA, 
                                        P.NUMERO AS NUMERO_PRODUTO,
                                        C.NUMERO AS NUMERO_CLIENTE 
                                    FROM PEDIDO PE
                                    LEFT JOIN PRODUTO P 
                                        ON P.ID = PE.PRODUTO_ID
                                    LEFT JOIN CLIENTE C 
                                        ON C.CPF = PE.CPF";

                    //ATRIBUIR SCRIPT 
                    comando.CommandText = sql;

                    SqlDataReader leitor = comando.ExecuteReader(); //EXECUTA SCRIPT

                    while (leitor.Read())
                    {
                        //ATRIBUI PEDIDO BUSCADO
                        Pedido pedidoBuscado = new Pedido();
                        pedidoBuscado.Numero = int.Parse(leitor["NUMERO"].ToString());
                        pedidoBuscado.ValorTotal = double.Parse(leitor["VALORTOTAL"].ToString());
                        pedidoBuscado.DataHora = DateTime.Parse(leitor["DATAHORA"].ToString());
                        pedidoBuscado.Produto.Nome = leitor["NUMERO_PRODUTO"].ToString();
                        pedidoBuscado.Cliente.Nome = leitor["NUMETO_CLIENTE"].ToString();

                        //ADICIONA NA LISTA
                        listaPedido.Add(pedidoBuscado);
                    }
                }
            }

            return listaPedido;
        
        }
        
        private Pedido ConverterSqlParaObjeto(SqlDataReader leitor)
        {
            var pedido = new Pedido();
            pedido.Numero = int.Parse(leitor["NUMERO"].ToString());
            pedido.ValorTotal = double.Parse(leitor["VALORTOTAL"].ToString());
            pedido.Quantidade = int.Parse(leitor["QUANTIDADE"].ToString());
            pedido.DataHora = Convert.ToDateTime(leitor["DATAHORA"].ToString());
            
            return pedido;
        }

        private void ConverterObjetoParaSql(Pedido pedido, SqlCommand comando)
        {
            //ADICIONANDO PARAMETROS
            comando.Parameters.AddWithValue("@NUMERO", pedido.Numero);
            comando.Parameters.AddWithValue("@VALORTOTAL", pedido.ValorTotal);
            comando.Parameters.AddWithValue("@QUANTIDADE", pedido.Quantidade);
            comando.Parameters.AddWithValue("@DATAHORA", pedido.DataHora);
            
        }
    }
}