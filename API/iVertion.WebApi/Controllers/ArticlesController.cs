using iVertion.Application.DTOs;
using iVertion.Application.Interfaces;
using iVertion.Domain.FiltersDb;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace iVertion.WebApi.Controllers
{
    /// <summary>
    /// Articles
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class ArticlesController : ControllerBase
    {
        private readonly IArticleService _articleService;
        private readonly IArticleHistoryService _articleHistoryService;
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="articleService"></param>
        /// <param name="articleHistoryService"></param>
        public ArticlesController(IArticleService articleService, IArticleHistoryService articleHistoryService)
        {
            _articleService = articleService;
            _articleHistoryService = articleHistoryService;
        }
        /// <summary>
        /// Returns the articles, paginating them according to the "articleFilterDb" parameters. 
        /// </summary>
        /// <param name="articleFilterDb"></param>
        /// <returns></returns>
        [HttpGet]
        [AllowAnonymous]
        public async Task<ActionResult> GetArticleAsync([FromQuery] ArticleFilterDb articleFilterDb)
        {
            var result = await _articleService.GetArticlesAsync(articleFilterDb);
            if (result.IsSuccess)
                return Ok(result);

            return BadRequest(result);
        }
        /// <summary>
        /// Returns an article by its Id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("{id}")]
        [AllowAnonymous]
        public async Task<ActionResult> GetByIdAsync(int id)
        {
            var result = await _articleService.GetArticleByIdAsync(id);
            if (result.Data == null)
                return NotFound();
            if (result.IsSuccess)
                return Ok(result);
            return BadRequest(result);
        }
        /// <summary>
        /// Creates a new article with the properties of "articleDto".
        /// </summary>
        /// <param name="articleDto"></param>
        /// <returns></returns>
        [HttpPost]
        [Authorize(Roles = "AddArticle")]
        public async Task<ActionResult> Post([FromBody] ArticleDTO articleDto)
        {
            if (articleDto == null)
                return BadRequest("The object needs to be informed.");
            var userId = User.FindFirst("UId").Value;
            var name = User.FindFirst("Name").Value;
            var dateNow = DateTime.UtcNow;
            articleDto.CreatedAt = dateNow;
            articleDto.UpdatedAt = dateNow;
            articleDto.UserId = userId;
            articleDto.Author = name;
            await _articleService.CreateAsync(articleDto);
            return Ok(articleDto);
        }
        /// <summary>
        /// Updates an article with the properties of "articleDto".
        /// </summary>
        /// <param name="id"></param>
        /// <param name="articleDto"></param>
        /// <returns></returns>
        [HttpPut]
        [Authorize(Roles = "EditArticle")]
        public async Task<ActionResult> Put(int id,[FromBody] ArticleDTO articleDto)
        {
            if (id != articleDto.Id)
                return BadRequest();
            if (articleDto == null)
                return BadRequest();
            var result = await _articleService.GetArticleByIdAsync(id);
            if (result.Data != null)
            {
                ArticleHistoryDTO articleHistory = new();
                var userId = User.FindFirst("UId").Value;
                var article = await _articleService.GetArticleByIdAsync(id);
                var active = article.Data.Active;
                var title = article.Data.Title;
                var description = article.Data.Description;
                var categoryId = article.Data.CategoryId;
                var articleId = id;
                var author = article.Data.Author;
                var createdAt = article.Data.CreatedAt;
                var updatedAt = DateTime.UtcNow;
                articleDto.CreatedAt = createdAt;
                
                articleDto.UpdatedAt = updatedAt;
                articleHistory.UserId=article.Data.UserId;
                articleDto.UserId = userId;
                articleDto.Author = author;
                articleHistory.Author = author;
                articleHistory.Active=active;
                articleHistory.Title=title;
                articleHistory.Description=description;
                articleHistory.CategoryId=categoryId;
                articleHistory.ArticleId=articleId;
                articleHistory.CreatedAt=updatedAt;

                await _articleService.UpdateAsync(articleDto);
                await _articleHistoryService.CreateAsync(articleHistory);

                return Ok(articleDto);
            }
            else
            {
                return NotFound($"The article Id: {id}, does not exist in the system.");
            }

        }
        /// <summary>
        /// Deletes an article by its Id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete]
        [Route("{id}")]
        [Authorize(Roles = "RemoveArticle")]
        public async Task<ActionResult> Delete(int id)
        {
            var article = await _articleService.GetArticleByIdAsync(id);
            if (article.Data == null)
                return NotFound("Article not found.");
            
            await _articleService.RemoveAsync(id);
            return Ok("Success");
        }
    }
}