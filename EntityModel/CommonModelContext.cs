using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Threading.Tasks;

namespace EntityModel
{
    public partial class CommonModelContext: IDbContext
    {
        #region Implementation of IDbContext

        public new IDbSet<T> Set<T>() where T : class
        {
            return base.Set<T>();
        }

        void IDbContext.SaveChanges()
        {
            base.SaveChanges();
        }

        async Task IDbContext.SaveChangesAsync()
        {
            await base.SaveChangesAsync();
        }

        public IEnumerable<T> Exec<T>(string name, params object[] parameters) where T : class
        {
            var methodInfo = this.GetType().GetMethod(name);
            if (methodInfo != null)
            {
                return (IEnumerable<T>)methodInfo.Invoke(this, parameters);
            }

            var context = ((IObjectContextAdapter)this).ObjectContext;
            return context.ExecuteStoreQuery<T>($"EXEC {name}", parameters);
        }

        #endregion
    }
}
