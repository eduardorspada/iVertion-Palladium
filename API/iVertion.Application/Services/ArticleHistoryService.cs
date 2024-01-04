using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using iVertion.Application.DTOs;
using iVertion.Application.Interfaces;
using iVertion.Domain.Entities;
using iVertion.Domain.FiltersDb;
using iVertion.Domain.Interfaces;

namespace iVertion.Application.Services
{
    public class ArticleHistoryService : IArticleHistoryService
    {
        private readonly IArticleHistoryRepository _articleHistoryRepository;
        private readonly IRepository _repo;
        private readonly IMapper _mapper;
        public ArticleHistoryService(IArticleHistoryRepository articleHistoryRepository,
                                     IRepository repo,
                                     IMapper mapper)
        {
            _articleHistoryRepository = articleHistoryRepository ?? 
                throw new ArgumentNullException(nameof(articleHistoryRepository));
            _repo = repo ??
                throw new ArgumentNullException(nameof(repo));
            _mapper = mapper;
        }
        public async Task CreateAsync(ArticleHistoryDTO ArticleHistoryDto)
        {
            var articleHistoryEntity = _mapper.Map<ArticleHistory>(ArticleHistoryDto);
            await _repo.CreateAsync(articleHistoryEntity);
        }

        public async Task<ResultService<ArticleHistoryDTO>> GetArticleHistoryByIdAsync(int? id)
        {
            var articleHistory = await _articleHistoryRepository.GetArticleHistoryByIdAsync(id);
            return ResultService.OK(_mapper.Map<ArticleHistoryDTO>(articleHistory));
        }

        public async Task<ResultService<PagedBaseResponseDTO<ArticleHistoryDTO>>> GetArticleHistoriesAsync(ArticleHistoryFilterDb articleHistoryFilterDb)
        {
            var articleHistories = await _articleHistoryRepository.GetArticleHistoriesAsync(articleHistoryFilterDb);
            var result = new PagedBaseResponseDTO<ArticleHistoryDTO>(articleHistories.TotalRegisters, 
                                                              _mapper.Map<List<ArticleHistoryDTO>>(articleHistories.Data));
            return ResultService.OK(result);
        }
    }
}