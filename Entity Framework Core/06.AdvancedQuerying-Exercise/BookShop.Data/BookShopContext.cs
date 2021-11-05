namespace BookShop.Data
{
    using Microsoft.EntityFrameworkCore;

    using Models;

    public class BookShopContext : DbContext
    {
		public BookShopContext() { }

		public BookShopContext(DbContextOptions options)
			:base(options) { }

        public DbSet<Author> Authors { get; set; }

        public DbSet<Book> Books { get; set; }

        public DbSet<BookCategory> BookCategories { get; set; }

        public DbSet<Category> Categories { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(Configuration.ConnectionString);
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<BookCategory>()
                .HasKey(k => new { k.BookId, k.CategoryId });
        }
    }
}
