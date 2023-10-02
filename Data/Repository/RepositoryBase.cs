using Questao5WebApi.Data.Context;
using System.Linq.Expressions;

namespace Questao5WebApi.Data.Repository
{
    public abstract class RepositoryBase<T> : IRepositoryBase<T> where T : class
    {
        protected ApiDbContext _ApiDbContext { get; set; }
        public RepositoryBase(ApiDbContext ApiDbContext)
        {
            _ApiDbContext = ApiDbContext;
        }
        public IQueryable<T> FindAll() => ApiDbContext.Set<T>().AsNoTracking();
        public IQueryable<T> FindByCondition(Expression<Func<T, bool>> expression) =>
            ApiDbContext.Set<T>().Where(expression).AsNoTracking();
        public void Create(T entity) => ApiDbContext.Set<T>().Add(entity);
        public void Update(T entity) => ApiDbContext.Set<T>().Update(entity);
        public void Delete(T entity) => ApiDbContext.Set<T>().Remove(entity);
    }
}
