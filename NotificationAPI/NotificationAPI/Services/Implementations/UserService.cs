using AutoMapper;
using NotificationAPI.DAL.Entities;
using NotificationAPI.DAL.Repositories.Interfaces;
using NotificationAPI.Models.RequestViewModels;
using NotificationAPI.Services.Interfaces;

namespace NotificationAPI.Services.Implementations
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
            User userToAdd = _mapper.Map<User>(user);
            User addedUser = await _userRepository.AddUserAsync(userToAdd);
            if (addedUser == null) { throw new Exception("Invalid Request"); }
            else return 1; 
        }
    }
}
