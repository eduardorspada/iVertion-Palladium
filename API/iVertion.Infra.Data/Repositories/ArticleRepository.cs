
using iVertion.Domain.Entities;
using iVertion.Domain.FiltersDb;
using iVertion.Domain.Interfaces;
using iVertion.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace iVertion.Infra.Data.Repositories
{
    public class ArticleRepository : IArticleRepository
    {
        private readonly ApplicationDbContext _context;
        public ArticleRepository(ApplicationDbContext context)
        {
            _context = context;            
        }

        public async Task<Article> GetArticleByIdAsync(int? id)
        {
            _context.ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
            var article = await _context.Articles.FindAsync(id);
            return article;
        }

        public async Task<PagedBaseResponse<Article>> GetArticlesAsync(ArticleFilterDb request)
        {
            var articles =  _context.Articles.AsQueryable();
            if (!String.IsNullOrEmpty(request.Title))
                articles = articles.Where(p => p.Title.Contains(request.Title));
            if (request.Active != null)
                articles = articles.Where(p => p.Active == request.Active);
            if (request.CategoryId != null)
                articles = articles.Where(p => p.CategoryId == request.CategoryId);
            if (!String.IsNullOrEmpty(request.UserId))
                articles = articles.Where(p => p.UserId.Contains(request.UserId));

            return await PagedBaseResponseHelper
                            .GetResponseAsync<PagedBaseResponse<Article>, Article>(articles, request);
        }
    }
}