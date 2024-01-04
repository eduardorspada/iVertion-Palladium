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
    public class CounterService : ICounterService
    {
        private readonly ICounterRepository _counterRepository;
        private readonly IRepository _repo;
        private readonly IMapper _mapper;

        public CounterService(ICounterRepository counterRepository,
                              IRepository repo,
                              IMapper mapper)
        {
            _counterRepository = counterRepository ?? 
                throw new ArgumentNullException(nameof(counterRepository));
            _repo = repo ??
                throw new ArgumentNullException(nameof(repo));
            _mapper = mapper;
        }

        public async Task CreateAsync(CounterDTO counterDto)
        {
            var counterEntity = _mapper.Map<Counter>(counterDto);
            await _repo.CreateAsync(counterEntity);
        }

        public async Task<ResultService<CounterDTO>> GetCounterByIdAsync(int id)
        {
            var counter = await _counterRepository.GetCounterById(id);
            return ResultService.OK(_mapper.Map<CounterDTO>(counter));
        }

        public async Task<ResultService<PagedBaseResponseDTO<CounterDTO>>> GetCountersAsync(CounterFilterDb counterFilterDb)
        {
            var counters = await _counterRepository.GetCountersAsync(counterFilterDb);
            var result = new PagedBaseResponseDTO<CounterDTO>(counters.TotalRegisters, 
                                                              _mapper.Map<List<CounterDTO>>(counters.Data));

            return ResultService.OK(result);
        }

        public async Task RemoveAsync(int id)
        {
            var counterEntity = _counterRepository.GetCounterById(id).Result;
            await _repo.RemoveAsync(counterEntity);
        }

        public async Task UpdateAsync(CounterDTO counterDto)
        {
            var counterEntity = _mapper.Map<Counter>(counterDto);
            await _repo.UpdateAsync(counterEntity);
        }
    }
}