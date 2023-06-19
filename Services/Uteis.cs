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
            //var usuario = _dbContext.Clientes.FirstOrDefault(u => u.Email == email && u.Senha == senha);
            //var usuarios = _dbContext.Clientes.Find(1);
            var usuario = _dbContext.Clientes.FirstOrDefault(u => u.Email == email && u.Senha == senha);

            return usuario != null;
            //return 0;
            /*
            List<Cliente> lista = _clienteRepository.GetAll();
            foreach (var item in lista)
            {
                if (item.Email == email)
                {
                    if (item.Senha == senha)
                    {
                        Console.WriteLine("Login realizado com sucesso!");
                        return true;
                    }    
                    break;
                }
            }
            Console.WriteLine("Usuário ou senha inválidos.");
            return false;
            */
        }
        
        /*public List<Pedido> GetPedidosByStatus(string status)
        {

        }
        */
    }
}