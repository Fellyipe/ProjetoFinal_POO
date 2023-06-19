// See https://aka.ms/new-console-template for more information

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using MySql.Data;
using MySql.Data.MySqlClient;
using GerenciamentoPedidosComida.Repositories;
using GerenciamentoPedidosComida.UI;
using GerenciamentoPedidosComida.Models;
using GerenciamentoPedidosComida.Interfaces;
using GerenciamentoPedidosComida.Services;

namespace GerenciamentoPedidosComida
{
    class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");

            string connectionString = "server=localhost;database=gerenciamentopedidoscomida;user=root;password=;";
            
            MySqlConnection connection = new MySqlConnection(connectionString);

            try
            {
                connection.Open();
                Console.WriteLine("Conexão com o banco de dados estabelecida com sucesso.");

                string query = "SELECT SYSDATE() AS SYSDATE";
                MySqlCommand comando = new MySqlCommand(query, connection);

                using (MySqlDataReader reader = comando.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        DateTime sysDate = reader.GetDateTime("SYSDATE");
                        Console.WriteLine(sysDate);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Erro ao conectar ao banco de dados: " + ex.Message);
            }

            IRepository<Cliente> clienteRepository = new Repository<Cliente>();

            // Criando uma instância do serviço de usuário
            ClienteUI clienteUI = new ClienteUI();
            Cliente novoCliente = new Cliente
            {
                Nome = "Jorge",
                Endereco = "Avenida Brasília, 123, Vila A, Foz do Iguaçu",
                Email = "jorge11@mail.com",
                Senha = "4321",
                NumeroTelefone = "(48)97894-1212"
            };

            // Chamando o método para criar o usuário
            var email = Console.ReadLine();
            var senha = Console.ReadLine();
            Menu menu = new Menu();
            //menu.RealizarLogin();
            var _uteis = new Uteis();
            menu.RealizarLogin();
        }
    }
}