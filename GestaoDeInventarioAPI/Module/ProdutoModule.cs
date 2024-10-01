using Carter;
using GestaoDeInventarioAPI.Context;
using GestaoDeInventarioAPI.Dto;
using Microsoft.EntityFrameworkCore;

namespace GestaoDeInventarioAPI.Module
{
    public class ProdutoModule : ICarterModule
    {
        public void AddRoutes(IEndpointRouteBuilder app)
        {
            app.MapGet("/produtos", async (InventarioContext db) =>
                await db.Produtos.ToListAsync());

            app.MapGet("/produtos/{id}", async (InventarioContext db, int id) =>
            {
                var produto = await db.Produtos.FindAsync(id);
                
                if(produto == null)
                {
                    return Results.NotFound(new { message = "Produto não encontrado." });
                }

                return produto == null ? Results.NotFound() : Results.Ok(produto);


            });

            app.MapPost("/produtos", async (InventarioContext db, ProdutoUpdate newProduct) =>
            {
                var produto = new ProdutoEntity
                {
                    Nome = newProduct.Nome,
                    Descricao = newProduct.Descricao,
                    Preco = newProduct.Preco,
                    QuantidadeEstoque = newProduct.QuantidadeEstoque,
                    Ativo = newProduct.Ativo
                };

                db.Produtos.Add(produto);
                await db.SaveChangesAsync();

                return Results.Created($"/produtos/{produto.Id}", produto);
            });

            app.MapPut("/produtos/{id}", async (InventarioContext db, int id, ProdutoUpdate updatedProduto) =>
            {
                var produto = await db.Produtos.FindAsync(id);

                if (produto == null)
                {
                    return Results.NotFound();
                }

                produto.Nome = updatedProduto.Nome;
                produto.Descricao = updatedProduto.Descricao;
                produto.Preco = updatedProduto.Preco;
                produto.QuantidadeEstoque = updatedProduto.QuantidadeEstoque;
                produto.Ativo = updatedProduto.Ativo;

                await db.SaveChangesAsync();

                return Results.Ok(produto);
            });

            app.MapDelete("/produtos/{id}", async (InventarioContext db, int id) =>
            {
                var produto = await db.Produtos.FindAsync(id);

                if (produto == null)
                {
                    return Results.NotFound(new { message = "Produto não encontrado." });
                }

                db.Produtos.Remove(produto);
                await db.SaveChangesAsync();

                return Results.Ok(new { message = "Produto apagada" });

            });
        }
    }
}
