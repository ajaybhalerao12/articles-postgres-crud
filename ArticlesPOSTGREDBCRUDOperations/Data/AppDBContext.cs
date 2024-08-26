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

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<User>(entity =>
            {
                entity.HasKey(x => x.Id);
                entity.Property(e => e.UserName).IsRequired().HasMaxLength(20);
                entity.Property(e => e.Password).IsRequired();

                entity.HasData(
                    new User
                    {
                        Id = 1,
                        UserName = "test",
                        Password = "password",
                    },
                    new User
                    {
                        Id = 2,
                        UserName = "test2",
                        Password = "password2",
                    });

            });
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
