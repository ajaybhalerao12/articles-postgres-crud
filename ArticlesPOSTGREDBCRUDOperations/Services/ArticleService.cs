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
    }
}
