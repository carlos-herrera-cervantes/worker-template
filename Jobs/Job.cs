using System;
using System.Threading.Tasks;
using Coravel.Invocable;
using WokerCloud.Services;

namespace WokerCloud.Jobs
{
    public class Job : IInvocable
    {
        private readonly IUserRepository _userRepository;

        public Job(IUserRepository userRepository) => _userRepository = userRepository;

        public async Task Invoke()
        {
            var users = await _userRepository.GetAllAsync();

            foreach (var user in users)
            {
                Console.Write(user.Email);
            }
        }
    }
}