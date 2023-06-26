using GerenciamentoPedidosComida.Interfaces;
using GerenciamentoPedidosComida.Models;
using GerenciamentoPedidosComida.Repositories;
using GerenciamentoPedidosComida.Services;
using System.Net.Mail;

namespace GerenciamentoPedidosComida.UI
{
    public class ClienteUI
    {
        private IRepository<Cliente> _clienteRepository;
        private Verificacao _verificacao;

        public ClienteUI()
        {
            _clienteRepository = new Repository<Cliente>();
            _verificacao = new Verificacao();
            
        }

        public void CreateCliente()
        {
            Console.WriteLine("Informe os dados:");

            Console.Write("Nome: ");
            string nome = Console.ReadLine();
            nome = _verificacao.VerificarNulidade(nome);

            Console.Write("Endereço: ");
            string endereco = Console.ReadLine();
            endereco = _verificacao.VerificarNulidade(endereco);

            Console.Write("Email: ");
            string email = Console.ReadLine();
            email = _verificacao.VerificarNulidade(email);

            while(!ValidarEmail(email))
            {
                Console.WriteLine("Email inválido, utilize o formato correto");
                Console.Write("Email: ");
                email = _verificacao.VerificarNulidade(Console.ReadLine());
            }
            while(IsEmailAlreadyTaken(email))
            {
                Console.WriteLine("Email já utilizado, use outro");
                Console.Write("Email: ");
                email = _verificacao.VerificarNulidade(Console.ReadLine());
            }

            Console.Write("Senha: ");
            string senha = Console.ReadLine();
            senha = _verificacao.VerificarNulidade(senha);

            Console.Write("Número de Telefone: ");
            string numeroTelefone = Console.ReadLine();
            numeroTelefone = _verificacao.VerificarNulidade(numeroTelefone);

            Cliente cliente = new Cliente
            {
                Nome = nome,
                Endereco = endereco,
                Email = email,
                Senha = senha,
                NumeroTelefone = numeroTelefone
            };

            _clienteRepository.Create(cliente);
        }

        public Cliente GetClienteById(int clienteId)
        {
            Cliente? cliente = _clienteRepository.GetById(clienteId);
            if (cliente != null)
            {
                return cliente;
            }
            else
            {
                Console.WriteLine("Não há nenhum cliente com esse Id");
                return null;
            }
        }

        public void UpdateCliente(Cliente cliente)
        {
            Console.WriteLine("Informe os dados:");

            Console.Write("Nome: ");
            string nome = Console.ReadLine();
            nome = _verificacao.VerificarNulidade(nome);

            Console.Write("Endereço: ");
            string endereco = Console.ReadLine();
            endereco = _verificacao.VerificarNulidade(endereco);

            Console.Write("Email: ");
            string email = Console.ReadLine();
            email = _verificacao.VerificarNulidade(email);

            while(!ValidarEmail(email))
            {
                Console.WriteLine("Email inválido, utilize o formato correto");
                Console.Write("Email: ");
                email = _verificacao.VerificarNulidade(Console.ReadLine());
            }
            while(IsEmailAlreadyTaken(email))
            {
                Console.WriteLine("Email já utilizado, use outro");
                Console.Write("Email: ");
                email = _verificacao.VerificarNulidade(Console.ReadLine());
            }

            Console.Write("Senha: ");
            string senha = Console.ReadLine();
            senha = _verificacao.VerificarNulidade(senha);

            Console.Write("Número de Telefone: ");
            string numeroTelefone = Console.ReadLine();
            numeroTelefone = _verificacao.VerificarNulidade(numeroTelefone);

            cliente.Nome = nome;
            cliente.Endereco = endereco;
            cliente.Email = email;
            cliente.Senha = senha;
            cliente.NumeroTelefone = numeroTelefone;

            _clienteRepository.Update(cliente);
        }

        public void DeleteCliente(int clienteId)
        {
            // Lógica de negócio para exclusão de usuário
            // ...

            _clienteRepository.Delete(clienteId);
        }

        private bool IsEmailAlreadyTaken(string email)
        {
            
            List<Cliente> lista = _clienteRepository.GetAll();
            foreach (var item in lista)
            {
                if (item.Email == email)
                {
                    return true;
                }
            }
            return false;   
        }

        public void ListAllClientes()
        {
            IEnumerable<Cliente> listaClientes = _clienteRepository.GetAll();
            if(listaClientes.Count() == 0)
            {
                Console.WriteLine("Não há nenhum cliente cadastrado.");
            }
            foreach (var item in listaClientes)
            {
                Console.WriteLine(item + "\r\n");
            }
        }
        public bool ValidarEmail(string email)
        {
            try
            {
                MailAddress endereco = new MailAddress(email);
                return true;
            }
            catch (FormatException)
            {
                return false;
            }
        }
    }
}