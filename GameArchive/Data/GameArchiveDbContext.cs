using GameArchive.Data.Map;
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
            modelBuilder.ApplyConfiguration(new UsuarioMap());
            modelBuilder.ApplyConfiguration(new PlataformaMap());
            modelBuilder.ApplyConfiguration(new DesenvolvedoraMap());
            modelBuilder.ApplyConfiguration(new GeneroMap());
            modelBuilder.ApplyConfiguration(new JogoMap());
            modelBuilder.ApplyConfiguration(new UsuarioJogoMap());
            modelBuilder.ApplyConfiguration(new PlataformaUsuarioMap());

            //Remover o cascadeDelete
            var cascadeFKs = modelBuilder.Model.GetEntityTypes()
                                               .SelectMany(x => x.GetForeignKeys())
                                               .Where(fk => !fk.IsOwnership && fk.DeleteBehavior == DeleteBehavior.Cascade);

            foreach (var fk in cascadeFKs)
                fk.DeleteBehavior = DeleteBehavior.Restrict;

            //Montar uma query na mão
            //modelBuilder.Entity<PlataformaUsuarioModel>(x => x.ToSqlQuery(""));

            base.OnModelCreating(modelBuilder);
        }
    }
}
