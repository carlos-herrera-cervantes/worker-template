using System.Collections.Generic;
using System.Threading.Tasks;
using WokerCloud.Models;

namespace WokerCloud.Repositories
{
    public interface IRepository<T> where T : BaseEntity
    {
         Task<IEnumerable<T>> GetAllAsync();
    }
}