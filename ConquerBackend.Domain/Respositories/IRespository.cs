﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ConquerBackend.Domain.Respositories
{
    public interface IRepository<TEntity> where TEntity : class, new()
    {
        Task<IEnumerable<TEntity>> GetAsync(CancellationToken cancellationToken = default);
        Task<IEnumerable<TOut>> GetAsync<TOut>(CancellationToken cancellationToken = default);
        Task<IEnumerable<TEntity>> GetAsync(int pageIndex, int pageSize, CancellationToken cancellationToken = default);
        Task<IEnumerable<TOut>> GetAsync<TOut>(int? pageIndex, int? pageSize, CancellationToken cancellationToken = default);
        Task<IEnumerable<TEntity>> GetIdAsync(int pageIndex, int pageSize, int id, CancellationToken cancellationToken = default);
        Task<IEnumerable<TEntity>> GetAsync(Expression<Func<TEntity, bool>> predecate, CancellationToken cancellationToken = default);
        Task<IEnumerable<TOut>> GetAsync<TOut>(Expression<Func<TEntity, bool>> predecate, CancellationToken cancellationToken = default);
        Task<IEnumerable<TEntity>> GetAsync(Expression<Func<TEntity, bool>> predecate, int pageIndex, int pageSize, CancellationToken cancellationToken = default);
        Task<IEnumerable<TOut>> GetAsync<TOut>(Expression<Func<TEntity, bool>> predecate, int pageIndex, int pageSize, CancellationToken cancellationToken = default);

        Task<TEntity> GetSingleAsync(object id, CancellationToken cancellationToken = default);
        Task<TOut> GetSingleAsync<TOut>(object id, CancellationToken cancellationToken = default);
        Task<TEntity> GetSingleAsync(Expression<Func<TEntity, bool>> predecate, CancellationToken cancellationToken = default);
        Task<TOut> GetSingleAsync<TOut>(Expression<Func<TEntity, bool>> predecate, CancellationToken cancellationToken = default);

        Task<int> GetTotalItemsAsync(CancellationToken cancellationToken = default);
        Task<int> GetTotalItemsAsync(Expression<Func<TEntity, bool>> predecate, CancellationToken cancellationToken = default);

        Task InsertAsync(TEntity entity, CancellationToken cancellationToken = default);
        Task DeleteAsync(object id, CancellationToken cancellationToken = default);

        void Update(TEntity entity);

        IQueryable<TEntity> GetAll();
        IQueryable<TEntity> Find(Expression<Func<TEntity, bool>> predicate);
    }

}
