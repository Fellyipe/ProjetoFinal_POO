
namespace GerenciamentoPedidosComida.Models
{
    public class ItemPedido
    {
        private int _pratoId;
        private int _quantidade;
        private decimal _precoUnitario;
        private decimal _total;
        private int _pedidoId;
        public int PratoId {
            get { return _pratoId; } 
            set { _pratoId = value; } 
        }
        public int Quantidade {
            get { return _quantidade; } 
            set { _quantidade = value; } 
        }
        public decimal PrecoUnitario {
            get { return _precoUnitario; } 
            set { _precoUnitario = value; } 
        }
        public decimal Total {
            get { return _total; } 
            set { _total = value; } 
        }
        public int PedidoId {
            get { return _pedidoId; } 
            set { _pedidoId = value; } 
        }
        public override string ToString()
        {
            return $"Item do Pedido:\n" +
                $"ID do Pedido: {PedidoId}\n" +
                $"ID do Prato: {PratoId}\n" +
                $"Quantidade: {Quantidade}\n" +
                $"Preço Unitário: {PrecoUnitario}\n" +
                $"Total: {Total}";
        }

    }
}