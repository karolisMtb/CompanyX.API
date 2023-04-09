using CompanyX.API.DataAccess.DatabaseContext;
using CompanyX.API.DataAccess.Interfaces;

namespace CompanyX.API.DataAccess.Repositories
{
    public class Repository<T> : IRepository<T> where T : class
    {
        protected readonly CompanyXDbContext _companyXDbContext;

        public Repository(CompanyXDbContext companyXDbContext)
        {
            _companyXDbContext = companyXDbContext;
        }

        public async Task AddAsync(T entity)
        {
            await _companyXDbContext.Set<T>().AddAsync(entity);
        }

        public async Task AddRangeAsync(IEnumerable<T> entities)
        {
            await _companyXDbContext.Set<T>().AddRangeAsync(entities);
        }

        public async Task DeleteAsync(T entity)
        {
            _companyXDbContext.Set<T>().Remove(entity);
        }

        public async Task DeleteRangeAsync(IEnumerable<T> entities)
        {
            _companyXDbContext.Set<T>().RemoveRange(entities);
        }

        public Task<IEnumerable<T>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public async Task UpdateAsync(T entity)
        {
            _companyXDbContext.Set<T>().Update(entity);
        }

    }
}
