using GerenciamentoPedidosComida.Interfaces;
using GerenciamentoPedidosComida.Models;
using GerenciamentoPedidosComida.Repositories;
using GerenciamentoPedidosComida.Services;

namespace GerenciamentoPedidosComida.UI
{
    public class PedidoUI
    {
        private IRepository<Pedido> _pedidoRepository;
        private Verificacao _verificacao;

        public PedidoUI()
        {
            _pedidoRepository = new Repository<Pedido>();
            _verificacao = new Verificacao();
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
                return pedido;
            }
            else
            {
                Console.WriteLine("Não há nenhum pedido com esse Id");
                return null;
            }
        }

        public void UpdatePedido(Pedido pedido, int verifica = 0)
        {
            if(verifica == 1)
            {
                Console.WriteLine("Informe os dados");

                Console.Write("Id do restaurante: ");
                int restauranteId = _verificacao.VerificarNumero(Console.ReadLine());

                Console.Write("Total: ");
                decimal preco = _verificacao.VerificarDecimal(Console.ReadLine());
            }

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
            if(listaPedidos.Count() == 0)
            {
                Console.WriteLine("Não há nenhum pedido cadastrado.");
            }
            foreach (var item in listaPedidos)
            {
                Console.WriteLine(item + "\r\n");
            }
        }
    }
}