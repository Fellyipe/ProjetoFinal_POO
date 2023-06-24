


namespace GerenciamentoPedidosComida.Services
{
    public class Verificacao
    {
        public string VeriicarNulidade(string entrada)
        {
            while(entrada == "")
            {
                Console.WriteLine("O campo não pode ser nulo!");
                Console.WriteLine("Inisira um dado não nulo");
                entrada = Console.ReadLine();
            }
            return entrada;
        }
    }
}