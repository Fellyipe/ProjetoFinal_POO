
namespace GerenciamentoPedidosComida.Models
{
    public class Cliente
    {   
        private int _id;
        private string _nome = "";
        private string _endereco = "";
        private string _email = "";
        private string _senha = "";
        private string _numeroTelefone = "";
        public int Id {
            get { return _id; } 
            set { _id = value; } 
        }
        public string Nome {
            get { return _nome; } 
            set
            {
                if (value != null)
                {
                    _nome = value;
                }
                else
                {
                    throw new ArgumentNullException(nameof(Nome), "O campo Nome não pode ser nulo.");
                }
            }
        }
        public string Endereco {
            get { return _endereco; } 
            set
            {
                if (value != null)
                {
                    _endereco = value;
                }
                else
                {
                    throw new ArgumentNullException(nameof(Endereco), "O campo Endereco não pode ser nulo.");
                }
            } 
        }
        public string Email {
            get { return _email; } 
            set
            {
                if (value != null)
                {
                    _email = value;
                }
                else
                {
                    throw new ArgumentNullException(nameof(Email), "O campo Email não pode ser nulo.");
                }
            } 
        }
        public string Senha {
            get { return _senha; } 
            set
            {
                if (value != null)
                {
                    _senha = value;
                }
                else
                {
                    throw new ArgumentNullException(nameof(Senha), "O campo Senha não pode ser nulo.");
                }
            }
        }
        public string NumeroTelefone {
            get { return _numeroTelefone; } 
            set
            {
                if (value != null)
                {
                    _numeroTelefone = value;
                }
                else
                {
                    throw new ArgumentNullException(nameof(NumeroTelefone), "O campo NumeroTelefone não pode ser nulo.");
                }
            }
        }
    }
}