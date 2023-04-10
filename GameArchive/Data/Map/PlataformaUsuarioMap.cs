using GameArchive.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GameArchive.Data.Map
{
    public class PlataformaUsuarioMap : IEntityTypeConfiguration<PlataformaUsuarioModel>
    {
        public void Configure(EntityTypeBuilder<PlataformaUsuarioModel> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Nome).IsRequired().HasMaxLength(255);
            builder.Property(x => x.PlataformaId).IsRequired();
            builder.HasOne(x => x.Plataforma);
            builder.Property(x => x.UsuarioId).IsRequired();
            builder.HasOne(x => x.Usuario);
            builder.Property(x => x.Controles).IsRequired();
        }
    }
}
