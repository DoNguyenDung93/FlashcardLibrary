using Microsoft.EntityFrameworkCore;

namespace FlashcardLibrary.Data
{
    public class MyDbContext: DbContext
    {
        public MyDbContext(DbContextOptions<MyDbContext> options): base(options) { }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Flashcard> Flashcards { get; set; }
    }
}
