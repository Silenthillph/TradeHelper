using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Threading.Tasks;
using TradeHelper.EntityModel.Repositories;

namespace TradeHelper.EntityModel.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly IDbContext _ctx;
        private readonly ConcurrentDictionary<Type, object> _repositories;
        private bool _disposed;

        public UnitOfWork(IDbContext ctx)
        {
            _ctx = ctx;
            _repositories = new ConcurrentDictionary<Type, object>();
            _disposed = false;
        }

        public IRepository<TEntity> GetRepository<TEntity>() where TEntity : class
        {
            // Checks if the Dictionary Key contains the Model class
            if (_repositories.Keys.Contains(typeof(TEntity)))
            {
                // Return the repository for that Model class
                return _repositories[typeof(TEntity)] as IRepository<TEntity>;
            }

            // If the repository for that Model class doesn't exist, create it
            var repository = new Repository<TEntity>(_ctx);

            // Add it to the dictionary
            _repositories.AddOrUpdate(typeof(TEntity), repository, (k, v) => v);
            return repository;
        }

        public void Save()
        {
            _ctx.SaveChanges();

        }

        public async Task SaveAsync()
        {
            await _ctx.SaveChangesAsync();

        }

        public IEnumerable<TRecordSet> Exec<TRecordSet>(string name, params object[] parameters) where TRecordSet : class
        {
            return _ctx.Exec<TRecordSet>(name, parameters);
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                   _ctx.Dispose();
                }

                _disposed = true;
            }
        }

        public T GetContext<T>() where T : class
        {
            return (T)_ctx;
        }
    }
}
