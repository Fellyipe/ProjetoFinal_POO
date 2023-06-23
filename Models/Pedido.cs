


namespace GerenciamentoPedidosComida.Models
{
    public class Pedido : Entidade
    {
        private DateTime _dataPedido;
        private string _status = "";
        private decimal _total;
        private int _clienteId;
        private int _restauranteId;
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
            set
            {
                if (value >= 0)
                {
                    _total = value;
                }
                else
                {
                    throw new ArgumentNullException(nameof(Total), "O campo Total não pode ser negativo.");
                }
            }  
        }
        public int ClienteId {
            get { return _clienteId; } 
            set { _clienteId = value; } 
        }
        public int RestauranteId {
            get { return _restauranteId; } 
            set { _restauranteId = value; } 
        }
        public override string ToString()
        {
            return $"Pedido ID: {Id}\n" +
                $"Data do Pedido: {DataPedido}\n" +
                $"Status: {Status}\n" +
                $"Total: {Total}\n" +
                $"ID do Cliente: {ClienteId}\n" +
                $"ID do Restaurante: {RestauranteId}";
        }

    }
}