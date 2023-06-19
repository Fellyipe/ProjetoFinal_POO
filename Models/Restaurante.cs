
namespace GerenciamentoPedidosComida.Models
{
    public class Restaurante
    {
        public int _id;
        public string _nome = "";
        public string _endereco = "";
        public string _numeroTelefone = "";
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
        public override string ToString()
        {
            return $"Restaurante ID: {Id}\n" +
                $"Nome: {Nome}\n" +
                $"Endereço: {Endereco}\n" +
                $"Número de Telefone: {NumeroTelefone}";
        }
    }
}