using ComuniQApi.Data;
using ComuniQApi.Repositorios.Interfaces;
using ComuniQApi.Repositorios;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddEntityFrameworkSqlServer()
    .AddDbContext<Contexto>(
    options => options.UseSqlServer(builder.Configuration.GetConnectionString("DataBase"))
    );

builder.Services.AddScoped<IBairrosRepositorio, BairrosRepositorio>();
builder.Services.AddScoped<ICampanhasRepositorio, CampanhasRepositorio>();
builder.Services.AddScoped<ICidadesRepositorio, CidadesRepositorio>();
builder.Services.AddScoped<IComentariosRepositorio, ComentariosRepositorio>();
builder.Services.AddScoped<IDenunciasRepositorio, DenunciasRepositorio>();
builder.Services.AddScoped<IEstadosRepositorio, EstadosRepositorio>();
builder.Services.AddScoped<IPublicacoesRepositorio, PublicacoesRepositorio>();
builder.Services.AddScoped<ITipoCampanhasRepositorio, TipoCampanhasRepositorio>();
builder.Services.AddScoped<ITipoDenunciasRepositorio, TipoDenunciasRepositorio>();
builder.Services.AddScoped<IUsuariosRepositorio, UsuariosRepositorio>();
builder.Services.AddScoped<ITipoPerfisRepositorio, TipoPerfisRepositorio>();


builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(
        policy =>
        {
            policy.AllowAnyOrigin()
                .AllowAnyMethod()
                .AllowAnyHeader();
        });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
