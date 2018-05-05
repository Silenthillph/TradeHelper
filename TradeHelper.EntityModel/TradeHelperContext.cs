using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TradeHelper.EntityModel.Entities;

namespace TradeHelper.EntityModel
{
    public class TradeHelperContext : DbContext, IDbContext
    {

        public TradeHelperContext(DbContextOptions<TradeHelperContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TradeInfo>().HasKey(t => t.Id);
        }

        public virtual DbSet<TradeInfo> TradeInfo { get; set; }

        #region Implementation of IDbContext

        public new DbSet<T> Set<T>() where T : class
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
            throw new NotImplementedException();
        }

        #endregion 
    }
}
