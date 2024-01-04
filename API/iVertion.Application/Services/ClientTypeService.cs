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
    public class ClientTypeService : IClientTypeService
    {
        private readonly IClientTypeRepository _clientTypeRepository;
        private readonly IRepository _repo;
        private readonly IMapper _mapper;

        public ClientTypeService(IClientTypeRepository clientTypeRepository,
                              IRepository repo,
                              IMapper mapper)
        {
            _clientTypeRepository = clientTypeRepository ?? 
                throw new ArgumentNullException(nameof(clientTypeRepository));
            _repo = repo ??
                throw new ArgumentNullException(nameof(repo));
            _mapper = mapper;
        }

        public async Task CreateAsync(ClientTypeDTO clientTypeDto)
        {
            var clientTypeEntity = _mapper.Map<ClientType>(clientTypeDto);
            await _repo.CreateAsync(clientTypeEntity);
        }

        public async Task<ResultService<ClientTypeDTO>> GetClientTypeByIdAsync(int id)
        {
            var clientType = await _clientTypeRepository.GetClientTypeByIdAsync(id);
            return ResultService.OK(_mapper.Map<ClientTypeDTO>(clientType));
        }

        public async Task<ResultService<PagedBaseResponseDTO<ClientTypeDTO>>> GetClientTypesAsync(ClientTypeFilterDb clientTypeFilterDb)
        {
            var clientTypes = await _clientTypeRepository.GetClientsTypeAsync(clientTypeFilterDb);
            var result = new PagedBaseResponseDTO<ClientTypeDTO>(clientTypes.TotalRegisters, 
                                                              _mapper.Map<List<ClientTypeDTO>>(clientTypes.Data));

            return ResultService.OK(result);
        }

        public async Task RemoveAsync(int id)
        {
            var clientTypeEntity = _clientTypeRepository.GetClientTypeByIdAsync(id).Result;
            await _repo.RemoveAsync(clientTypeEntity);
        }

        public async Task UpdateAsync(ClientTypeDTO clientTypeDto)
        {
            var clientTypeEntity = _mapper.Map<ClientType>(clientTypeDto);
            await _repo.UpdateAsync(clientTypeEntity);
        }
    }
}