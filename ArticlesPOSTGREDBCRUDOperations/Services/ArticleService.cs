using ArticlesPOSTGREDBCRUDOperations.Data;
using ArticlesPOSTGREDBCRUDOperations.DTOs;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace ArticlesPOSTGREDBCRUDOperations.Services
{
    public class ArticleService(IMapper mapper, AppDBContext context): 
        IArticleService
    {
        public async Task<IEnumerable<ArticleDto>> GetAllArticles()
        {
            var articles= await context.Articles
                .Include(a => a.Author)
                .Include(ac => ac.ArticleCategories)
                    .ThenInclude(ac => ac.Category)
                .ToListAsync();
            var articleDtos = mapper.Map<IEnumerable<ArticleDto>>(articles);
            return articleDtos;
        }

        public Task<ArticleDto>? GetArticleWithDetails(int articleId)
        {
            var article = context.Articles
                .Include(x => x.Author)
                .Include(ac => ac.ArticleCategories)
                   .ThenInclude(ac => ac.Category)
                .FirstOrDefault(a => a.Id == articleId);
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

            if (article == null) {
                return null;
            }

            ArticleDto articleDto = mapper.Map<ArticleDto>(article);
            return Task.FromResult<ArticleDto>(articleDto);
        }
    }
}
