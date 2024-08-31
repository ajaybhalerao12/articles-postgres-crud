using ArticlesPOSTGREDBCRUDOperations.DTOs;
using Microsoft.EntityFrameworkCore;

namespace ArticlesPOSTGREDBCRUDOperations.Services
{
    public interface IArticleService
    {
        public Task<IEnumerable<ArticleDto>> GetAllArticles();
        public Task<ArticleDto>? GetArticleWithDetails(int articleId);
        public Task<ArticleDto> AddArticle(ArticleDto articleDto);

        public Task<ArticleDto> UpdateArticle(int articleId,ArticleDto articleDto);
    }
}