using System.Collections.Generic;
using System.Data.Entity;
using System.Threading.Tasks;

namespace EntityModel
{
    public interface IDbContext
    {
        IDbSet<T> Set<T>() where T : class;
        void SaveChanges();
        Task SaveChangesAsync();
        IEnumerable<T> Exec<T>(string name, params object[] parameters) where T : class;
        void Dispose();
    }
}
