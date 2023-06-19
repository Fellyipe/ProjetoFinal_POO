using GerenciamentoPedidosComida.Models;
using Microsoft.EntityFrameworkCore;

namespace GerenciamentoPedidosComida.Migrations
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<Avaliacao>? Avaliacaos { get; set; }
        public DbSet<Cliente>? Clientes { get; set; }
        public DbSet<ItemPedido>? ItemPedidos { get; set; }
        public DbSet<Pedido>? Pedidos { get; set; }
        public DbSet<Prato>? Pratos { get; set; }
        public DbSet<Restaurante>? Restaurantes { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
            {
                modelBuilder.Entity<ItemPedido>().HasKey(ip => new { ip.PedidoId, ip.PratoId });
                modelBuilder.Entity<Avaliacao>().ToTable("Avaliacao");
                modelBuilder.Entity<Cliente>().ToTable("Cliente");
                modelBuilder.Entity<ItemPedido>().ToTable("ItemPedido");
                modelBuilder.Entity<Pedido>().ToTable("Pedido");
                modelBuilder.Entity<Prato>().ToTable("Prato");
                modelBuilder.Entity<Restaurante>().ToTable("Restaurante");
                
                modelBuilder.Entity<Avaliacao>().Property(c => c.Comentario).IsRequired(false); // Permite valores nulos
            }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySQL("Server=localhost; Database=gerenciamentopedidoscomida; User id=root; Password=");
        }
    }
}