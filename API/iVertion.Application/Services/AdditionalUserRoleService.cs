using AutoMapper;
using iVertion.Application.DTOs;
using iVertion.Application.Interfaces;
using iVertion.Domain.Entities;
using iVertion.Domain.FiltersDb;
using iVertion.Domain.Interfaces;

namespace iVertion.Application.Services
{
    public class AdditionalUserRoleService : IAdditionalUserRoleService
    {
        private readonly IAdditionalUserRoleRepository _additionalUserRoleRepository;
        private readonly IRepository _repo;
        private readonly IMapper _mapper;
        public AdditionalUserRoleService(IAdditionalUserRoleRepository additionalUserRoleRepository,
                                        IRepository repo,
                                        IMapper mapper)
        {
            _additionalUserRoleRepository = additionalUserRoleRepository ??
                throw new ArgumentNullException(nameof(additionalUserRoleRepository));
            _repo = repo ??
                throw new ArgumentNullException(nameof(repo));
            _mapper = mapper;
        }
        public async Task CreateAdditionalUserRoleAsync(AdditionalUserRoleDTO addtionalUserRoleDto)
        {
            var addtionalUserRoleEntity = _mapper.Map<AdditionalUserRole>(addtionalUserRoleDto);
            await _repo.CreateAsync(addtionalUserRoleEntity);
        }

        public async Task<ResultService<AdditionalUserRoleDTO>> GetAdditionalUserRoleByIdAsync(int id)
        {
            var addtionalUserRole = await _additionalUserRoleRepository.GetAdditionalUserRoleByIdAsync(id);
            return ResultService.OK(_mapper.Map<AdditionalUserRoleDTO>(addtionalUserRole));
        }

        public async Task<ResultService<PagedBaseResponseDTO<AdditionalUserRoleDTO>>> GetAdditionalUserRolesAsync(AdditionalUserRoleFilterDb additionalUserRoleFilterDb)
        {
            var addtionalUserRoles = await _additionalUserRoleRepository.GetAdditionalUserRoleAsync(additionalUserRoleFilterDb);
            var result = new PagedBaseResponseDTO<AdditionalUserRoleDTO>(
                addtionalUserRoles.TotalRegisters,
                _mapper.Map<List<AdditionalUserRoleDTO>>(addtionalUserRoles.Data)
            );

            return ResultService.OK(result);
        }

        public async Task RemoveAdditionalUserRoleAsync(int id)
        {
            var additionalUserRole = _additionalUserRoleRepository.GetAdditionalUserRoleByIdAsync(id).Result;
            await _repo.RemoveAsync(additionalUserRole);
        }

        public async Task UpdateAdditionalUserRoleAsync(AdditionalUserRoleDTO additionalUserRoleDto)
        {
            var additionalUserRoleEntity = _mapper.Map<AdditionalUserRole>(additionalUserRoleDto);
            await _repo.UpdateAsync(additionalUserRoleEntity);
        }

    }
}