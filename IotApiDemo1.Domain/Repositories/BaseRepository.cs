using IotApiDemo1.Domain.Data;
using IotApiDemo1.Domain.Repositories.Interfaces;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace IotApiDemo1.Domain.Repositories
{
    public class BaseRepository<TEntity> : IBaseRepository<TEntity> where TEntity : class
    {
        private readonly IMongoDatabase _database;
        private readonly IMongoCollection<TEntity> _collection;

        public BaseRepository(IOptions<DatabaseSetting> options, string collectionName)
        {
            var client = new MongoClient(options.Value.ConnectionString);
            _database = client.GetDatabase(options.Value.DatabaseName);
            _collection = _database.GetCollection<TEntity>(collectionName);
        }

        public async Task<TEntity> AddAsync(TEntity entity)
        {
            await _collection.InsertOneAsync(entity);
            return entity;
        }

        public async Task<bool> DeleteAsync(string id)
        {
            var result = await _collection.DeleteOneAsync(Builders<TEntity>.Filter.Eq("Id", id));
            return result.DeletedCount > 0;
        }

        public async Task<List<TEntity>> GetAllAsync()
        {
            return await _collection.Find(_ => true).ToListAsync();
        }

        public async Task<TEntity> GetByIdAsync(string id)
        {
            return await _collection.Find(Builders<TEntity>.Filter.Eq("Id", id)).FirstOrDefaultAsync();
        }

        public async Task<TEntity> UpdateAsync(string id, TEntity entity)
        {
            await _collection.ReplaceOneAsync(Builders<TEntity>.Filter.Eq("Id", id), entity);
            return entity;
        }

        public IMongoCollection<TEntity> GetCollection() => _collection;
    }
}
