using AutoMapper;
using iVertion.Application.DTOs;
using iVertion.Application.Interfaces;
using iVertion.Domain.Entities;
using iVertion.Domain.FiltersDb;
using iVertion.Domain.Interfaces;

namespace iVertion.Application.Services
{
    public class UserProfileService : IUserProfileService
    {
        private readonly IUserProfileRepository _userProfileRepository;
        private readonly IRepository _repo;
        private readonly IMapper _mapper;

        public UserProfileService(IUserProfileRepository userProfileRepository,
                                  IRepository repo,
                                  IMapper mapper)
        {
            _userProfileRepository = userProfileRepository ??
                throw new ArgumentNullException(nameof(userProfileRepository));
            _repo = repo ??
                throw new ArgumentNullException(nameof(repo));
            _mapper = mapper;
        }

        public async Task CreateUserProfileAsync(UserProfileDTO userProfileDto)
        {
            var userProfileEntity = _mapper.Map<UserProfile>(userProfileDto);
            await _repo.CreateAsync(userProfileEntity);
        }

        public async Task<ResultService<UserProfileDTO>> GetUserProfileByIdAsync(int id)
        {
            var userProfile = await _userProfileRepository.GetUserProfileByIdAsync(id);
            return ResultService.OK(_mapper.Map<UserProfileDTO>(userProfile));
        }

        public async Task<ResultService<PagedBaseResponseDTO<UserProfileDTO>>> GetUserProfilesAsync(UserProfileFilterDb userProfileFilterDb)
        {
            var userProfiles = await _userProfileRepository.GetUserProfileAsync(userProfileFilterDb);
            var result = new PagedBaseResponseDTO<UserProfileDTO>(
                userProfiles.TotalRegisters,
                _mapper.Map<List<UserProfileDTO>>(userProfiles.Data)
            );

            return ResultService.OK(result);
        }

        public async Task RemoveUserProfileAsync(int id)
        {
            var userProfileEntity = _userProfileRepository.GetUserProfileByIdAsync(id).Result;
            await _repo.RemoveAsync(userProfileEntity);
        }

        public async Task UpdateUserProfileAsync(UserProfileDTO userProfileDto)
        {
            var userProfileEntity = _mapper.Map<UserProfile>(userProfileDto);
            await _repo.UpdateAsync(userProfileEntity);
        }

    }
}