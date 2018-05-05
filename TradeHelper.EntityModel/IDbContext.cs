using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace TradeHelper.EntityModel
{
    public interface IDbContext
    {
        DbSet<T> Set<T>() where T : class;
        void SaveChanges();
        Task SaveChangesAsync();
        IEnumerable<T> Exec<T>(string name, params object[] parameters) where T : class;
        void Dispose();
    }
}
