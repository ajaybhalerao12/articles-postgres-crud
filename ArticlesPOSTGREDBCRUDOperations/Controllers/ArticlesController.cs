using ArticlesPOSTGREDBCRUDOperations.DTOs;
using ArticlesPOSTGREDBCRUDOperations.Models;
using ArticlesPOSTGREDBCRUDOperations.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ArticlesPOSTGREDBCRUDOperations.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/articles")]
    public class ArticlesController : ControllerBase
    {

        private readonly IArticleService _articleService;

        public ArticlesController(IArticleService articleService)
        {   
            _articleService = articleService;
        }

        [HttpGet]
        // GET: api/articles
        public async Task<ActionResult<IEnumerable<ArticleDto>>> GetArticles()
        {
            var articlesDtos = await _articleService.GetAllArticles();
            return Ok(articlesDtos);
        }

        // GET: api/articles/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<ArticleDto>> GetArticle(int id)
        {
            ArticleDto? article = await _articleService.GetArticleWithDetails(id);
            if (article == null)
            {
                return NotFound();
            }
            return Ok(article);
        }

        [HttpPost]
        public async Task<ActionResult<Article>> PostArticle(ArticleDto articleDto)
        {          
            var newArticle = await _articleService.AddArticle(articleDto);
            return CreatedAtAction("GetArticle", new { id = articleDto.Id} , articleDto);
        }

        // Update: api/articles/{id}
        [HttpPut("{id}")]
        public async Task<ActionResult<ArticleDto>> PutArticle(int id, ArticleDto articleDto)
        {
            var article = await _articleService.UpdateArticle(id, articleDto);
            if(article == null)
            {
                return NotFound(new { Message = $"Article with {id} not found " });
            }
            return NoContent();

            //if (id != article.Id)
            //{
            //    return BadRequest();
            //}
            //_context.Entry(article).State = EntityState.Modified;

            //try
            //{
            //    await _context.SaveChangesAsync();
            //}
            //catch (DbUpdateConcurrencyException)
            //{
            //    if (!ArticleExists(id))
            //    {
            //        return NotFound();
            //    }
            //    throw;
            //}

            //return NoContent();
        }

        // DELETE: api/articles/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteArticle(int id)
        {
            bool result = await _articleService.DeleteArticle(id);
            if (!result)
            {
                return NotFound(new { Message =$"Article with {id} not found "});
            }
            return NoContent();
        }
    }
}
