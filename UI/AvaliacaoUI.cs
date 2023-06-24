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

        public void CreateAvaliacao(Pedido pedido)
        {
            Console.WriteLine("Avalie o seu pedido (1 a 5):");
            int classificacao = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Faça um comentário (opcional)");
            string comentario = Console.ReadLine(); 
            //while ()
            Avaliacao avaliacao = new Avaliacao
            {
                Comentario = comentario,
                Classificacao = classificacao,
                ClienteId = pedido.ClienteId,
                RestauranteId = pedido.RestauranteId,
                PedidoId = pedido.Id
            };
            _avaliacaoRepository.Create(avaliacao);
        }

        public Avaliacao GetAvaliacaoById(int avaliacaoId)
        {
            Avaliacao? avaliacao = _avaliacaoRepository.GetById(avaliacaoId);
            if (avaliacao != null)
            {
                return avaliacao;
            }
            else
            {
                Console.WriteLine("Não há nenhum avaliacao com esse Id");
                return null;
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

        public void ListAllAvaliacaos()
        {
            IEnumerable<Avaliacao> listaAvaliacaos = _avaliacaoRepository.GetAll();
            if(listaAvaliacaos.Count() == 0)
            {
                Console.WriteLine("Não há nenhum restaurante cadastrado.");
            }
            foreach (var item in listaAvaliacaos)
            {
                Console.WriteLine(item + "\r\n");
            }
        }
    }
}