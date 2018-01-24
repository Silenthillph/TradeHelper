using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using EntityModel;

namespace Repository
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly IDbContext _context;
        private readonly IDbSet<T> _dbSet;

        public Repository(IDbContext context)
        {
            _context = context;
            _dbSet = context.Set<T>();
        }

        public virtual IEnumerable<T> GetAll()
        {
            return _dbSet;
        }

        public IEnumerable<T> Find(Expression<Func<T, bool>> predicate)
        {
            var query = _dbSet.Where(predicate);

            return query;
        }

        public async Task<IEnumerable<T>> FindAsync(Expression<Func<T, bool>> predicate)
        {
            return await _dbSet.Where(predicate).ToListAsync();
        }

        public IQueryable<T> FindQueryable(Expression<Func<T, bool>> predicate)
        {
            return _dbSet.Where(predicate);
        }

        public T FindEntity(params object[] primaryKeys)
        {
            return _dbSet.Find(primaryKeys);
        }

        public async Task<T> FindEntityAsync(params object[] primaryKeys)
        {
            return await ((DbSet<T>)_dbSet).FindAsync(primaryKeys);
        }

        public T FirstOrDefault(Expression<Func<T, bool>> predicate)
        {
            return _dbSet.FirstOrDefault(predicate);
        }

        public async Task<T> FirstOrDefaultAsync(Expression<Func<T, bool>> predicate)
        {
            return await _dbSet.FirstOrDefaultAsync(predicate);
        }

        public T First(Expression<Func<T, bool>> predicate)
        {
            return _dbSet.First(predicate);
        }

        public async Task<T> FirstAsync(Expression<Func<T, bool>> predicate)
        {
            return await _dbSet.FirstAsync(predicate);
        }

        public IQueryable<T> AsQueryable()
        {
            return _dbSet.AsQueryable();
        }

        public virtual void Add(T entity)
        {
            _dbSet.Add(entity);
        }

        public virtual void Delete(T entity)
        {
            _dbSet.Remove(entity);
        }

        public virtual void DeleteAll(IEnumerable<T> entity)
        {
            foreach (var ent in entity.ToList())
            {
                _dbSet.Remove(ent);
            }
        }

        public virtual void Update(T entity)
        {
            _dbSet.Attach(entity);
        }

        public IQueryable<T> Include(string path)
        {
            return _dbSet.Include(path);
        }

        public virtual bool Any()
        {
            return _dbSet.Any();
        }

        public async Task<bool> AnyAsync()
        {
            return await _dbSet.AnyAsync();
        }
    }
}
