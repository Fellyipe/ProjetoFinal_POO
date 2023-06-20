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

        public void CreatePedido(int clienteId, int restauranteId)
        {
            IRepository<ItemPedido> _itemPedidoRepository = new Repository<ItemPedido>();
            /*var pedido;
            _pedidoRepository.Create(pedido);*/
            // Obter os detalhes do pedido do usuário            
            // Criar o objeto Pedido
            Pedido novoPedido = new Pedido
            {
                DataPedido = DateTime.Now,
                ClienteId = clienteId,
                RestauranteId = restauranteId,
                Status = "Em andamento",
                Total = 0
            };
            
            // Salvar o pedido no banco de dados
            _pedidoRepository.Create(novoPedido);
        }

        public Pedido GetPedidoById(int pedidoId)
        {
            Pedido? pedido = _pedidoRepository.GetById(pedidoId);
            if (pedido != null)
            {
                // Console.WriteLine(pedido);
                return pedido;
            }
            else
            {
                // Console.WriteLine("Não há nenhum pedido com esse Id");
                return null;
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

        public int GetRestauranteIdByPedidoId(int pedidoId)
        {
            return _pedidoRepository.GetById(pedidoId).RestauranteId;
        }

        public void ListAllPedidos()
        {
            IEnumerable<Pedido> listaPedidos = _pedidoRepository.GetAll();
            foreach (var item in listaPedidos)
            {
                Console.WriteLine(item);
            }
        }
    }
}