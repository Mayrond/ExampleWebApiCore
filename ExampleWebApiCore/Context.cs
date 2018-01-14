using ExampleWebApiCore.Infrastructure;
using ExampleWebApiCore.Models;
using ExampleWebApiCore.Models.General;
using Microsoft.EntityFrameworkCore;

namespace ExampleWebApiCore
{
    public sealed class Context : DbContext
    {
        public Context()
        {
            Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=helloappdb;Trusted_Connection=True;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            foreach (var type in modelBuilder.Model.GetEntityTypes())
                modelBuilder.SetSoftDeleteFilter(type.ClrType);   
        }

        public DbSet<Good> Goods { get; set; }
    }
}