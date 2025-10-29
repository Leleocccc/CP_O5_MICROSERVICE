using Microsoft.EntityFrameworkCore;
using cp.Models;

namespace cp.Data
{
    public class EstoqueDbContext : DbContext
    {
        public EstoqueDbContext(DbContextOptions<EstoqueDbContext> options) : base(options) { }

        public DbSet<Produto> Produtos { get; set; }
        public DbSet<MovimentacaoEstoque> Movimentacoes { get; set; }
        public DbSet<AlertaEstoque> Alertas { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Produto>().HasKey(p => p.SKU);
        }
    }
}
