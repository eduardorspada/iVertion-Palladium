using System;
using System.Linq;
using System.Threading.Tasks;
using iVertion.Domain.Entities;
using iVertion.Domain.FiltersDb;
using iVertion.Domain.Interfaces;
using iVertion.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace iVertion.Infra.Data.Repositories
{
    public class ArticleHistoryRepository : IArticleHistoryRepository
    {
        private readonly ApplicationDbContext _context;
        public ArticleHistoryRepository(ApplicationDbContext context)
        {
            _context = context;            
        }

        public async Task<PagedBaseResponse<ArticleHistory>> GetArticleHistoriesAsync(ArticleHistoryFilterDb request)
        {
            var ArticleHistories =  _context.ArticleHistories.AsQueryable();
            if (!String.IsNullOrEmpty(request.Title))
                ArticleHistories = ArticleHistories.Where(p => p.Title.Contains(request.Title));
            if (request.Active != null)
                ArticleHistories = ArticleHistories.Where(p => p.Active == request.Active);
            if (request.ArticleId != null)
                ArticleHistories = ArticleHistories.Where(p => p.ArticleId == request.ArticleId);
            if (!String.IsNullOrEmpty(request.UserId))
                ArticleHistories = ArticleHistories.Where(p => p.UserId.Contains(request.UserId));

            return await PagedBaseResponseHelper
                            .GetResponseAsync<PagedBaseResponse<ArticleHistory>, ArticleHistory>(ArticleHistories, request);
        }

        public async Task<ArticleHistory> GetArticleHistoryByIdAsync(int? id)
        {
            _context.ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
            var articleHistories = await _context.ArticleHistories.FindAsync(id);
            return articleHistories;
        }
    }
}