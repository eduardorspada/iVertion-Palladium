using AutoMapper;
using iVertion.Application.DTOs;
using iVertion.Application.Interfaces;
using iVertion.Domain.Entities;
using iVertion.Domain.FiltersDb;
using iVertion.Domain.Interfaces;

namespace iVertion.Application.Services
{
    public class RoleProfileService : IRoleProfileService
    {
        private readonly IRoleProfileRepository _roleProfileRepository;
        private readonly IRepository _repo;
        private readonly IMapper _mapper;
        public RoleProfileService(IRoleProfileRepository roleProfileRepository,
                                  IRepository repo,
                                  IMapper mapper)
        {
            _roleProfileRepository = roleProfileRepository ?? 
                throw new ArgumentNullException(nameof(roleProfileRepository));
            _repo = repo ??
                throw new ArgumentNullException(nameof(repo));
            _mapper = mapper;
        }
        public async Task CreateRoleProfileAsync(RoleProfileDTO roleProfileDto)
        {
            var roleProfileEntity = _mapper.Map<RoleProfile>(roleProfileDto);
            await _repo.CreateAsync(roleProfileEntity);
        }

        public async Task<ResultService<RoleProfileDTO>> GetRoleProfileByIdAsync(int id)
        {
            var roleProfile = await _roleProfileRepository.GetRoleProfileByIDAsync(id);
            return ResultService.OK(_mapper.Map<RoleProfileDTO>(roleProfile));
        }

        public async Task<ResultService<PagedBaseResponseDTO<RoleProfileDTO>>> GetRoleProfilesAsync(RoleProfileFilterDb roleProfileFilterDb)
        {
            var roleProfiles = await _roleProfileRepository.GetRoleProfilesAsync(roleProfileFilterDb);
            var result = new PagedBaseResponseDTO<RoleProfileDTO>(
                roleProfiles.TotalRegisters, 
                _mapper.Map<List<RoleProfileDTO>>(roleProfiles.Data)
            );

            return ResultService.OK(result);
        }

        public async Task RemoveRoleProfileAsync(int id)
        {
            var roleProfileEntity = _roleProfileRepository.GetRoleProfileByIDAsync(id).Result;
            await _repo.RemoveAsync(roleProfileEntity);
        }

        public async Task UpdateRoleProfileAsync(RoleProfileDTO roleProfileDto)
        {
            var roleProfileEntity = _mapper.Map<RoleProfile>(roleProfileDto);
            await _repo.UpdateAsync(roleProfileEntity);
        }

    }
}