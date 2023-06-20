using GerenciamentoPedidosComida.Interfaces;
using GerenciamentoPedidosComida.Models;
using GerenciamentoPedidosComida.Repositories;

namespace GerenciamentoPedidosComida.UI
{
    public class RestauranteUI
    {
        private IRepository<Restaurante> _restauranteRepository;

        public RestauranteUI()
        {
            _restauranteRepository = new Repository<Restaurante>();
        }

        public void CreateRestaurante()
        {
            Console.WriteLine("Informe os dados do restaurante:");
            /*var restaurante;
            _restauranteRepository.Create(restaurante);*/
        }

        public void GetRestauranteById(int restauranteId)
        {
            Restaurante? restaurante = _restauranteRepository.GetById(restauranteId);
            if (restaurante != null)
            {
                Console.WriteLine(restaurante);
            }
            else
            {
                Console.WriteLine("Não há nenhum restaurante com esse Id");
            }
        }

        public void UpdateRestaurante(Restaurante restaurante)
        {
            // Lógica de negócio para atualização de usuário
            // ...

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
            foreach (var item in listaRestaurantes)
            {
                Console.WriteLine(item);
            }
        }
    }
}