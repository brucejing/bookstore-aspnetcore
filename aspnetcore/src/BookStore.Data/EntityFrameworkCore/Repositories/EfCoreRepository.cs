using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookStore.Core.Domain;
using BookStore.Core.Repositories;

namespace BookStore.Data.EntityFrameworkCore.Repositories
{
    /// <summary>
    /// Implements <see cref="IRepository{TEntity,TPrimaryKey}"/> for Entity Framework Core.
    /// </summary>
    /// <typeparam name="TEntity">Type of the Entity for this repository</typeparam>
    /// <typeparam name="TPrimaryKey">Primary key of the entity</typeparam>
    public class EfCoreRepository<TEntity, TPrimaryKey> : IRepository<TEntity, TPrimaryKey> where TEntity : class, IEntity<TPrimaryKey>
    {
        private readonly BookStoreDbContext _dbContext;
        private DbSet<TEntity> _entities;

        public EfCoreRepository(BookStoreDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        #region Properties

        public virtual IQueryable<TEntity> Table => Entities;

        public virtual IQueryable<TEntity> TableNoTracking => Entities.AsNoTracking();

        protected virtual DbSet<TEntity> Entities
        {
            get { return _entities ??= _dbContext.Set<TEntity>(); }
        }

        #endregion

        #region Sync Methods

        public virtual TEntity GetById(TPrimaryKey id)
        {
            return Entities.Find(id);
        }

        public virtual List<TEntity> GetAll()
        {
            return Entities.ToList();
        }

        public virtual bool Exists(TPrimaryKey id)
        {
            return GetById(id) != null;
        }

        public virtual TEntity Insert(TEntity entity)
        {
            if (entity == null)
                throw new ArgumentNullException(nameof(entity));

            Entities.Add(entity);
            _dbContext.SaveChanges();

            return entity;
        }

        public virtual void Insert(IEnumerable<TEntity> entities)
        {
            if (entities == null)
                throw new ArgumentNullException(nameof(entities));

            Entities.AddRange(entities);
            _dbContext.SaveChanges();
        }

        public virtual void Update(TEntity entity)
        {
            if (entity == null)
                throw new ArgumentNullException(nameof(entity));

            Entities.Update(entity);
            _dbContext.SaveChanges();
        }

        public virtual void Update(IEnumerable<TEntity> entities)
        {
            if (entities == null)
                throw new ArgumentNullException(nameof(entities));

            Entities.UpdateRange(entities);
            _dbContext.SaveChanges();
        }

        public virtual void Delete(TEntity entity)
        {
            if (entity == null)
                throw new ArgumentNullException(nameof(entity));

            Entities.Remove(entity);
            _dbContext.SaveChanges();
        }

        public virtual void Delete(IEnumerable<TEntity> entities)
        {
            if (entities == null)
                throw new ArgumentNullException(nameof(entities));

            Entities.RemoveRange(entities);
            _dbContext.SaveChanges();
        }

        #endregion

        #region Async Methods

        public virtual async Task<TEntity> GetByIdAsync(TPrimaryKey id)
        {
            return await Entities.FindAsync(id);
        }

        public virtual async Task<List<TEntity>> GetAllAsync()
        {
            return await Entities.ToListAsync();
        }

        public virtual async Task<bool> ExistsAsync(TPrimaryKey id)
        {
            return await GetByIdAsync(id) != null;
        }

        public virtual async Task<TEntity> InsertAsync(TEntity entity)
        {
            await Entities.AddAsync(entity);
            await _dbContext.SaveChangesAsync();

            return entity;
        }

        public virtual async Task UpdateAsync(TEntity entity)
        {
            _dbContext.Entry(entity).State = EntityState.Modified;
            await _dbContext.SaveChangesAsync();
        }

        public virtual async Task DeleteAsync(TEntity entity)
        {
            Entities.Remove(entity);
            await _dbContext.SaveChangesAsync();
        }

        #endregion
    }
}
