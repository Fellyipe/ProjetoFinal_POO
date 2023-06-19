using GerenciamentoPedidosComida.Interfaces;
using GerenciamentoPedidosComida.Models;
using GerenciamentoPedidosComida.Repositories;

namespace GerenciamentoPedidosComida.UI
{
    public class PedidoUI
    {
        private IRepository<Pedido> _pedidoRepository;

        public PedidoUI()
        {
            _pedidoRepository = new Repository<Pedido>();
        }

        public void CreatePedido()
        {
            Console.WriteLine("Informe os dados do pedido:");
            /*var pedido;
            _pedidoRepository.Create(pedido);*/
        }

        public void GetPedidoById(int pedidoId)
        {
            Pedido? pedido = _pedidoRepository.GetById(pedidoId);
            if (pedido != null)
            {
                Console.WriteLine(pedido);
            }
            else
            {
                Console.WriteLine("Não há nenhum pedido com esse Id");
            }
        }

        public void UpdatePedido(Pedido pedido)
        {
            // Lógica de negócio para atualização de usuário
            // ...

            _pedidoRepository.Update(pedido);
        }

        public void DeletePedido(int pedidoId)
        {
            // Lógica de negócio para exclusão de usuário
            // ...

            _pedidoRepository.Delete(pedidoId);
        }
    }
}