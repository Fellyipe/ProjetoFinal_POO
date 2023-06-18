
namespace GerenciamentoPedidosComida.Models
{
    public class Prato
    {
        public int Id { get; set; }
        public string NomeItem { get; set; }
        public string Descricao { get; set; }
        public decimal Preco { get; set; }
        public int RestauranteId { get; set; }
    }
}