using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Data.Entity.Core;
using System.Data.Entity.Infrastructure;
using System.Threading.Tasks;
using EntityModel;

namespace Repository
{
    public class UnitOfWork<T> : IUnitOfWork where T : IDbContext
    {
        private readonly IDbContext _ctx;
        private readonly ConcurrentDictionary<Type, object> _repositories;
        private bool _disposed;

        public UnitOfWork(IDbContext ctx)
        {
            _ctx = (T)ctx;
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
            try
            {
                _ctx.SaveChanges();
            }
            catch (DbUpdateException dex)
            {
                throw new ConcurrencyException(dex.Message);
            }
            catch (OptimisticConcurrencyException ex)
            {
                throw new ConcurrencyException(ex.Message);
            }
        }

        public async Task SaveAsync()
        {
            try
            {
                await _ctx.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException dcex)
            {
                throw new ConcurrencyException(dcex.Message);
            }
            catch (OptimisticConcurrencyException ex)
            {
                throw new ConcurrencyException(ex.Message);
            }
            catch (DbUpdateException dex)
            {
                throw new ConcurrencyException(dex.Message);
            }
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

        public T1 GetContext<T1>() where T1 : class
        {
            return (T1)_ctx;
        }
    }
}
