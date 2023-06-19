


namespace GerenciamentoPedidosComida.Models
{
    public class Pedido
    {
        private int _id;
        private DateTime _dataPedido;
        private string _status = "";
        private decimal _total;
        private int _clienteId;
        private int _restauranteId;
        public int Id {
            get { return _id; } 
            set { _id = value; } 
        }
        public DateTime DataPedido  {
            get { return _dataPedido; } 
            set { _dataPedido = value; } 
        }
        public string Status {
            get { return _status; } 
            set
            {
                if (value != null)
                {
                    _status = value;
                }
                else
                {
                    throw new ArgumentNullException(nameof(Status), "O campo Status não pode ser nulo.");
                }
            }
        }
        public decimal Total {
            get { return _total; } 
            set { _total = value; } 
        }
        public int ClienteId {
            get { return _clienteId; } 
            set { _clienteId = value; } 
        }
        public int RestauranteId {
            get { return _restauranteId; } 
            set { _restauranteId = value; } 
        }
    }
}