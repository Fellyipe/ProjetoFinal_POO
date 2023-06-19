
namespace GerenciamentoPedidosComida.Models
{
    public class Restaurante
    {
        public int _id;
        public string _nome;
        public string _endereco;
        public string _numeroTelefone;
        public int Id {
            get { return _id; } 
            set { _id = value; } 
        }
        public string Nome {
            get { return _nome; } 
            set { _nome = value; } 
        }
        public string Endereco {
            get { return _endereco; } 
            set { _endereco = value; } 
        }
        public string NumeroTelefone {
            get { return _numeroTelefone; } 
            set { _numeroTelefone = value; } 
        }
    }
}