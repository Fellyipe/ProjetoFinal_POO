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
        public bool Login(string email, string senha)
        {    
            var usuario = _dbContext.Clientes.FirstOrDefault(u => u.Email == email && u.Senha == senha);

            return usuario != null;
        }

        public async Task<int> GetLastPedidoIdAsync()
        {
            var lastUser = await _dbContext.Pedidos.OrderByDescending(u => u.Id).FirstOrDefaultAsync();

            if (lastUser != null)
            {
                return lastUser.Id;
            }

            return 0; // Retorna 0 se nenhum usuário for encontrado na tabela
        }

        public Task<List<Prato>> GetAllPratosByRestauranteId(int restauranteId)
        {
            return _dbContext.Pratos.Where(p => p.RestauranteId == restauranteId).ToListAsync();
        }

        
        
        /*public List<Pedido> GetPedidosByStatus(string status)
        {

        }
        */
    }
}