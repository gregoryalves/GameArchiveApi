using GameArchive.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GameArchive.Data.Map
{
    public class GeneroMap : IEntityTypeConfiguration<GeneroModel>
    {
        public void Configure(EntityTypeBuilder<GeneroModel> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Nome).IsRequired().HasMaxLength(255);
        }
    }
}
