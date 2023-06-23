namespace GerenciamentoPedidosComida.Models
{
    public abstract class Entidade
    {
        private int _id;
        public int Id {
            get { return _id; } 
            set { _id = value; } 
        }
    }
}