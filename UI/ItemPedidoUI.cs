using GerenciamentoPedidosComida.Interfaces;
using GerenciamentoPedidosComida.Models;
using GerenciamentoPedidosComida.Repositories;

namespace GerenciamentoPedidosComida.UI
{
    public class ItemPedidoUI
    {
        private IRepository<ItemPedido> _itemPedidoRepository;

        public ItemPedidoUI()
        {
            _itemPedidoRepository = new Repository<ItemPedido>();
        }

        public void CreateItemPedido()
        {
            Console.WriteLine("Informe os dados do itemPedido:");
            /*var itemPedido;
            _itemPedidoRepository.Create(itemPedido);*/
        }

        public void GetItemPedidoById(int itemPedidoId)
        {
            ItemPedido? itemPedido = _itemPedidoRepository.GetById(itemPedidoId);
            if (itemPedido != null)
            {
                Console.WriteLine(itemPedido);
            }
            else
            {
                Console.WriteLine("Não há nenhum itemPedido com esse Id");
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
    }
}