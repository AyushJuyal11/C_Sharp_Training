using AutoMapper;
using PolicyMailSendingAPI.DAL.Entities;
using PolicyMailSendingAPI.DAL.Repositories.Interfaces;
using PolicyMailSendingAPI.Models.RequestViewModels;
using PolicyMailSendingAPI.Services.Interfaces;

namespace PolicyMailSendingAPI.Services.Implementations
{
    public class UserService : IUserService
    {
        private readonly IMapper _mapper; 
        private readonly IUserRepository _userRepository;
        public UserService(IUserRepository userRepository , IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper =  mapper; 
        }

        public async Task<int> AddUserAsync(UserRequestModel user)
        {
            UserEntity userToAdd = _mapper.Map<UserEntity>(user);
            UserEntity addedUser = await _userRepository.AddUserAsync(userToAdd);
            if (addedUser == null) { throw new Exception("Invalid Request"); }
            else return 1; 
        }
    }
}
