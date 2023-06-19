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
            ClienteUI clienteUI = new ClienteUI(clienteRepository);
            Cliente novoCliente = new Cliente
            {
                Nome = "André",
                Endereco = "Rua das Pitangueiras, 512, Centro, Guarapuava",
                Email = "andre@gmail.com",
                Senha = "1234",
                NumeroTelefone = "(48)99545-1234"
            };

            // Chamando o método para criar o usuário
            clienteUI.CreateCliente(novoCliente);
3
        }
    }
}
