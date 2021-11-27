using System.Collections.Generic;
using System.Threading.Tasks;
using WokerCloud.Models;

namespace WokerCloud.Services
{
    public interface IUserRepository
    {
         Task<IEnumerable<User>> GetAllAsync();
    }
}