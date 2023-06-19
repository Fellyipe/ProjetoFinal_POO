using GerenciamentoPedidosComida.Interfaces;
using GerenciamentoPedidosComida.Models;
using GerenciamentoPedidosComida.Repositories;

namespace GerenciamentoPedidosComida.UI
{
    public class AvaliacaoUI
    {
        private IRepository<Avaliacao> _avaliacaoRepository;

        public AvaliacaoUI()
        {
            _avaliacaoRepository = new Repository<Avaliacao>();
        }

        public void CreateAvaliacao()
        {
            Console.WriteLine("Informe os dados do avaliacao:");
            /*var avaliacao;
            _avaliacaoRepository.Create(avaliacao);*/
        }

        public void GetAvaliacaoById(int avaliacaoId)
        {
            Avaliacao? avaliacao = _avaliacaoRepository.GetById(avaliacaoId);
            if (avaliacao != null)
            {
                Console.WriteLine(avaliacao);
            }
            else
            {
                Console.WriteLine("Não há nenhum avaliacao com esse Id");
            }
        }

        public void UpdateAvaliacao(Avaliacao avaliacao)
        {
            // Lógica de negócio para atualização de usuário
            // ...

            _avaliacaoRepository.Update(avaliacao);
        }

        public void DeleteAvaliacao(int avaliacaoId)
        {
            // Lógica de negócio para exclusão de usuário
            // ...

            _avaliacaoRepository.Delete(avaliacaoId);
        }
    }
}