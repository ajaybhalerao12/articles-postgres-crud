using ArticlesPOSTGREDBCRUDOperations.Data;
using ArticlesPOSTGREDBCRUDOperations.DTOs;
using ArticlesPOSTGREDBCRUDOperations.Models;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace ArticlesPOSTGREDBCRUDOperations.Services
{
    public class ArticleService(IMapper mapper, AppDBContext context) :
        IArticleService
    {
        public async Task<ArticleDto> AddArticle(ArticleDto articleDto)
        {
            articleDto.CreatedAt = DateTime.UtcNow;
            articleDto.Id = context.Articles.Count() + 1;
            var article = mapper.Map<Article>(articleDto);
            
            // Add new article
            foreach (var categoryName in articleDto.Categories)
            {
                var category = context.Categories
                    .FirstOrDefault(c => c.CategoryName == categoryName);
                if (category != null)
                {
                    article.ArticleCategories.Clear();
                    article.ArticleCategories.Add(new ArticleCategory
                    {
                        ArticleId = article.Id,
                        CategoryId = category.CategoryId
                    });
                }
            }

            context.Articles.Add(article);
            await context.SaveChangesAsync();
            var createdArticleDto = mapper.Map<ArticleDto>(article);
            return createdArticleDto;
        }

        public async Task<IEnumerable<ArticleDto>> GetAllArticles()
        {
            var articles = await context.Articles
                .Include(a => a.Author)
                .Include(ac => ac.ArticleCategories)
                    .ThenInclude(ac => ac.Category)
                .ToListAsync();
            var articleDtos = mapper.Map<IEnumerable<ArticleDto>>(articles);
            return articleDtos;
        }

        public async Task<ArticleDto>? GetArticleWithDetails(int articleId)
        {
            var article = await context.Articles
                .Include(x => x.Author)
                .Include(ac => ac.ArticleCategories)
                   .ThenInclude(ac => ac.Category)
                .FirstOrDefaultAsync(a => a.Id == articleId);
            //var article = context.Articles
            //.Include(a => a.Author)

            //.Where(a => a.Id == articleId)
            //.Select(a => new ArticleDto
            //{
            //    Id = a.Id,
            //    Title = a.Title,
            //    Content = a.Content,
            //    CreatedAt = a.CreatedAt,
            //    AuthorId = a.AuthorId,
            //    AuthorName = a.Author.Name
            //})
            //.FirstOrDefault();

            if (article == null)
            {
                return null;
            }

            ArticleDto articleDto = mapper.Map<ArticleDto>(article);
            return articleDto;
        }

        public async Task<ArticleDto> UpdateArticle(int articleId, ArticleDto articleDto)
        {
            var article = mapper.Map<Article>(articleDto);

            // Check if the article already exists
            var existingArticle = await context.Articles
                .Include(a => a.ArticleCategories)
                .FirstOrDefaultAsync(a => a.Id == articleId);

            if (existingArticle == null)
            {
                return null;
            }
            else
            {
                existingArticle.Title = articleDto.Title;
                existingArticle.Content = articleDto.Content;
                existingArticle.CreatedAt = articleDto.CreatedAt;
                existingArticle.AuthorId = article.AuthorId;

                // Update Categories
                existingArticle.ArticleCategories.Clear();
                foreach (var categoryName in articleDto.Categories)
                {
                    var category = await context.Categories
                        .FirstOrDefaultAsync(c => c.CategoryName == categoryName);

                    if (category != null)
                    {
                        existingArticle.ArticleCategories.Add(new ArticleCategory
                        {
                            ArticleId = articleId,
                            CategoryId = category.CategoryId,
                        });
                    }
                }
                context.Articles.Update(existingArticle);
            }
            await context.SaveChangesAsync();

            return mapper.Map<ArticleDto>(article);
        }

        public async Task<bool> DeleteArticle(int articleId)
        {
            var article = await context.Articles.FindAsync(articleId);
            if (article == null) {
                return false;
            };
            context.Articles.Remove(article);
            await context.SaveChangesAsync();
            return true;
        }

        private bool ArticleExists(int id)
        {
            return context.Articles.Any(a => a.Id == id);
        }
    }
}
