using AutoMapper;
using PopulateHtmlDataApi.DAL.Entities;
using PopulateHtmlDataApi.DAL.Repositories.Interfaces;
using PopulateHtmlDataApi.Models.RequestViewModels;
using PopulateHtmlDataApi.Models.ResponseViewModels;
using PopulateHtmlDataApi.Services.Interfaces;

namespace PopulateHtmlDataApi.Services.Implementations
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public UserService(IMapper mapper, IUserRepository userRepository)
        {
            _userRepository = userRepository;
            _mapper=mapper;
        }

        public async Task<IEnumerable<UserResponseModel>> GetAllUsersAsync()
        {
            Task<IEnumerable<UserEntity>> allUserEntities = (Task<IEnumerable<UserEntity>>)await _userRepository.GetAllUserEntitiesAsync();
            if (allUserEntities == null) throw new Exception("No Html Templates found : ");
            IEnumerable<UserResponseModel> allUserResponseModels = _mapper.Map<IEnumerable<UserResponseModel>>(allUserEntities);
            return allUserResponseModels;
        }

        public async Task<UserResponseModel> GetUserByPolicyNumberAsync(string PolicyNumber)
        {
            UserEntity requiredUserEntity = await _userRepository.GetUserEntityByIdAsync(PolicyNumber);
            if (requiredUserEntity == null) throw new Exception("Not found");
            UserResponseModel requiredUserResponse = _mapper.Map<UserResponseModel>(requiredUserEntity);
            return requiredUserResponse;
        }

        public async Task<int> AddUserAsync(UserRequestModel user)
        {
            UserEntity userEntityToBeAdded = _mapper.Map<UserEntity>(user);
            UserEntity addedUserEntity = await _userRepository.AddUserEntityAsync(userEntityToBeAdded);
            if (addedUserEntity == null) throw new Exception("Bad Request");
            else return 1;

        }

        public async Task<int> DeleteUserAsync(string PolicyNumber)
        {
            UserEntity userEntityToBeDeleted = await _userRepository.DeleteUserEntityAsync(PolicyNumber);
            if (userEntityToBeDeleted == null) throw new Exception("Not Found");
            else return 1;
        }

        public async Task<int> UpdateUserAsync(UserRequestModel user)
        {
            UserEntity userToBeUpdated = _mapper.Map<UserEntity>(user);
            UserEntity updatedUser = await _userRepository.UpdateUserEntityAsync(userToBeUpdated);
            if (updatedUser == null) throw new Exception("Not Found");
            else return 1;
        }

    }
}
