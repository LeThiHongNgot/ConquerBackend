using AutoMapper;
using ConquerBackend.Domain.Entities;
using ConquerBackend.Domain.Respositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ConquerBackend.Persistence.Repositories
{
    public class Repository<TEntity, TKey> : IRepository<TEntity, TKey> where TEntity : class, new()
    {
        protected readonly DbContext context;
        private readonly DbSet<TEntity> _dbSet;
        protected readonly IUnitOfWork _unitOfWork;
        public Repository(DbContext context, IUnitOfWork unitOfWork)
        {
            this.context = context;
            _dbSet = context.Set<TEntity>();
            this._unitOfWork = unitOfWork;
        }
        public IUnitOfWork UnitOfWork => _unitOfWork;
        public async Task<int> GetTotalItemsAsync(CancellationToken cancellationToken = default)
        {
            return await context.Set<TEntity>().CountAsync(cancellationToken);
        }

        public async Task<int> GetTotalItemsAsync(Expression<Func<TEntity, bool>> predicate, CancellationToken cancellationToken = default)
        {
            return await context.Set<TEntity>().CountAsync(predicate, cancellationToken);
        }

        public async Task DeleteAsync(object id, CancellationToken cancellationToken = default)
        {
            var entity = await GetSingleAsync(id, cancellationToken);
            context.Set<TEntity>().Remove(entity);
        }

        public async Task<IEnumerable<TEntity>> GetAsync(CancellationToken cancellationToken = default)
        {
            return await context.Set<TEntity>().ToListAsync(cancellationToken);
        }

        public async Task<IEnumerable<TEntity>> GetAsync(int pageIndex, int pageSize, CancellationToken cancellationToken = default)
        {
            return await context
                .Set<TEntity>()
                .Skip((pageIndex - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync(cancellationToken);
        }

        public async Task<IEnumerable<TEntity>> GetIdAsync(int pageIndex, int pageSize, int id, CancellationToken cancellationToken = default)
        {
            return await context
                .Set<TEntity>()
                .Where(entity => EF.Property<int>(entity, "Id") == id)
                .Skip((pageIndex - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync(cancellationToken);
        }

        public async Task<IEnumerable<TEntity>> GetAsync(Expression<Func<TEntity, bool>> predicate, CancellationToken cancellationToken = default)
        {
            return await context.Set<TEntity>().Where(predicate).ToListAsync(cancellationToken);
        }

        public async Task<IEnumerable<TEntity>> GetAsync(Expression<Func<TEntity, bool>> predicate, int pageIndex, int pageSize, CancellationToken cancellationToken = default)
        {
            return await context
                .Set<TEntity>()
                .Where(predicate)
                .Skip((pageIndex - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync(cancellationToken);
        }

        public async Task<TEntity> GetSingleAsync(object id, CancellationToken cancellationToken = default)
        {
            return await context.Set<TEntity>().FindAsync(new object[] { id }, cancellationToken);
        }

        public async Task<TEntity> GetSingleAsync(Expression<Func<TEntity, bool>> predicate, CancellationToken cancellationToken = default)
        {
            return await context.Set<TEntity>().FirstOrDefaultAsync(predicate, cancellationToken);
        }

        public async Task<TKey> InsertAsync(TEntity entity, CancellationToken cancellationToken = default)
        {
            var entry = await context.Set<TEntity>().AddAsync(entity, cancellationToken);
            return (TKey)entry.Property("Id").CurrentValue;
        }

        public void Update(TEntity entity)
        {
            context.Set<TEntity>().Update(entity);
        }

        public IQueryable<TEntity> GetAll() => _dbSet.AsQueryable();
        public IQueryable<TEntity> Find(Expression<Func<TEntity, bool>> predicate) => _dbSet.Where(predicate);
    }


}

