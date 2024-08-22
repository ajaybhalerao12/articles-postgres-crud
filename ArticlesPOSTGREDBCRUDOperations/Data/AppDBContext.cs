using ArticlesPOSTGREDBCRUDOperations.Models;
using Microsoft.EntityFrameworkCore;

namespace ArticlesPOSTGREDBCRUDOperations.Data
{
    public class AppDBContext : DbContext
    {
        public AppDBContext(DbContextOptions<AppDBContext> options) : base(options)
        {

        }
        public DbSet<Article> Articles { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Article>().HasData(
                new Article
                {
                    Id = 1,
                    Title = "First Article",
                    Content = "This is the content of the first article.",
                    CreatedAt = DateTime.UtcNow
                },
                new Article
                {
                    Id = 2,
                    Title = "Second Article",
                    Content = "This is the content of the second article.",
                    CreatedAt = DateTime.UtcNow
                });
        }
    }
}
