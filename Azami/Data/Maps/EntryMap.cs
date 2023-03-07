using Azami.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Azami.Data.Maps
{
    public class EntryMap : IEntityTypeConfiguration<EntryModel>
    {
        public void Configure(EntityTypeBuilder<EntryModel> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Title).IsRequired().HasMaxLength(255);
            builder.Property(x => x.Username).IsRequired().HasMaxLength(255);
            builder.Property(x => x.Password).IsRequired().HasMaxLength(255);
            builder.Property(x => x.UserId).IsRequired().HasMaxLength(255);
            builder.HasOne(x => x.User)
                .WithMany(u => u.Entries)
                .HasForeignKey(x => x.UserId);
        }
    }
}
