using GameArchive.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GameArchive.Data.Map
{
    public class UsuarioJogoMap : IEntityTypeConfiguration<UsuarioJogoModel>
    {
        public void Configure(EntityTypeBuilder<UsuarioJogoModel> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.JogoId).IsRequired();
            builder.HasOne(x => x.Jogo);
            builder.Property(x => x.UsuarioId).IsRequired();
            builder.HasOne(x => x.Usuario);
            builder.Property(x => x.DataAquisicao).IsRequired();
            builder.Property(x => x.JaZerado).IsRequired();   
            builder.Property(x => x.EhMidiaFisica).IsRequired();   
            builder.Property(x => x.PrecoPago);   
            builder.Property(x => x.Descricao).HasMaxLength(1000);   
            builder.Property(x => x.Nota);   
        }
    }
}
