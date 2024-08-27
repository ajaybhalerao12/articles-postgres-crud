using ArticlesPOSTGREDBCRUDOperations.Models;
using Microsoft.EntityFrameworkCore;

namespace ArticlesPOSTGREDBCRUDOperations.Data
{
    public class AppDBContext : DbContext
    {
        public AppDBContext(DbContextOptions<AppDBContext> options) : base(options)
        {

        }
        public DbSet<User> Users { get; set; }
        public DbSet<Article> Articles { get; set; }
        public DbSet<Author> Authors { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<ArticleCategory> ArticleCategories { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<ArticleCategory>()
                .HasKey(ac => new { ac.ArticleId, ac.CategoryId });

            modelBuilder.Entity<ArticleCategory>()
                .HasOne(ac=> ac.Article)
                .WithMany(ac=>ac.ArticleCategories)
                .HasForeignKey(ac=>ac.ArticleId);

            modelBuilder.Entity<ArticleCategory>()
                .HasOne(ac => ac.Category)
                .WithMany(ac => ac.ArticleCategories)
                .HasForeignKey(ac => ac.CategoryId);

            modelBuilder.Entity<User>(entity =>
            {
                entity.HasKey(x => x.Id);
                entity.Property(e => e.UserName).IsRequired().HasMaxLength(20);
                entity.Property(e => e.PasswordHash).IsRequired();

                entity.HasData(
                    new User
                    {
                        Id = 1,
                        UserName = "test",
                        PasswordHash = BCrypt.Net.BCrypt.HashPassword("password1")
                    },
                    new User
                    {
                        Id = 2,
                        UserName = "test2",
                        PasswordHash = BCrypt.Net.BCrypt.HashPassword("password2")
                    });

            });
            //modelBuilder.Entity<Article>().HasData(
            //    new Article
            //    {
            //        Id = 1,
            //        Title = "First Article",
            //        Content = "This is the content of the first article.",
            //        CreatedAt = DateTime.UtcNow
            //    },
            //    new Article
            //    {
            //        Id = 2,
            //        Title = "Second Article",
            //        Content = "This is the content of the second article.",
            //        CreatedAt = DateTime.UtcNow
            //    });
        }
    }
}
