
namespace GerenciamentoPedidosComida.Models
{
    public class Cliente
    {   
        private int _id;
        private string _nome;
        private string _endereco;
        private string _email;
        private string _senha;
        private string _numeroTelefone;
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
        public string Email {
            get { return _email; } 
            set { _email = value; } 
        }
        public string Senha {
            get { return _senha; } 
            set { _senha = value; } 
        }
        public string NumeroTelefone {
            get { return _numeroTelefone; } 
            set { _numeroTelefone = value; } 
        }
    }
}