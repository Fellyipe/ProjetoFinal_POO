using GerenciamentoPedidosComida.Interfaces;
using GerenciamentoPedidosComida.Models;
using GerenciamentoPedidosComida.Repositories;
using GerenciamentoPedidosComida.Services;

namespace GerenciamentoPedidosComida.UI
{
    public class PratoUI
    {
        private IRepository<Prato> _pratoRepository;
        private Verificacao _verificacao;

        public PratoUI()
        {
            _pratoRepository = new Repository<Prato>();
        }

        public void CreatePrato()
        {
            Console.WriteLine("Informe os dados:");

            Console.Write("Nome do prato: ");
            string nomeItem = Console.ReadLine();
            nomeItem = _verificacao.VeriicarNulidade(nomeItem);

            Console.Write("Descrição: ");
            string descricao = Console.ReadLine();
            descricao = _verificacao.VeriicarNulidade(descricao);

            Console.Write("Preço: ");
            decimal preco = Convert.ToDecimal(Console.ReadLine());

            Console.Write("Id do restaurante: ");
            int restauranteId = _verificacao.VerificarNumero(Console.ReadLine());

            Prato prato = new Prato
            {
                NomeItem = nomeItem,
                Descricao = descricao,
                Preco = preco,
                RestauranteId = restauranteId
            };

            _pratoRepository.Create(prato);
        }

        public Prato GetPratoById(int pratoId)
        {
            Prato? prato = _pratoRepository.GetById(pratoId);
            if (prato != null)
            {
                return prato;
            }
            else
            {
                Console.WriteLine("Não há nenhum prato com esse Id");
                return null;
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
            if(listaPratos.Count() == 0)
            {
                Console.WriteLine("Não há nenhum prato cadastrado.");
            }
            foreach (var item in listaPratos)
            {
                Console.WriteLine(item + "\r\n");
            }
        }
    }
}