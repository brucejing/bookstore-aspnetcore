using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookStore.Core.Domain;

namespace BookStore.Core.Repositories
{
    /// <summary>
    /// This interface is implemented by all repositories.
    /// </summary>
    /// <typeparam name="TEntity">Main Entity type this repository works on</typeparam>
    /// <typeparam name="TPrimaryKey">Primary key type of the entity</typeparam>
    public interface IRepository<TEntity, in TPrimaryKey> where TEntity : IEntity<TPrimaryKey>
    {
        #region Properties

        /// <summary>
        /// Gets a table
        /// </summary>
        IQueryable<TEntity> Table { get; }

        /// <summary>
        /// Gets a table with "no tracking" enabled (EF feature).
        /// Use it only when you load record(s) only for read-only operations.
        /// </summary>
        IQueryable<TEntity> TableNoTracking { get; }

        #endregion

        #region Sync Methods

        TEntity GetById(TPrimaryKey id);

        List<TEntity> GetAll();

        bool Exists(TPrimaryKey id);

        TEntity Insert(TEntity entity);

        void Insert(IEnumerable<TEntity> entities);

        void Update(TEntity entity);

        void Update(IEnumerable<TEntity> entities);

        void Delete(TEntity entity);

        void Delete(IEnumerable<TEntity> entities);

        #endregion

        #region Async Methods

        Task<TEntity> GetByIdAsync(TPrimaryKey id);

        Task<List<TEntity>> GetAllAsync();

        Task<bool> ExistsAsync(TPrimaryKey id);

        Task<TEntity> InsertAsync(TEntity entity);

        Task UpdateAsync(TEntity entity);

        Task DeleteAsync(TEntity entity);

        #endregion
    }
}
