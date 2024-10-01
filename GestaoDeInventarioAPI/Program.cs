using Carter;
using GestaoDeInventarioAPI.Extensions;

var builder = WebApplication.CreateBuilder(args);
builder.AddServices();
builder.AddOpenAPI();
builder.Services.AddEFCore(builder.Configuration);

var app = builder.Build();
app.UseServices();
app.MapCarter();
app.UseOpenAPI(string.Empty);



app.Run();