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
        private Verificacao _verificacao;
        private PratoUI _pratoUI;
        private PedidoUI _pedidoUI;

        public ItemPedidoUI()
        {
            _itemPedidoRepository = new Repository<ItemPedido>();
            _uteis = new Uteis();
            _verificacao = new Verificacao();
            _pedidoUI = new PedidoUI();
            _pratoUI = new PratoUI();
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

            Console.WriteLine("Informe os dados:");

            Console.Write("Quantidade: ");
            int quantidade = _verificacao.VerificarNumero(Console.ReadLine());

            Pedido pedido = _pedidoUI.GetPedidoById(itemPedido.PedidoId);
            Prato prato = _pratoUI.GetPratoById(itemPedido.PratoId);


            _uteis.UpdateItemPedido(itemPedido.PedidoId, itemPedido.PratoId, quantidade, prato.Preco, (quantidade * prato.Preco));

        }

        public void DeleteItemPedido(int pedidoId, int pratoId)
        {
            _uteis.DeleteItemPedido(pedidoId, pratoId);
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