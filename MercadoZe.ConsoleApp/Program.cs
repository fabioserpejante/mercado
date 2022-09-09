﻿
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using MercadoZe.Classes;
using MercadoZe.Classes.DAO;

namespace MercadoZe.ConsoleApp
{
    class Program
    {
        static ProdutoDAO _produtoDao = new ProdutoDAO();
        static ClienteDAO _clienteDao = new ClienteDAO();
        static PedidoDAO _pedidoDao = new PedidoDAO();
        static string _opcaoProduto = "";
        static string _opcaoCliente = "";
        static string _opcaoPedido = "";

        static string _opcaoPrincipal = "";
        
        static int _idProduto = 0;
        static long _cpfCliente = 0;

        static Produto _produtoEncontrado = new Produto();
        static Cliente _clienteEncontrado = new Cliente();
        static List<Produto> _listaProdutos = new List<Produto>();
        static List<Cliente> _listaClientes = new List<Cliente>();

        static List<Pedido> _listaPedidos = new List<Pedido>();


        static void Main(string[] args)
        {
            EscolherUmaOpcaoPrincipal();
        }

        //MENU
        public static void EscolherUmaOpcaoPrincipal()
        {
            Console.Clear();
            Console.WriteLine(" --         MENU PRINCIPAL         -- ");
            Console.WriteLine(" Escolha umas das opções abaixo:");
            Console.WriteLine(" 1 - Gerenciar Produto");
            Console.WriteLine(" 2 - Gerenciar Cliente");
            Console.WriteLine(" 3 - Gerenciar Pedido");
            Console.Write("=> ");
            _opcaoPrincipal = Console.ReadLine();

            switch (_opcaoPrincipal)
            {
                case "1":
                    Console.Clear();
                    GerenciarProduto();
                    break;
                case "2":
                    Console.Clear();
                    GerenciarCliente();
                    break;
                case "3":
                    Console.Clear();
                    GerenciarPedido();
                    break;    
                default:
                    Console.Clear();
                    break;
            }

        }

        public static void GerenciarCliente()
        {
            Console.Clear();
            Console.WriteLine(" --         MENU CLIENTE       -- ");
            Console.WriteLine(" Escolha umas das opções abaixo:");
            Console.WriteLine(" 1 - Cadastrar cliente");
            Console.WriteLine(" 2 - Editar cliente");
            Console.WriteLine(" 3 - Deletar cliente");
            Console.WriteLine(" 4 - Buscar cliente por CPF");
            Console.WriteLine(" 5 - Buscar cliente por texto");
            Console.WriteLine(" 6 - Buscar todos os cliente");
            Console.WriteLine(" 7 - Voltar ao menu principal");
            Console.Write("=> ");
            _opcaoCliente = Console.ReadLine();

            FuncionalidadesCliente();
        }

        public static void GerenciarProduto()
        {
            Console.Clear();
            Console.WriteLine(" --         MENU PRODUTO       -- ");
            Console.WriteLine(" Escolha umas das opções abaixo:");
            Console.WriteLine(" 1 - Cadastrar produto");
            Console.WriteLine(" 2 - Editar produto");
            Console.WriteLine(" 3 - Deletar produto");
            Console.WriteLine(" 4 - Buscar produto por indentificador");
            Console.WriteLine(" 5 - Buscar produto por texto");
            Console.WriteLine(" 6 - Buscar todos os produtos");
            Console.WriteLine(" 7 - Entrada de produtos");
            Console.WriteLine(" 8 - Saída de produtos");
            Console.WriteLine(" 9 - Voltar ao menu principal");
            Console.Write("=> ");
            _opcaoProduto = Console.ReadLine();

            FuncionalidadesProduto();
        }

        public static void GerenciarPedido()
        {
            Console.Clear();
            Console.WriteLine(" --         MENU PEDIDO       -- ");
            Console.WriteLine(" Escolha umas das opções abaixo:");
            Console.WriteLine(" 1 - Cadastrar pedido");
            Console.WriteLine(" 2 - Buscar todos os pedidos");
            Console.WriteLine(" 3 - Voltar ao menu principal");
            Console.Write("=> ");
            _opcaoPedido = Console.ReadLine();

            FuncionalidadesPedido();
        }

        //MENU

        //VOLTAR
        public static void VoltarMenuProduto()
        {
            GerenciarProduto();
        }

        public static void VoltarMenuCliente()
        {
            GerenciarCliente();
        }

        public static void VoltarMenuPedido()
        {
            GerenciarPedido();
        }
        //VOLTAR

        //FUNCIONALIDADES
        public static void FuncionalidadesProduto()
        {
            switch (_opcaoProduto)
            {
                case "1":
                    Console.Clear();
                    AdicionarProduto();
                    VoltarMenuProduto();
                    break;
                case "2":
                    Console.Clear();
                    AtualizarProduto();
                    VoltarMenuProduto();
                    break;
                case "3":
                    Console.Clear();
                    DeletarProduto();
                    VoltarMenuProduto();
                    break;
                case "4":
                    Console.Clear();
                    BuscarProdutoPorId();
                    VoltarMenuProduto();
                    break;
                case "5":
                    Console.Clear();
                    BuscarProdutoPorTexto();
                    VoltarMenuProduto();
                    break;
                case "6":
                    Console.Clear();
                    BuscaTodosProdutos();
                    VoltarMenuProduto();
                    break;
                case "7":
                    Console.Clear();
                    EntradaEstoque();
                    Console.ReadKey();
                    VoltarMenuProduto();
                    break;
                case "8":
                    Console.Clear();
                    SaidaEstoque();
                    Console.ReadKey();
                    VoltarMenuProduto();
                    break;
                case "9":
                    Console.Clear();
                    EscolherUmaOpcaoPrincipal();
                    break;
                default:
                    Console.WriteLine("Opção inválida!");
                    Console.ReadKey();
                    VoltarMenuProduto();
                    break;
            }

        }

        public static void FuncionalidadesCliente()
        {
            switch (_opcaoCliente)
            {
                case "1":
                    Console.Clear();
                    AdicionarCliente();
                    VoltarMenuCliente();
                    break;
                case "2":
                    Console.Clear();
                    AtualizarCliente();
                    VoltarMenuCliente();
                    break;
                case "3":
                    Console.Clear();
                    DeletarCliente();
                    VoltarMenuCliente();
                    break;
                case "4":
                    Console.Clear();
                    BuscarClientePorCpf();
                    VoltarMenuCliente();
                    break;
                case "5":
                    Console.Clear();
                    BuscarClientePorTexto();
                    VoltarMenuCliente();
                    break;
                case "6":
                    Console.Clear();
                    BuscarTodosClientes();
                    VoltarMenuCliente();
                    break;
                case "7":
                    EscolherUmaOpcaoPrincipal();
                    break;
                default:
                    Console.WriteLine("Opção inválida!");
                    Console.ReadKey();
                    VoltarMenuCliente();
                    break;
            }

        }

        public static void FuncionalidadesPedido()
        {
            switch (_opcaoPedido)
            {
                case "1":
                    Console.Clear();
                    AdicionarPedido();
                    VoltarMenuPedido();
                    break;
                case "2":
                    Console.Clear();
                    BuscarTodosPedidos();
                    VoltarMenuPedido();
                    break;
                case "3":
                    EscolherUmaOpcaoPrincipal();
                    break;
                default:
                    Console.WriteLine("Opção inválida!");
                    Console.ReadKey();
                    VoltarMenuPedido();
                    break;
            }

        }
        //FUNCIONALIDADES

        //TELA PRODUTO
        public static void AdicionarProduto()
        {

            Produto novoProduto = new Produto();
            Console.WriteLine("--                   CADASTRO DE PRODUTO                -- ");

            Console.WriteLine("Digite o nome do produto:");
            novoProduto.Nome = Console.ReadLine();

            Console.WriteLine("Digite a descrição:");
            novoProduto.Descricao = Console.ReadLine();

            Console.WriteLine("Digite a data de vencimento:(DD/MM/YYYY)");
            novoProduto.DataVencimento = Convert.ToDateTime(Console.ReadLine());

            Console.WriteLine("Digite o preço unitário:");
            novoProduto.PrecoUnitario = double.Parse(Console.ReadLine());

            Console.WriteLine("Digite a unidade:");
            novoProduto.Unidade = Console.ReadLine();

            _produtoDao.AdicionarProduto(novoProduto);

        }

        public static void AtualizarProduto()
        {
            Console.Clear();
            Console.WriteLine(" --          EDITAR PRODUTO         -- \n");

            Console.WriteLine("Digite o id do produto que será editado:");
            _idProduto = Convert.ToInt32(Console.ReadLine());

            _produtoEncontrado = _produtoDao.BuscarPorId(_idProduto);

            if (_produtoEncontrado.Id == 0)
            {
                Console.WriteLine("Produto não encontrado!");
                Console.ReadKey();
                VoltarMenuProduto();
            }

            Console.WriteLine($" Produto que será editado:\n {_produtoEncontrado}");

            Console.ReadKey();

            Console.WriteLine("Digite o nome do produto:");
            _produtoEncontrado.Nome = Console.ReadLine();

            Console.WriteLine("Digite a descrição:");
            _produtoEncontrado.Descricao = Console.ReadLine();

            Console.WriteLine("Digite a data de vencimento:(DD/MM/YYYY)");
            _produtoEncontrado.DataVencimento = Convert.ToDateTime(Console.ReadLine());

            Console.WriteLine("Digite o preço unitário:");
            _produtoEncontrado.PrecoUnitario = double.Parse(Console.ReadLine());

            Console.WriteLine("Digite a unidade:");
            _produtoEncontrado.Unidade = Console.ReadLine();

            _produtoDao.AtualizarProduto(_produtoEncontrado);
        }

        public static void DeletarProduto()
        {
            Console.WriteLine(" --          DELETAR PRODUTO          -- \n");

            Console.WriteLine("Digite o id do produto que será editado:");
            _idProduto = Convert.ToInt32(Console.ReadLine());

            _produtoEncontrado = _produtoDao.BuscarPorId(_idProduto);

            if (_produtoEncontrado.Id == 0)
            {
                Console.WriteLine("Produto não encontrado!");
                Console.ReadKey();
                VoltarMenuProduto();
            }

            Console.WriteLine($" Produto que será deletado:\n {_produtoEncontrado}");
            Console.ReadKey();
            _produtoDao.DeletarProduto(_produtoEncontrado);

        }

        public static void BuscarProdutoPorId()
        {
            Console.WriteLine("--           PRODUTO         -- \n");

            Console.WriteLine("Digite o id do produto que será editado:");
            _idProduto = Convert.ToInt32(Console.ReadLine());

            _produtoEncontrado = _produtoDao.BuscarPorId(_idProduto);
            Console.WriteLine("Produto encontrado:");
            Console.WriteLine("--------------------------------------");
            if (_produtoEncontrado.Id != 0)
            {
                Console.WriteLine(_produtoEncontrado);
            }
            Console.ReadKey();
        }

        public static void BuscarProdutoPorTexto()
        {
            Console.WriteLine("--           LISTA PRODUTOS         -- \n");
            Console.WriteLine("Digite o texto do produto:");
            var texto = Console.ReadLine();
            _listaProdutos = _produtoDao.BuscaPorTexto(texto);

            Console.WriteLine("Produtos encontrados:");
            Console.WriteLine("--------------------------------------");
            foreach (var item in _listaProdutos)
            {
                Console.WriteLine(item);
                Console.WriteLine("--------------------------------------");
            }
            Console.ReadKey();
        }

        public static void BuscaTodosProdutos()
        {
            Console.WriteLine("--           LISTA PRODUTOS         -- \n");
            _listaProdutos = _produtoDao.BuscaTodos();

            foreach (var item in _listaProdutos)
            {
                Console.WriteLine(item);
                Console.WriteLine("--------------------------------------");
            }
            Console.ReadKey();
        }

        public static void EntradaEstoque()
        {
            Console.Clear();
            Console.WriteLine(" --          ENTRADA ESTOQUE         -- \n");

            Console.WriteLine("Digite o id do produto:");
            _idProduto = Convert.ToInt32(Console.ReadLine());

            _produtoEncontrado = _produtoDao.BuscarPorId(_idProduto);

            if (_produtoEncontrado.Id == 0)
            {
                Console.WriteLine("Produto não encontrado!");
                Console.ReadKey();
                VoltarMenuProduto();
            }

            Console.WriteLine($"Quantidade atual no estoque: {_produtoEncontrado.QuantidadeEstoque}");

            Console.ReadKey();

            Console.WriteLine("Digite a quantidade de entrada no estoque:");
            var quantidade = Convert.ToInt32(Console.ReadLine());

            _produtoEncontrado.EntradaEstoque(quantidade);
            _produtoDao.EntradaESaidaEstoque(_produtoEncontrado);
        }

        public static void SaidaEstoque()
        {
            Console.Clear();
            Console.WriteLine(" --          SAIDA ESTOQUE         -- \n");

            Console.WriteLine("Digite o id do produto:");
            _idProduto = Convert.ToInt32(Console.ReadLine());

            _produtoEncontrado = _produtoDao.BuscarPorId(_idProduto);

            if (_produtoEncontrado.Id == 0)
            {
                Console.WriteLine("Produto não encontrado!");
                Console.ReadKey();
                VoltarMenuProduto();
            }

            Console.WriteLine($"Quantidade atual no estoque: {_produtoEncontrado.QuantidadeEstoque}");

            Console.ReadKey();

            Console.WriteLine("Digite a quantidade de saída no estoque:");
            var quantidade = Convert.ToInt32(Console.ReadLine());

            _produtoEncontrado.SaidaEstoque(quantidade);
            _produtoDao.EntradaESaidaEstoque(_produtoEncontrado);
        }
        //TELA PRODUTO

        //TELA PEDIDO

        public static void AdicionarPedido()
        {
            Pedido novoPedido = new Pedido();
            Console.WriteLine("--                   CADASTRO DE PEDIDO                -- ");

            Console.WriteLine("Digite o ID do PRODUTO:");
            var _idProduto = int.Parse(Console.ReadLine());
            var produtoBuscado = _produtoDao.BuscarPorId(_idProduto);

            novoPedido.Produto = produtoBuscado;

            Console.WriteLine("Digite o CPF do cliente:");
            var _idCliente = Int64.Parse(Console.ReadLine());
            var clienteBuscado = _clienteDao.BuscarPorCpf(_idCliente);

            novoPedido.Cliente = clienteBuscado;


            Console.WriteLine("Digite a quantidade:");
            novoPedido.Quantidade = int.Parse(Console.ReadLine());

            Console.WriteLine("Digite a data:");
            novoPedido.DataHora = Convert.ToDateTime(Console.ReadLine());

            _pedidoDao.AdicionarPedido(novoPedido);

            

        }
        
        public static void BuscarTodosPedidos()
        {
            Console.WriteLine("--           LISTA PEDIDOS         -- \n");
            _listaPedidos = _pedidoDao.BuscaTodos();

            foreach (var item in _listaPedidos)
            {
                Console.WriteLine(item);
                Console.WriteLine("--------------------------------------");
            }

            Console.ReadKey();
        }

        //TELA PEDIDO

        
        public static void AdicionarCliente()
        {
            Cliente novoCliente = new Cliente();
            Console.WriteLine("--                   CADASTRO DE CLIENTE                -- ");

            Console.WriteLine("Digite o CPF do cliente:");
            novoCliente.CPF = long.Parse(Console.ReadLine());

            Console.WriteLine("Digite o nome:");
            novoCliente.Nome = Console.ReadLine();

            Console.WriteLine("Digite a data de nascimento:");
            novoCliente.DataNascimento = Convert.ToDateTime(Console.ReadLine());

            var endereco = new Endereco();

            Console.WriteLine(" - Cadastro de Endereço -");
            Console.WriteLine("Digite a rua:");
            endereco.Rua = Console.ReadLine();

            Console.WriteLine("Digite o número:");
            endereco.Numero = int.Parse(Console.ReadLine());

            Console.WriteLine("Digite o bairro:");
            endereco.Bairro = Console.ReadLine();

            Console.WriteLine("Digite o cep:");
            endereco.Cep = Console.ReadLine();

            Console.WriteLine("Digite o complemento:");
            endereco.Complemento = Console.ReadLine();

            novoCliente.Endereco = endereco;

            _clienteDao.AdicionarCliente(novoCliente);

        }

        public static void AtualizarCliente()
        {
            Console.WriteLine("--                   ATUALIZAR DE CLIENTE                -- ");

            Console.WriteLine("Digite o CPF do cliente que será editado:");
            _cpfCliente = long.Parse(Console.ReadLine());

            _clienteEncontrado = _clienteDao.BuscarPorCpf(_cpfCliente);

            if (_clienteEncontrado.CPF == 0)
            {
                Console.WriteLine("Cliente não encontrado!");
                Console.ReadKey();
                VoltarMenuCliente();
            }

            Console.WriteLine($" Cliente que será editado:\n {_clienteEncontrado}");

            Console.ReadKey();

            Console.WriteLine("Digite o nome:");
            _clienteEncontrado.Nome = Console.ReadLine();

            Console.WriteLine("Digite a data de nascimento:");
            _clienteEncontrado.DataNascimento = Convert.ToDateTime(Console.ReadLine());

            var endereco = new Endereco();

            Console.WriteLine(" - Cadastro de Endereço -");
            Console.WriteLine("Digite a rua:");
            endereco.Rua = Console.ReadLine();

            Console.WriteLine("Digite o número:");
            endereco.Numero = int.Parse(Console.ReadLine());

            Console.WriteLine("Digite o bairro:");
            endereco.Bairro = Console.ReadLine();

            Console.WriteLine("Digite o cep:");
            endereco.Cep = Console.ReadLine();

            Console.WriteLine("Digite o completo:");
            endereco.Complemento = Console.ReadLine();

            _clienteEncontrado.Endereco = endereco;

            _clienteDao.AtualizarCliente(_clienteEncontrado);

        }

        public static void BuscarTodosClientes()
        {
            Console.WriteLine("--           LISTA CLIENTES         -- \n");
            _listaClientes = _clienteDao.BuscaTodos();

            foreach (var item in _listaClientes)
            {
                Console.WriteLine(item);
                Console.WriteLine("--------------------------------------");
            }

            Console.ReadKey();
        }

        public static void BuscarClientePorCpf()
        {
            Console.WriteLine("--           CLIENTE         -- \n");

            Console.WriteLine("Digite o CPF do cliente que será buscado:");
            _idProduto = Convert.ToInt32(Console.ReadLine());

            _clienteEncontrado = _clienteDao.BuscarPorCpf(_idProduto);
            Console.WriteLine("Cliente encontrado:");
            Console.WriteLine("--------------------------------------");
            if (_clienteEncontrado.CPF != 0)
            {
                Console.WriteLine(_clienteEncontrado);
            }
            Console.ReadKey();
        }

        public static void BuscarClientePorTexto()
        {
            Console.WriteLine("--           CLIENTE PRODUTOS         -- \n");
            Console.WriteLine("Digite o texto do cliente:");
            var texto = Console.ReadLine();
            _listaClientes = _clienteDao.BuscaPorTexto(texto);

            Console.WriteLine("Clientes encontrados:");
            Console.WriteLine("--------------------------------------");
            foreach (var item in _listaClientes)
            {
                Console.WriteLine(item);
                Console.WriteLine("--------------------------------------");
            }
            Console.ReadKey();
        }

        public static void DeletarCliente()
        {
            Console.Clear();
            Console.WriteLine(" --          EDITAR CLIENTE         -- \n");

            Console.WriteLine("Digite o cpf do cliente que será editado:");
            _cpfCliente = Convert.ToInt32(Console.ReadLine());

            _clienteEncontrado = _clienteDao.BuscarPorCpf(_cpfCliente);

            if (_clienteEncontrado.CPF == 0)
            {
                Console.WriteLine("Cliente não encontrado!");
                Console.ReadKey();
                VoltarMenuProduto();
            }

            Console.WriteLine($" Cliente que será editado:\n {_clienteEncontrado}");

            Console.ReadKey();

            Console.WriteLine("Digite o nome:");
            _clienteEncontrado.Nome = Console.ReadLine();

            Console.WriteLine("Digite a data de nascimento:");
            _clienteEncontrado.DataNascimento = Convert.ToDateTime(Console.ReadLine());

            var endereco = new Endereco();

            Console.WriteLine(" - Cadastro de Endereço -");
            Console.WriteLine("Digite a rua:");
            endereco.Rua = Console.ReadLine();

            Console.WriteLine("Digite o número:");
            endereco.Numero = int.Parse(Console.ReadLine());

            Console.WriteLine("Digite o bairro:");
            endereco.Bairro = Console.ReadLine();

            Console.WriteLine("Digite o cep:");
            endereco.Cep = Console.ReadLine();

            Console.WriteLine("Digite o completo:");
            endereco.Complemento = Console.ReadLine();

            _clienteEncontrado.Endereco = endereco;

            _produtoDao.AtualizarProduto(_produtoEncontrado);
        }
        //TELA CLIENTE
    }
}
