using Carter;
using GestaoDeInventarioAPI.Context;
using GestaoDeInventarioAPI.Dto;
using Microsoft.EntityFrameworkCore;

namespace GestaoDeInventarioAPI.Module
{
    public class EstoqueModule : ICarterModule
    {
        public void AddRoutes(IEndpointRouteBuilder app)
        {
            app.MapGet("/estoque", async (InventarioContext db) =>
                await db.Estoques.ToListAsync());

            app.MapGet("/estoque/{id}", async (InventarioContext db, int id) =>
            {
                var estoque = await db.Estoques.FindAsync(id);

                if (estoque == null)
                {
                    return Results.NotFound(new { message = "Estoque não encontrado." });
                }


                return estoque == null ? Results.NotFound() : Results.Ok(estoque);
            });

            app.MapPost("/estoque", async (InventarioContext db, EstoqueCreate newEstoque) =>
            {

                var estoque = new EstoqueEntity
                {
                    QuantidadeEntrada = newEstoque.QuantidadeEntrada,
                    QuantidadeSaida = newEstoque.QuantidadeSaida,
                    TipoMovimentacao = newEstoque.TipoMovimentacao,
                };

                db.Estoques.Add(estoque);
                await db.SaveChangesAsync();

                return Results.Created($"/estoque/{estoque.Id}", estoque);

            });

            app.MapPut("/estoque/{id}", async (InventarioContext db, int id, EstoqueCreate updateEstoque) =>
            {
                var estoque = await db.Estoques.FindAsync(id);

                if (estoque == null)
                {
                    return Results.NotFound();
                }

                estoque.QuantidadeEntrada = updateEstoque.QuantidadeEntrada;
                estoque.QuantidadeSaida = updateEstoque.QuantidadeSaida;
                estoque.TipoMovimentacao = updateEstoque.TipoMovimentacao;

                await db.SaveChangesAsync();

                return Results.Ok(estoque);
            });

            app.MapDelete("/estoque/{id}", async (InventarioContext db, int id) =>
            {
                var estoque = await db.Estoques.FindAsync(id);

                if (estoque == null)
                {
                    return Results.NotFound(new { message = "Estoque não encontrado." });
                }

                db.Estoques.Remove(estoque);
                await db.SaveChangesAsync();

                return Results.Ok(new { message = "Estoque apagado" });

            });
        }
    }
}
