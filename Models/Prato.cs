
namespace GerenciamentoPedidosComida.Models
{
    public class Prato
    {
        public int _id;
        public string _nomeItem = "";
        public string _descricao = "";
        public decimal _preco;
        public int _restauranteId;         
        public int Id {
            get { return _id; } 
            set { _id = value; } 
        }
        public string NomeItem {
            get { return _nomeItem; } 
            set
            {
                if (value != null)
                {
                    _nomeItem = value;
                }
                else
                {
                    throw new ArgumentNullException(nameof(NomeItem), "O campo NomeItem não pode ser nulo.");
                }
            }
        }
        public string Descricao {
            get { return _descricao; } 
            set
            {
                if (value != null)
                {
                    _descricao = value;
                }
                else
                {
                    throw new ArgumentNullException(nameof(Descricao), "O campo Descricao não pode ser nulo.");
                }
            }
        }
        public decimal Preco {
            get { return _preco; } 
            set { _preco = value; } 
        }
        public int RestauranteId {
            get { return _restauranteId; } 
            set { _restauranteId = value; } 
        }
        public override string ToString()
        {
            return $"Prato ID: {Id}\n" +
                $"Nome do Item: {NomeItem}\n" +
                $"Descrição: {Descricao}\n" +
                $"Preço: {Preco}\n" +
                $"ID do Restaurante: {RestauranteId}";
        }

    }
}