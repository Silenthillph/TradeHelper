using Microsoft.EntityFrameworkCore;
using TradeHelper.EntityModel;

namespace TradeHelper.WebApi.Core.Configurations
{
    public class ContextConfiguration: IContextConfiguration
    {
        private readonly TradeHelperContext _tradeHelperContext;

        public ContextConfiguration(TradeHelperContext tradeHelperContext)
        {
            _tradeHelperContext = tradeHelperContext;
        }

        public void Migrate()
        {
            _tradeHelperContext.Database.Migrate();
        }
    }
}
