using System;
using Full_Stack_Food_Truck_Application.Data.Entities;

using Microsoft.EntityFrameworkCore;

namespace Full_Stack_Food_Truck_Application.Helpers
{
    public class DataContext : DbContext
    {
        
    public DataContext(DbContextOptions<DataContext> options) : base(options) { }
        public DbSet<Favorite> Favorites { get; set; }
        public DbSet<User> Users { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Favorite>()
                .HasOne(s => s.CreatedBy)
                .WithMany(s => s.Favorites);

            modelBuilder.Entity<Favorite>()
                .HasOne(s => s.Coordinates);

            modelBuilder.Entity<User>()
                .HasMany(s => s.Favorites)
                .WithOne(s => s.CreatedBy);
        }
    }
}

