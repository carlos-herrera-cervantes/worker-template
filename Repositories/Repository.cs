using System.Collections.Generic;
using System.Threading.Tasks;
using MongoDB.Driver;
using WokerCloud.Contexts;
using WokerCloud.Models;

namespace WokerCloud.Repositories
{
    public class Repository<T> : IRepository<T> where T : BaseEntity
    {
        private readonly IMongoCollection<T> _context;

        public Repository(IMongoDBSettings settings)
        {
            var client = MongoDBFactory.CreateClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.Database);
            _context = database.GetCollection<T>($"{typeof(T).Name}s");
        }

        public async Task<IEnumerable<T>> GetAllAsync() => await _context.Find(Builders<T>.Filter.Empty).ToListAsync();
    }
}