
using GameArchive.Business;
using GameArchive.Business.Interfaces;
using GameArchive.Data;
using GameArchive.Repositorios.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace GameArchive
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            // Configuração de CORS
            builder.Services.AddCors(options =>
            {
                options.AddPolicy("AllowAll", builder =>
                {
                    builder.AllowAnyOrigin()
                           .AllowAnyMethod()
                           .AllowAnyHeader();
                });
            });

            //Configura��o do entity framework
            builder.Services.AddEntityFrameworkSqlServer().AddDbContext<GameArchiveDbContext>(
                    options => options.UseSqlServer(builder.Configuration.GetConnectionString("DataBase"))
                );

            //Inje��o de dependencia das Business classes
            builder.Services.AddScoped<IUsuarioBusiness, UsuarioBusiness>();
            builder.Services.AddScoped<IUsuarioJogoBusiness, UsuarioJogoBusiness>();

            //Inje��o de dependencia dos reposit�rios
            builder.Services.AddScoped<IDesenvolvedoraRepositorio, DesenvolvedoraRepositorio>();
            builder.Services.AddScoped<IGeneroRepositorio, GeneroRepositorio>();
            builder.Services.AddScoped<IJogoRepositorio, JogoRepositorio>();
            builder.Services.AddScoped<IPlataformaRepositorio, PlataformaRepositorio>();
            builder.Services.AddScoped<IPlataformaUsuarioRepositorio, PlataformaUsuarioRepositorio>();
            builder.Services.AddScoped<IUsuarioJogoRepositorio, UsuarioJogoRepositorio>();
            builder.Services.AddScoped<IUsuarioRepositorio, UsuarioRepositorio>();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            //if (app.Environment.IsDevelopment())
            //{
                app.UseSwagger();
                app.UseSwaggerUI();
            //}

            app.UseHttpsRedirection();

            app.UseCors("AllowAll");

            app.UseAuthorization();

            app.MapControllers();

            app.Run();
        }
    }
}