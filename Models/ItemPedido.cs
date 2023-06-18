
namespace GerenciamentoPedidosComida.Models
{
    public class ItemPedido
    {
        public int PedidoId { get; set; }
        public int PratoId { get; set; }
        public int Quantidade { get; set; }
        public decimal PrecoUnitario { get; set; }
        public decimal Total { get; set; }
    }
}