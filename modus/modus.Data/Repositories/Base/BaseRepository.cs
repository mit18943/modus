using modus.Core.Data;
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

        public BaseRepository()
        {
            var client = new MongoClient("mongodb://localhost:27017");
            db = client.GetDatabase("ModusDB");
        }

        public async Task<DeleteResult> DeleteRecordAsync(string table, string id)
        {
            var collection = db.GetCollection<TEntity>(table);
            var filter = Builders<TEntity>.Filter.Eq("Id", id);
            return await collection.DeleteOneAsync(filter);
        }

        public async Task<TEntity> InsertRecordAsnyc(string table, TEntity record)
        {
            var collection = db.GetCollection<TEntity>(table);
            await collection.InsertOneAsync(record);
            return record;
        }

        public async Task<TEntity> LoadRecordByIdAsync(string table, string id)
        {
            var collection = db.GetCollection<TEntity>(table);
            var filter = Builders<TEntity>.Filter.Eq("Id", id);


            var x = await collection.Find(filter).FirstOrDefaultAsync();
            if (x is not null)
                return x;
            else
                return null;
        }

        public async Task<List<TEntity>> LoadRecordsAsnyc(string table)
        {
            var collection = db.GetCollection<TEntity>(table);

            return await collection.Find(new BsonDocument()).ToListAsync();
        }

        public async Task<TEntity> UpsertRecordAsync(string table, string id, TEntity record)
        {
            var collection = db.GetCollection<TEntity>(table);

            var filter = Builders<TEntity>.Filter.Eq("Id", id);
            return await collection.FindOneAndReplaceAsync(
                filter,
                record
                );
        }

    }
}
