using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using PromoIphones.Controllers;
using PromoIphones.Interfaces;
using PromoIphones.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer(); 

builder.Services.AddSingleton<IPromocaoService, PromocaoService>();
builder.Services.AddTransient<PromocaoController>();

// Configuração do Swagger
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "iPhone Promo API",
        Version = "v1",
        Description = "API para promoção de iPhones - 100 por R$ 1,00 a cada hora",
        Contact = new OpenApiContact
        {
            Name = "Sua Equipe",
            Email = "contato@empresa.com"
        }
    });
});

var app = builder.Build();

// Configure the HTTP
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "iPhone Promo API V1");
        c.RoutePrefix = "swagger";
    });
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.MapGet("/", () => Results.Redirect("/swagger"));

app.Run();