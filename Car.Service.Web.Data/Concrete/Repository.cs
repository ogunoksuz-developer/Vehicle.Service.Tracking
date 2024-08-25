using Car.Service.Web.Data.Abstract;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Car.Service.Web.Data.Concrete
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly ServiceVehicleContext _context;
        private readonly DbSet<T> _dbSet;

        public Repository(ServiceVehicleContext context)
        {
            _context = context;
            _dbSet = _context.Set<T>();
        }

        public async Task<T> GetByIdAsync(int id)
        {
            return await _dbSet.FindAsync(id);
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await _dbSet.ToListAsync();
        }

        public async Task AddAsync(T entity)
        {
            await _dbSet.AddAsync(entity);
        }

        public void Update(T entity)
        {
            _dbSet.Update(entity);
        }

        public void Delete(T entity)
        {
            _dbSet.Remove(entity);
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }

        public IQueryable<T> SearchAsync(Expression<Func<T, bool>> predicate)
        {
            return _dbSet.Where(predicate);
        }

        public async Task<IEnumerable<T>> ExecuteStoredProcedureAsync(string storedProcedure, params object[] parameters)
        {
            // Use FromSqlRaw or FromSqlInterpolated depending on your needs
            var query = _context.Set<T>().FromSqlRaw(storedProcedure, parameters);
            return await query.ToListAsync();
        }
    }

}
