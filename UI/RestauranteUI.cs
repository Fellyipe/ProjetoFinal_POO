using GerenciamentoPedidosComida.Interfaces;
using GerenciamentoPedidosComida.Models;
using GerenciamentoPedidosComida.Repositories;
using GerenciamentoPedidosComida.Services;

namespace GerenciamentoPedidosComida.UI
{
    public class RestauranteUI
    {
        private IRepository<Restaurante> _restauranteRepository;
        private Verificacao _verificacao;

        public RestauranteUI()
        {
            _restauranteRepository = new Repository<Restaurante>();
            _verificacao = new Verificacao();
        }

        public void CreateRestaurante()
        {
            Console.WriteLine("Informe os dados:");

            Console.Write("Nome: ");
            string nome = Console.ReadLine();
            nome = _verificacao.VerificarNulidade(nome);

            Console.Write("Endereço: ");
            string endereco = Console.ReadLine();
            endereco = _verificacao.VerificarNulidade(endereco);

            Console.Write("Número de Telefone: ");
            string numeroTelefone = Console.ReadLine();
            numeroTelefone = _verificacao.VerificarNulidade(numeroTelefone);

            Restaurante restaurante = new Restaurante
            {
                Nome = nome,
                Endereco = endereco,
                NumeroTelefone = numeroTelefone
            };

            _restauranteRepository.Create(restaurante);
        }

        public Restaurante GetRestauranteById(int restauranteId)
        {
            Restaurante? restaurante = _restauranteRepository.GetById(restauranteId);
            if (restaurante != null)
            {
                return restaurante;
            }
            else
            {
                Console.WriteLine("Não há nenhum restaurante com esse Id");
                return null;
            }
        }

        public void UpdateRestaurante(Restaurante restaurante)
        {
            Console.WriteLine("Informe os dados:");

            Console.Write("Nome: ");
            string nome = Console.ReadLine();
            nome = _verificacao.VerificarNulidade(nome);

            Console.Write("Endereço: ");
            string endereco = Console.ReadLine();
            endereco = _verificacao.VerificarNulidade(endereco);

            Console.Write("Número de Telefone: ");
            string numeroTelefone = Console.ReadLine();
            numeroTelefone = _verificacao.VerificarNulidade(numeroTelefone);


            restaurante.Nome = nome;
            restaurante.Endereco = endereco;
            restaurante.NumeroTelefone = numeroTelefone;

            _restauranteRepository.Update(restaurante);
        }

        public void DeleteRestaurante(int restauranteId)
        {
            // Lógica de negócio para exclusão de usuário
            // ...

            _restauranteRepository.Delete(restauranteId);
        }

        public void ListAllRestaurantes()
        {
            IEnumerable<Restaurante> listaRestaurantes = _restauranteRepository.GetAll();
            if(listaRestaurantes.Count() == 0)
            {
                Console.WriteLine("Não há nenhum restaurante cadastrado.");
            }
            foreach (var item in listaRestaurantes)
            {
                Console.WriteLine(item + "\r\n");
            }
        }
    }
}