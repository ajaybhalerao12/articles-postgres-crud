using ArticlesPOSTGREDBCRUDOperations.Data;
using ArticlesPOSTGREDBCRUDOperations.DTOs;
using ArticlesPOSTGREDBCRUDOperations.Models;
using ArticlesPOSTGREDBCRUDOperations.Services;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ArticlesPOSTGREDBCRUDOperations.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/articles")]
    public class ArticlesController : ControllerBase
    {        
        private readonly AppDBContext _context;
        private readonly IArticleService _articleService;

        public ArticlesController(AppDBContext context, IArticleService articleService)
        {   
            _context = context;
            _articleService = articleService;
        }

        [HttpGet]
        // GET: api/articles
        public async Task<ActionResult<IEnumerable<ArticleDto>>> GetArticles()
        {
            var articlesDtos = await _articleService.GetAllArticles();
            return Ok(articlesDtos);
        }

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

        [HttpPut("{id}")]
        public async Task<IActionResult> PutArticle(int id, Article article)
        {
            if (id != article.Id)
            {
                return BadRequest();
            }
            _context.Entry(article).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ArticleExists(id))
                {
                    return NotFound();
                }
                throw;
            }

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteArticle(int id)
        {            
            var article = await _context.Articles.FindAsync(id);

            if (article == null)
            {
                return NotFound();
            }
            _context.Articles.Remove(article);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ArticleExists(int id)
        {
            return _context.Articles.Any(a => a.Id == id);
        }
    }
}
