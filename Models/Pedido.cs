


namespace GerenciamentoPedidosComida.Models
{
    public class Pedido
    {
        public int Id { get; set; }
        public DateTime DataPedido { get; set; }
        public string Status { get; set; }
        public decimal Total { get; set; }
        public int ClienteId { get; set; }
        public int RestauranteId { get; set; }
    }
}