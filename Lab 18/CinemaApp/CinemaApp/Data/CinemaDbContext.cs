using CinemaApp.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.IO;

namespace CinemaApp.Data
{
    public class CinemaDbContext : DbContext
    {
        public DbSet<MovieSession> Sessions => Set<MovieSession>();
        public DbSet<TicketModel> Tickets => Set<TicketModel>();

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (optionsBuilder.IsConfigured)
                return;

            var dataFolder = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Data");
            Directory.CreateDirectory(dataFolder);

            var dbPath = Path.Combine(dataFolder, "cinema.db");
            optionsBuilder.UseSqlite($"Data Source={dbPath}");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<MovieSession>()
                .HasKey(s => s.Id);

            modelBuilder.Entity<MovieSession>()
                .HasMany(s => s.Tickets)
                .WithOne(t => t.Session)
                .HasForeignKey(t => t.SessionId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<TicketModel>()
                .HasKey(t => t.Id);
        }
    }
}