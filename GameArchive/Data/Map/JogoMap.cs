using GameArchive.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GameArchive.Data.Map
{
    public class JogoMap : IEntityTypeConfiguration<JogoModel>
    {
        public void Configure(EntityTypeBuilder<JogoModel> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Nome).IsRequired().HasMaxLength(255);
            builder.Property(x => x.PlataformaId).IsRequired();
            builder.HasOne(x => x.Plataforma);
            builder.Property(x => x.DesenvolvedoraId).IsRequired();
            builder.HasOne(x => x.Desenvolvedora);
            builder.Property(x => x.GeneroId).IsRequired();
            builder.HasOne(x => x.Genero);
            builder.Property(x => x.FaixaEtaria).IsRequired();
        }
    }
}
