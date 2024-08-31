using ArticlesPOSTGREDBCRUDOperations.DTOs;
using Microsoft.EntityFrameworkCore;

namespace ArticlesPOSTGREDBCRUDOperations.Services
{
    public interface IArticleService
    {
        public Task<ArticleDto>? GetArticleWithDetails(int articleId);
    }
}