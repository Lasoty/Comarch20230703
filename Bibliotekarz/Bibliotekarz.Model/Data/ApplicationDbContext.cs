using Bibliotekarz.Model.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bibliotekarz.Model.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext() : base()
        { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            string connString = "Server=localhost;Database=BibliotekarzDb;Trusted_Connection=True;MultipleActiveResultSets=true;TrustServerCertificate=true";
            string connString2 = "Server=localhost;Database=BibliotekarzDb;User Id=sa;Password=Qwerty123";
            optionsBuilder.UseSqlServer(connString).EnableSensitiveDataLogging();

            base.OnConfiguring(optionsBuilder);
        }

        public DbSet<Book> Books { get; set; }
        
        public DbSet<Customer> Borrowers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Customer>().Property(e => e.FirstName).HasMaxLength(50).IsRequired();
            modelBuilder.Entity<Customer>().Property(e => e.LastName).HasMaxLength(150).IsRequired();

            modelBuilder.Entity<Book>().HasOne(e => e.Borrower)
                .WithMany()
                .IsRequired(false)
                .OnDelete(DeleteBehavior.NoAction);

            base.OnModelCreating(modelBuilder);
        }
    }
}
