using Microsoft.EntityFrameworkCore;
using ExamenPar2.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var connecionString = builder.Configuration.GetConnectionString("cadenaSQL");

///AGREGAMOS LA CONFIGURACIÓN PARA SQL
builder.Services.AddDbContext<DbExamenContext>(options => options.UseSqlServer(connecionString));

///DEFINIMOS LA NUEVA POLITICA DE CORS
builder.Services.AddCors(options =>
{
    options.AddPolicy("NuevaPolitica", app =>
    {
        app.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod();
    });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

///ACTIVAMOS LA POLITICA
app.UseCors("NuevaPolitica");

app.UseAuthorization();

app.MapControllers();

app.Run();
