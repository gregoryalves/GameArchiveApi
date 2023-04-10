using GameArchive.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GameArchive.Data.Map
{
    public class DesenvolvedoraMap : IEntityTypeConfiguration<DesenvolvedoraModel>
    {
        public void Configure(EntityTypeBuilder<DesenvolvedoraModel> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Nome).IsRequired().HasMaxLength(255);
        }
    }
}
