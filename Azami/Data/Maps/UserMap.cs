using Azami.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Azami.Data.Maps
{
    public class UserMap : IEntityTypeConfiguration<UserModel>
    {
        public void Configure(EntityTypeBuilder<UserModel> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Name).IsRequired().HasMaxLength(255);
            builder.Property(x => x.Email).IsRequired().HasMaxLength(255);
            builder.Property(x => x.MasterPassword).IsRequired().HasMaxLength(255).UseCollation("latin1_general_cs");
            builder.HasMany(x => x.Entries).WithOne(e => e.User);
            builder.Navigation(x => x.Entries).UsePropertyAccessMode(PropertyAccessMode.Property);
        }
    }
}
