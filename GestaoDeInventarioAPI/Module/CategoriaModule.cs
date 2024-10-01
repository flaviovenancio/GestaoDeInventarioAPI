using Carter;
using GestaoDeInventarioAPI.Context;
using GestaoDeInventarioAPI.Dto;
using Microsoft.EntityFrameworkCore;

namespace GestaoDeInventarioAPI.Module
{
    public class CategoriaModule : ICarterModule
    {
        public void AddRoutes(IEndpointRouteBuilder app)
        {
            app.MapGet("/categorias", async (InventarioContext db) =>
                await db.Categorias.ToListAsync());

            app.MapGet("/categorias/{id}", async (InventarioContext db, int id) =>
            {
                var categoria = await db.Categorias.FindAsync(id);

                if (categoria == null)
                {
                    return Results.NotFound(new { message = "Categoria não encontrada." });
                }

                return categoria == null ? Results.NotFound() : Results.Ok(categoria);
            });

            app.MapPost("/categorias", async (InventarioContext db, CategoriaCreate newCategoria) =>
            {

                var categoria = new CategoriaEntity
                {
                    Nome = newCategoria.Nome,
                    Descricao = newCategoria.Descricao,
                    Ativo = newCategoria.Ativo,
                };

                db.Categorias.Add(categoria);
                await db.SaveChangesAsync();

                return Results.Created($"/categorias/{categoria.Id}", categoria);

            });

            app.MapPut("/categorias/{id}", async (InventarioContext db, int id, CategoriaCreate updateCategoria) =>
            {
                var categoria = await db.Categorias.FindAsync(id);

                if (categoria == null)
                {
                    return Results.NotFound();
                }

                categoria.Nome = updateCategoria.Nome;
                categoria.Descricao = updateCategoria.Descricao;
                categoria.Ativo = updateCategoria.Ativo;

                await db.SaveChangesAsync();

                return Results.Ok(categoria);
            });

            app.MapDelete("/categorias/{id}", async (InventarioContext db, int id) =>
            {
                var categoria = await db.Categorias.FindAsync(id);

                if (categoria == null)
                {
                    return Results.NotFound(new { message = "Categoria não encontrada." });
                }

                db.Categorias.Remove(categoria);
                await db.SaveChangesAsync();

                return Results.Ok(new { message = "Categoria apagada" });

            });
        }
    }
}
