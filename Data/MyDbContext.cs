using Microsoft.EntityFrameworkCore;

namespace FlashcardLibrary.Data
{
    public class MyDbContext: DbContext
    {
        public MyDbContext(DbContextOptions<MyDbContext> options): base(options) { }
        public DbSet<Category> Category { get; set; }
        public DbSet<Flashcard> Flashcard { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Category>().ToTable("Category");
            modelBuilder.Entity<Flashcard>().ToTable("Flashcard");
        }
    }
}
