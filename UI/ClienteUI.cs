using GerenciamentoPedidosComida.Interfaces;
using GerenciamentoPedidosComida.Models;
using GerenciamentoPedidosComida.Repositories;

namespace GerenciamentoPedidosComida.UI
{
    public class ClienteUI
    {
        private IRepository<Cliente> _clienteRepository;

        public ClienteUI()
        {
            _clienteRepository = new Repository<Cliente>();
            
        }

        public void CreateCliente()
        {
            Console.WriteLine("Informe os dados do cliente:");

            Console.Write("Nome: ");
            string nome = Console.ReadLine();

            Console.Write("Endereço: ");
            string endereco = Console.ReadLine();

            Console.Write("Email: ");
            string email = Console.ReadLine();
            while(IsEmailAlreadyTaken(email))
            {
                Console.WriteLine("Email já utilizado, use outro");
                Console.Write("Email: ");
                email = Console.ReadLine();
            }

            Console.Write("Senha: ");
            string senha = Console.ReadLine();

            Console.Write("Número de Telefone: ");
            string numeroTelefone = Console.ReadLine();


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

        public void GetClienteById(int clienteId)
        {
            Cliente? cliente = _clienteRepository.GetById(clienteId);
            if (cliente != null)
            {
                Console.WriteLine(cliente);
            }
            else
            {
                Console.WriteLine("Não há nenhum cliente com esse Id");
            }
        }

        public void UpdateCliente(Cliente cliente)
        {
            // Lógica de negócio para atualização de usuário
            // ...

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

        public bool Login(string email, string senha)
        {
            
            List<Cliente> lista = _clienteRepository.GetAll();
            foreach (var item in lista)
            {
                if (item.Email == email)
                {
                    if (item.Senha == senha)
                    {
                        Console.WriteLine("Login realizado com sucesso!");
                        return true;
                    }    
                    break;
                }
            }
            Console.WriteLine("Usuário ou senha inválidos.");
            return false;
        }
    }
}