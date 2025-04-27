using System.Linq.Expressions;

namespace ConquerBackend.Domain.Respositories
{
    public interface IRepository<TEntity,TKey> where TEntity : class, new()
    {
        public IUnitOfWork UnitOfWork { get; }
        Task<IEnumerable<TEntity>> GetAsync(CancellationToken cancellationToken = default);
        Task<IEnumerable<TEntity>> GetAsync(int pageIndex, int pageSize, CancellationToken cancellationToken = default);
        Task<IEnumerable<TEntity>> GetIdAsync(int pageIndex, int pageSize, int id, CancellationToken cancellationToken = default);
        Task<IEnumerable<TEntity>> GetAsync(Expression<Func<TEntity, bool>> predecate, CancellationToken cancellationToken = default);
        Task<IEnumerable<TEntity>> GetAsync(Expression<Func<TEntity, bool>> predecate, int pageIndex, int pageSize, CancellationToken cancellationToken = default);
        Task<TEntity> GetSingleAsync(object id, CancellationToken cancellationToken = default);
        Task<TEntity> GetSingleAsync(Expression<Func<TEntity, bool>> predecate, CancellationToken cancellationToken = default);
        Task<int> GetTotalItemsAsync(CancellationToken cancellationToken = default);
        Task<int> GetTotalItemsAsync(Expression<Func<TEntity, bool>> predecate, CancellationToken cancellationToken = default);

        Task<TKey> InsertAsync(TEntity entity, CancellationToken cancellationToken = default);
        Task DeleteAsync(object id, CancellationToken cancellationToken = default);

        void Update(TEntity entity);

        IQueryable<TEntity> GetAll();
        IQueryable<TEntity> Find(Expression<Func<TEntity, bool>> predicate);
    }

}
