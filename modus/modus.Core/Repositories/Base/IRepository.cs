using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace modus.Core.Repositories.Base
{
    public interface IRepository<TEntity> where TEntity : class
    {
        Task<TEntity> InsertRecordAsnyc(string table, TEntity record);
        Task<List<TEntity>> LoadRecordsAsnyc(string table);
        Task<TEntity> LoadRecordByIdAsync(string table, string id);
        Task<TEntity> UpsertRecordAsync(string table, string id, TEntity record);
        Task<DeleteResult> DeleteRecordAsync(string table, string id);
    }
}
