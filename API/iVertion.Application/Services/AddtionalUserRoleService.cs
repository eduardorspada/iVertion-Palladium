using AutoMapper;
using iVertion.Application.DTOs;
using iVertion.Application.Interfaces;
using iVertion.Domain.Entities;
using iVertion.Domain.FiltersDb;
using iVertion.Domain.Interfaces;

namespace iVertion.Application.Services
{
    public class AddtionalUserRoleService : IAddtionalUserRoleService
    {
        private readonly IAddtionalUserRoleRepository _addtionalUserRoleRepository;
        private readonly IRepository _repo;
        private readonly IMapper _mapper;
        public AddtionalUserRoleService(IAddtionalUserRoleRepository addtionalUserRoleRepository,
                                        IRepository repo,
                                        IMapper mapper)
        {
            _addtionalUserRoleRepository = addtionalUserRoleRepository ??
                throw new ArgumentNullException(nameof(addtionalUserRoleRepository));
            _repo = repo ??
                throw new ArgumentNullException(nameof(repo));
            _mapper = mapper;
        }
        public async Task CreateAddtionalUserRoleAsync(AddtionalUserRoleDTO addtionalUserRoleDto)
        {
            var addtionalUserRoleEntity = _mapper.Map<AddtionalUserRole>(addtionalUserRoleDto);
            await _repo.CreateAsync(addtionalUserRoleEntity);
        }

        public async Task<ResultService<AddtionalUserRoleDTO>> GetAddtionalUserRoleByIdAsync(int id)
        {
            var addtionalUserRole = await _addtionalUserRoleRepository.GetAddtionalUserRoleByIdAsync(id);
            return ResultService.OK(_mapper.Map<AddtionalUserRoleDTO>(addtionalUserRole));
        }

        public async Task<ResultService<PagedBaseResponseDTO<AddtionalUserRoleDTO>>> GetAddtionalUserRolesAsync(AddtionalUserRoleFilterDb addtionalUserRoleFilterDb)
        {
            var addtionalUserRoles = await _addtionalUserRoleRepository.GetAddtionalUserRoleAsync(addtionalUserRoleFilterDb);
            var result = new PagedBaseResponseDTO<AddtionalUserRoleDTO>(
                addtionalUserRoles.TotalRegisters,
                _mapper.Map<List<AddtionalUserRoleDTO>>(addtionalUserRoles.Data)
            );

            return ResultService.OK(result);
        }

        public async Task RemoveAddtionalUserRoleAsync(int id)
        {
            var addtionalUserRole = _addtionalUserRoleRepository.GetAddtionalUserRoleByIdAsync(id).Result;
            await _repo.RemoveAsync(addtionalUserRole);
        }

        public async Task UpdateAddtionalUserRoleAsync(AddtionalUserRoleDTO addtionalUserRoleDto)
        {
            var addtionalUserRoleEntity = _mapper.Map<AddtionalUserRole>(addtionalUserRoleDto);
            await _repo.UpdateAsync(addtionalUserRoleEntity);
        }

    }
}