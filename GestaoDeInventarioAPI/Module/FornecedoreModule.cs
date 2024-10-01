using Carter;
using GestaoDeInventarioAPI.Context;
using GestaoDeInventarioAPI.Dto;
using Microsoft.EntityFrameworkCore;

namespace GestaoDeInventarioAPI.Module
{
    public class FornecedoreModule : ICarterModule
    {
        public void AddRoutes(IEndpointRouteBuilder app)
        {
            app.MapGet("/fornecedor", async (InventarioContext db) =>
                await db.Fornecedores.ToListAsync());

            app.MapGet("/fornecedor/{id}", async (InventarioContext db, int id) =>
            {
                var fornecedor = await db.Fornecedores.FindAsync(id);
                return fornecedor == null ? Results.NotFound() : Results.Ok(fornecedor);
            });

            app.MapPost("/fornecedor", async (InventarioContext db, FornecedorCreate newFornecedor) =>
            {

                var fornecedor = new FornecedorEntity
                {
                    Nome = newFornecedor.Nome,
                    Telefone = newFornecedor.Telefone,
                    Endereco = newFornecedor.Endereco,
                    Ativo = newFornecedor.Ativo,
                };

                db.Fornecedores.Add(fornecedor);
                await db.SaveChangesAsync();

                return Results.Created($"/fornecedor/{fornecedor.Id}", fornecedor);

            });

            app.MapPut("/fornecedor/{id}", async (InventarioContext db, int id, FornecedorCreate updateFornecedor) =>
            {
                var fornecedor = await db.Fornecedores.FindAsync(id);

                if (fornecedor == null)
                {
                    return Results.NotFound();
                }

                fornecedor.Nome = updateFornecedor.Nome;
                fornecedor.Telefone = updateFornecedor.Telefone;
                fornecedor.Endereco = updateFornecedor.Endereco;
                fornecedor.Ativo = updateFornecedor.Ativo;

                await db.SaveChangesAsync();

                return Results.Ok(fornecedor);
            });

            app.MapDelete("/fornecedor/{id}", async (InventarioContext db, int id) =>
            {
                var fornecedor = await db.Fornecedores.FindAsync(id);

                if (fornecedor == null)
                {
                    return Results.NotFound(new { message = "Fornecedor não encontrada." });
                }

                db.Fornecedores.Remove(fornecedor);
                await db.SaveChangesAsync();

                return Results.Ok(new { message = "Fornecedor apagado" });

            });
        }
    }
}
