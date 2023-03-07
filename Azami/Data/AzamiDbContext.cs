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
        public DbSet<EntryModel> Entries { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new UserMap());
            modelBuilder.ApplyConfiguration(new EntryMap());
            base.OnModelCreating(modelBuilder);
        }
    }
}
