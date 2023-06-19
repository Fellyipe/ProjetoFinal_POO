

namespace GerenciamentoPedidosComida.Models
{
    public class Avaliacao
    {
        private int _id;
        private string? _comentario;
        private int _classificacao;
        private int _clienteId;
        private int _restauranteId;
        private int _pedidoId;
        public int Id {
            get { return _id; } 
            set { _id = value; } 
        }
        public string? Comentario {
            get { return _comentario; } 
            set { _comentario = value; } 
        }
        public int Classificacao {
            get { return _classificacao; } 
            set { _classificacao = value; } 
        }
        public int ClienteId {
            get { return _clienteId; } 
            set { _clienteId = value; } 
        }
        public int RestauranteId {
            get { return _restauranteId; } 
            set { _restauranteId = value; } 
        }
        public int PedidoId {
            get { return _pedidoId; } 
            set { _pedidoId = value; } 
        }
        public override string ToString()
        {
            return $"Avaliação ID: {Id}\n" +
                $"Comentário: {Comentario}\n" +
                $"Classificação: {Classificacao}\n" +
                $"ID do Cliente: {ClienteId}\n" +
                $"ID do Restaurante: {RestauranteId}\n" +
                $"ID do Pedido: {PedidoId}";
        }
    }
}