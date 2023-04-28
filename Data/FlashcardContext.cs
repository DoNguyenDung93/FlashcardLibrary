using Microsoft.EntityFrameworkCore;

namespace FlashcardLibrary.Data
{
    public class FlashcardContext: DbContext
    {
        public FlashcardContext(DbContextOptions<FlashcardContext> options): base(options) { }
        public FlashcardContext() { }
        public DbSet<Category> Category { get; set; }
        public DbSet<Flashcard> Flashcard { get; set; }
        public DbSet<Attachment> Attachment { get; set; }
        public DbSet<User> User { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Category>().ToTable("Category");
            modelBuilder.Entity<Flashcard>().ToTable("Flashcard");
            modelBuilder.Entity<Attachment>().ToTable("Attachment");
            modelBuilder.Entity<User>().ToTable("User");

            modelBuilder.Entity<Attachment>()
                        .HasOne(s => s.Flashcard)
                        .WithMany(g => g.Attachments)
                        .HasForeignKey(s => s.FlashcardID);

            modelBuilder.Entity<Flashcard>()
                        .HasOne(s => s.Category)
                        .WithMany(g => g.Flashcards)
                        .HasForeignKey(s => s.CategoryID);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            var connectionString = configuration.GetConnectionString("MainDB");
            optionsBuilder.UseSqlServer(connectionString);
        }
    }
}
