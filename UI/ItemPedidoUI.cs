using GerenciamentoPedidosComida.Interfaces;
using GerenciamentoPedidosComida.Models;
using GerenciamentoPedidosComida.Repositories;
using GerenciamentoPedidosComida.Services;

namespace GerenciamentoPedidosComida.UI
{
    public class ItemPedidoUI
    {
        private IRepository<ItemPedido> _itemPedidoRepository;
        private Uteis _uteis;

        public ItemPedidoUI()
        {
            _itemPedidoRepository = new Repository<ItemPedido>();
        }

        public void CreateItemPedido(ItemPedido itemPedido)
        {
            _itemPedidoRepository.Create(itemPedido);
        }

        public ItemPedido GetItemPedidoById(int pedidoId, int pratoId)
        {
            ItemPedido? itemPedido = _uteis.GetItemPedidoByPedidoIdAndPratoId(pedidoId, pratoId);
            if (itemPedido != null)
            {
                return itemPedido;
            }
            else
            {
                Console.WriteLine("Não há nenhum itemPedido com esse Id");
                return null;
            }
        }

        public void UpdateItemPedido(ItemPedido itemPedido)
        {
            // Lógica de negócio para atualização de usuário
            // ...

            _itemPedidoRepository.Update(itemPedido);
        }

        public void DeleteItemPedido(int itemPedidoId)
        {
            // Lógica de negócio para exclusão de usuário
            // ...

            _itemPedidoRepository.Delete(itemPedidoId);
        }

        public void ListAllItemPedidos()
        {
            IEnumerable<ItemPedido> listaItemPedidos = _itemPedidoRepository.GetAll();
            if(listaItemPedidos.Count() == 0)
            {
                Console.WriteLine("Não há nenhum ItemPedido cadastrado.");
            }
            foreach (var item in listaItemPedidos)
            {
                Console.WriteLine(item + "\r\n");
            }
        }
    }
}