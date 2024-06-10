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
        /// Документы
        /// </summary>
        public DbSet<Domain.Entities.Document> Documents { get; set; }
    }
}