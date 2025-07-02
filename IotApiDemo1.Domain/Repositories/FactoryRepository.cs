using IotApiDemo1.Domain.Data;
using IotApiDemo1.Domain.Models;
using IotApiDemo1.Domain.Repositories.Interfaces;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace IotApiDemo1.Domain.Repositories
{
    public class FactoryRepository : IFactoryRepository
    {
        private readonly IMongoCollection<Factory> _collection;

        public FactoryRepository(IOptions<DatabaseSetting> options)
        {
            var client = new MongoClient(options.Value.ConnectionString);
            var database = client.GetDatabase(options.Value.DatabaseName);
            _collection = database.GetCollection<Factory>("Factories");
        }

        public async Task<List<Factory>> GetAllAsync()
        {
            return await _collection.Find(_ => true).ToListAsync();
        }

        public async Task<Factory?> GetByIdAsync(string id)
        {
            return await _collection.Find(f => f.Id == id).FirstOrDefaultAsync();
        }

        public async Task AddAsync(Factory factory)
        {
            await _collection.InsertOneAsync(factory);
        }

        public async Task UpdateAsync(string id, Factory factory)
        {
            await _collection.ReplaceOneAsync(f => f.Id == id, factory);
        }

        public async Task DeleteAsync(string id)
        {
            await _collection.DeleteOneAsync(f => f.Id == id);
        }
    }
}
