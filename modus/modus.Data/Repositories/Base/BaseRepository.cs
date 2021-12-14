using modus.Core.Repositories.Base;
using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace modus.Data.Repositories.Base
{
    public class BaseRepository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        protected readonly IMongoDatabase db;

        public BaseRepository(string database)
        {
            var client = new MongoClient();
            db = client.GetDatabase(database);
        }

        public async Task<IAsyncResult> DeleteRecordAsync(string table, Guid id)
        {
            var collection = db.GetCollection<TEntity>(table);
            var filter = Builders<TEntity>.Filter.Eq("Id", id);
            return (IAsyncResult) await collection.DeleteOneAsync(filter);
        }

        public async Task<TEntity> InsertRecordAsnyc(string table, TEntity record)
        {
            var collection = db.GetCollection<TEntity>(table);
            await collection.InsertOneAsync(record);
            return record;
        }

        public async Task<TEntity> LoadRecordByIdAsync(string table, Guid id)
        {
            var collection = db.GetCollection<TEntity>(table);
            var filter = Builders<TEntity>.Filter.Eq("Id", id);

            return await collection.Find(filter).FirstAsync();
        }

        public async Task<List<TEntity>> LoadRecordsAsnyc(string table)
        {
            var collection = db.GetCollection<TEntity>(table);

            return await collection.Find(new BsonDocument()).ToListAsync();
        }

        [Obsolete]
        public async Task<IAsyncResult> UpsertRecordAsync(string table, Guid id, TEntity record)
        {
            var collection = db.GetCollection<TEntity>(table);

            return (IAsyncResult) await collection.ReplaceOneAsync(
                new BsonDocument("_id", id),
                record,
                new UpdateOptions { IsUpsert = true }
                );
        }
    }
}
