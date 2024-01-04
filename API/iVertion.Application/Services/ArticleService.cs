using AutoMapper;
using iVertion.Application.DTOs;
using iVertion.Application.Interfaces;
using iVertion.Domain.Entities;
using iVertion.Domain.FiltersDb;
using iVertion.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace iVertion.Application.Services
{
    public class ArticleService : IArticleService
    {
        private readonly IArticleRepository _articleRepository;
        private readonly IRepository _repo;
        private readonly IMapper _mapper;

        public ArticleService(IArticleRepository articleRepository,
                              IRepository repo,
                              IMapper mapper)
        {
            _articleRepository = articleRepository ?? 
                throw new ArgumentNullException(nameof(articleRepository));
            _repo = repo ??
                throw new ArgumentNullException(nameof(repo));
            _mapper = mapper;
        }

        public async Task<ResultService<PagedBaseResponseDTO<ArticleDTO>>> GetArticlesAsync(ArticleFilterDb articleFilterDb)
        {
            var articles = await _articleRepository.GetArticlesAsync(articleFilterDb);
            var result = new PagedBaseResponseDTO<ArticleDTO>(articles.TotalRegisters, 
                                                              _mapper.Map<List<ArticleDTO>>(articles.Data));

            return ResultService.OK(result);
        }

        public async Task CreateAsync(ArticleDTO ArticleDto)
        {
            var articleEntity = _mapper.Map<Article>(ArticleDto);
            await _repo.CreateAsync(articleEntity);
        }

        public async Task UpdateAsync(ArticleDTO ArticleDto)
        {
            var articleEntity = _mapper.Map<Article>(ArticleDto);
            await _repo.UpdateAsync(articleEntity);
        }

        public async Task RemoveAsync(int? id)
        {
            var articleEntity = _articleRepository.GetArticleByIdAsync(id).Result;
            await _repo.RemoveAsync(articleEntity);
        }

        public async Task<ResultService<ArticleDTO>> GetArticleByIdAsync(int? id)
        {
            var article = await _articleRepository.GetArticleByIdAsync(id);
            return ResultService.OK(_mapper.Map<ArticleDTO>(article));
        }
    }
}