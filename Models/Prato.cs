
namespace GerenciamentoPedidosComida.Models
{
    public class Prato
    {
        public int _id;
        public string _nomeItem;
        public string _descricao;
        public decimal _preco;
        public int _restauranteId;         
        public int Id {
            get { return _id; } 
            set { _id = value; } 
        }
        public string NomeItem {
            get { return _nomeItem; } 
            set { _nomeItem = value; } 
        }
        public string Descricao {
            get { return _descricao; } 
            set { _descricao = value; } 
        }
        public decimal Preco {
            get { return _preco; } 
            set { _preco = value; } 
        }
        public int RestauranteId {
            get { return _restauranteId; } 
            set { _restauranteId = value; } 
        }
    }
}