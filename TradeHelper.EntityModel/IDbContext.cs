using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace TradeHelper.EntityModel
{
    public interface IDbContext
    {
        DbSet<T> Set<T>() where T : class;
        void SaveChanges();
        Task SaveChangesAsync();
        IEnumerable<T> Exec<T>(string name, params object[] parameters) where T : class;
        EntityEntry Entry<T>(T entity) where T : class;
        void Dispose();
    }
}
