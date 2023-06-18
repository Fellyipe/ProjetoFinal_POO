

namespace GerenciamentoPedidosComida.Models
{
    public class Avaliacao
    {
        public int Id { get; set; }
        public string Comentario { get; set; }
        public int Classificacao { get; set; }
        public int ClienteId { get; set; }
        public int RestauranteId { get; set; }
        public int PedidoId { get; set; }
    }
}