using System.Collections.Generic;
using System.Threading.Tasks;
using WokerCloud.Models;
using WokerCloud.Repositories;

namespace WokerCloud.Services
{
    public class UserRepository : IUserRepository
    {
        private readonly IRepository<User> _userRepository;

        public UserRepository(IRepository<User> userRepository) => _userRepository = userRepository;

        public async Task<IEnumerable<User>> GetAllAsync() => await _userRepository.GetAllAsync();
    }
}