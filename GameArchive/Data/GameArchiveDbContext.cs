using GameArchive.Models;
using Microsoft.EntityFrameworkCore;

namespace GameArchive.Data
{
    public class GameArchiveDbContext : DbContext
    {
        public GameArchiveDbContext(DbContextOptions<GameArchiveDbContext> options) : base(options)
        {
        }

        public DbSet<UsuarioModel> Usuarios { get; set; }
        public DbSet<UsuarioJogoModel> UsuariosJogos { get; set; }
        public DbSet<PlataformaUsuarioModel> PlataformasUsuarios { get; set; }
        public DbSet<PlataformaModel> Plataformas { get; set; }
        public DbSet<JogoModel> Jogos { get; set; }
        public DbSet<GeneroModel> Generos { get; set; }
        public DbSet<DesenvolvedoraModel> Desenvolvedoras { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            //Montar uma query na mão
            //modelBuilder.Entity<PlataformaUsuarioModel>(x => x.ToSqlQuery(""));
        }
    }
}
