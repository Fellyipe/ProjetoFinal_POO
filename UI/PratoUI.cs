using GerenciamentoPedidosComida.Interfaces;
using GerenciamentoPedidosComida.Models;
using GerenciamentoPedidosComida.Repositories;

namespace GerenciamentoPedidosComida.UI
{
    public class PratoUI
    {
        private IRepository<Prato> _pratoRepository;

        public PratoUI()
        {
            _pratoRepository = new Repository<Prato>();
        }

        public void CreatePrato()
        {
            Console.WriteLine("Informe os dados do prato:");
            /*var prato;
            _pratoRepository.Create(prato);*/
        }

        public void GetPratoById(int pratoId)
        {
            Prato? prato = _pratoRepository.GetById(pratoId);
            if (prato != null)
            {
                Console.WriteLine(prato);
            }
            else
            {
                Console.WriteLine("Não há nenhum prato com esse Id");
            }
        }

        public void UpdatePrato(Prato prato)
        {
            // Lógica de negócio para atualização de usuário
            // ...

            _pratoRepository.Update(prato);
        }

        public void DeletePrato(int pratoId)
        {
            // Lógica de negócio para exclusão de usuário
            // ...

            _pratoRepository.Delete(pratoId);
        }

        public void ListAllPratos()
        {
            IEnumerable<Prato> listaPratos = _pratoRepository.GetAll();
            foreach (var item in listaPratos)
            {
                Console.WriteLine(item);
            }
        }
    }
}