using GerenciamentoPedidosComida.Interfaces;
using GerenciamentoPedidosComida.Models;

namespace GerenciamentoPedidosComida.UI
{
    public class ClienteUI
    {
        private IRepository<Cliente> _clienteRepository;

        public ClienteUI(IRepository<Cliente> clienteRepository)
        {
            _clienteRepository = clienteRepository;
        }

        public void CreateCliente(Cliente cliente)
        {
            // Lógica de negócio para criação de usuário
            // ...

            _clienteRepository.Create(cliente);
        }

        public Cliente GetClienteById(int clienteId)
        {
            return _clienteRepository.GetById(clienteId);
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
    }
}