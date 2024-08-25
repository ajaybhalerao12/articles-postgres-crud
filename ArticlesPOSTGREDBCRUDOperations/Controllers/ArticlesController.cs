using ArticlesPOSTGREDBCRUDOperations.Data;
using ArticlesPOSTGREDBCRUDOperations.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ArticlesPOSTGREDBCRUDOperations.Controllers
{
    [ApiController]
    [Route("api/articles")]    
    public class ArticlesController : ControllerBase
    {
        private readonly AppDBContext _context;

        public ArticlesController(AppDBContext context)
        {
            _context = context;
        }


        [HttpGet]
        // GET: api/articles
        public async Task<ActionResult<IEnumerable<Article>>> GetArticles()
        {
            return await _context.Articles.ToListAsync();
        }
    }
}
