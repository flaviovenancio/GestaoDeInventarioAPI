using GestaoDeInventarioAPI.Dto;
using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography.X509Certificates;

namespace GestaoDeInventarioAPI.Context
{
    public class InventarioContext : DbContext
    {
        public InventarioContext(DbContextOptions<InventarioContext> options) : base(options) { }

        public DbSet<ProdutoEntity> Produtos { get; set; }
        public DbSet<CategoriaEntity> Categorias { get; set; }
        public DbSet<FornecedorEntity> Fornecedores { get; set; }
        public DbSet<EstoqueEntity> Estoques { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Define o relacionamento entre produto e Catregoria
            modelBuilder.Entity<ProdutoEntity>()
                .HasOne(p => p.Categoria)
                .WithMany(c => c.Produtos)
                .HasForeignKey(p => p.CategoriaId);

            //Define o relacionamento entre Produto e Fornecedor
            modelBuilder.Entity<ProdutoEntity>()
                .HasOne(p => p.Fornecedor)
                .WithMany(c => c.Produtos)
                .HasForeignKey(p => p.FornecedorId);

            //Define o relacionamento estoque e produto
            modelBuilder.Entity<EstoqueEntity>()
                .HasOne(e => e.Produto)
                .WithMany(p => p.Estoques)
                .HasForeignKey(e => e.ProdutoId);
        }
    }
}
