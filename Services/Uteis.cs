using Microsoft.EntityFrameworkCore;
using GerenciamentoPedidosComida.Models;
using GerenciamentoPedidosComida.Migrations;
using GerenciamentoPedidosComida.Repositories;
using Microsoft.EntityFrameworkCore;

namespace GerenciamentoPedidosComida.Services
{
    public class Uteis
    {
        private ApplicationDbContext _dbContext = new ApplicationDbContext();
        // private DbSet<T> _dbSet;
        
        public Uteis(/*ApplicationDbContext dbContext*/)
        {
            // _dbContext = dbContext;
            // _dbSet = _dbContext.Set<T>();
        }
        public Cliente Login(string email, string senha)
        {    
            var cliente = _dbContext.Clientes.FirstOrDefault(u => u.Email == email && u.Senha == senha);

            return cliente;
        }

        public Pedido GetLastPedido()
        {
            var lastUser = _dbContext.Pedidos.OrderByDescending(u => u.Id).FirstOrDefault();

            if (lastUser != null)
            {
                return lastUser;
            }

            return null; // Retorna 0 se nenhum usuário for encontrado na tabela
        }

        public List<Prato> GetAllPratosByRestauranteId(int restauranteId)
        {
            return _dbContext.Pratos.Where(p => p.RestauranteId == restauranteId).ToList();
        }

        public List<Pedido> GetAllPedidosByStatus(string status)
        {
            return _dbContext.Pedidos.Where(p => p.Status == status).ToList();
        }

        public ItemPedido GetItemPedidoByPedidoIdAndPratoId(int pedidoId, int pratoId)
        {
            return _dbContext.ItemPedidos.FirstOrDefault(i => i.PedidoId == pedidoId && i.PratoId == pratoId);
        }

        public void UpdateQuantidadeInItemPedido(int pedidoId, int pratoId, int quantidade)
        {
            var itemPedido = _dbContext.ItemPedidos.FirstOrDefault(p => p.PedidoId == pedidoId && p.PratoId == pratoId);
            // Modificar os valores das colunas relevantes
            itemPedido.Quantidade = quantidade;

            // Executar o update no banco de dados
            _dbContext.SaveChanges();
        
        }


        


        
        
        /*public List<Pedido> GetPedidosByStatus(string status)
        {

        }
        */
    }
}