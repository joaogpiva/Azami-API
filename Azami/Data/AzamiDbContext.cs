using Azami.Data.Maps;
using Azami.Models;
using Microsoft.EntityFrameworkCore;

namespace Azami.Data
{
    public class AzamiDbContext : DbContext
    {
        public AzamiDbContext(DbContextOptions<AzamiDbContext> options) : base(options) 
        {
        }

        public DbSet<UserModel> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new UserMap());
            modelBuilder.Entity<UserModel>().Property(u => u.MasterPassword)
                .UseCollation("latin1_general_cs");
            base.OnModelCreating(modelBuilder);
        }
    }
}
