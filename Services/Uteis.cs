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

        public List<Pedido> GetAllPedidosEntregues()
        {
            return _dbContext.Pedidos.Where(p => p.Status == "Entregue").ToList();
        }

        
        
        /*public List<Pedido> GetPedidosByStatus(string status)
        {

        }
        */
    }
}