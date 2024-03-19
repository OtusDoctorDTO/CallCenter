using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.EntityFramework
{
    /// <summary>
    /// Контекст
    /// </summary>
    public class DatabaseContext : DbContext
    {
        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
        {
            Database.EnsureCreated();
        }
        
        /// <summary>
        /// Контакты
        /// </summary>
        public DbSet<Contact> Contacts { get; set; }
        /// <summary>
        /// Документы
        /// </summary>
        public DbSet<Domain.Entities.Document> Documents { get; set; }
        /// <summary>
        /// пациенты
        /// </summary>
        public DbSet<Patient> Patients { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Patient>()
                .HasOne(e => e.Document)
                .WithOne(e => e.Patient)
                .HasForeignKey<Patient>(e => e.DocumentId)
                .IsRequired();
        }
    }
}