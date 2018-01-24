using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Repository
{
    public interface IUnitOfWork : IDisposable
    {
        IRepository<TEntity> GetRepository<TEntity>() where TEntity : class;
        void Save();
        Task SaveAsync();
        IEnumerable<TRecordSet> Exec<TRecordSet>(string name, params object[] parameters) where TRecordSet : class;
        T GetContext<T>() where T : class;
        void Dispose();
    }
}
