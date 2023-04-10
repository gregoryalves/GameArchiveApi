using GameArchive.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GameArchive.Data.Map
{
    public class PlataformaMap : IEntityTypeConfiguration<PlataformaModel>
    {
        public void Configure(EntityTypeBuilder<PlataformaModel> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Nome).IsRequired().HasMaxLength(255);
        }
    }
}
