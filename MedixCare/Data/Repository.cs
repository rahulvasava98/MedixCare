
using MedixCare.Models;
using Microsoft.EntityFrameworkCore;

namespace MedixCare.Data
{
    public class Repository<T> : IRepository<T> where T : class
    {
        protected readonly ApplicationDbContext _context;
        private readonly DbSet<T> _dbSet;   

        public Repository(ApplicationDbContext context)
        {
            _context = context;
            _dbSet = context.Set<T>();

        }


        //public async Task<T> GetByIdAsync(int id) => await _dbSet.FindAsync(id);
        public async Task<T> GetByIdAsync(int id)
        {
         return await _dbSet.FindAsync(id);
        }


        //public async Task<IEnumerable<T>> GetAllAsync() => await _dbSet.ToListAsync();
        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await _dbSet.ToListAsync();
            
        }


        //public async Task AddAsync(T entity) => await _dbSet.AddAsync(entity);
        public async Task AddAsync(T entity)
        {
            await _dbSet.AddAsync(entity);
        }


        //public void Update(T entity) => _dbSet.Update(entity);
        public void Update(T entity)
        {
            _dbSet.Update(entity);
        }

        //public void Remove(T entity) => _dbSet.Remove(entity);
        public void Remove(T entity)
        {
            _dbSet.Remove(entity);
        }

        public IQueryable<T> Query()
        {
            return _dbSet.AsQueryable();
        }

    }
}
