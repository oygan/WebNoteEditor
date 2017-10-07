using System.Data.Entity;
using GoodNoteEditor.Domain.Entities;

namespace GoodNoteEditor.Domain.Concrete.Repository
{
    /// <summary>
    /// Entities 
    /// </summary>
    public class EFDbContext : DbContext 
    {
        /// <summary>
        /// Notes
        /// </summary>
        public DbSet<Note> Notes { get; set; }

        /// <summary>
        /// Maps tables and models
        /// </summary>
        /// <param name="modelBuilder">model builder</param>
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            Database.SetInitializer(new DropCreateDatabaseIfModelChanges<EFDbContext>());
           // Database.SetInitializer<EFDbContext>(null);
            base.OnModelCreating(modelBuilder);
        }
    }
}
