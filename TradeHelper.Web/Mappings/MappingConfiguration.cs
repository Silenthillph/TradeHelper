using AutoMapper;
using TradeHelper.Web.Mappings.Auto;

namespace TradeHelper.Web.Mappings
{
    public static class MappingConfiguration
    {
        public static void Configure()
        {
            Mapper.Initialize(x =>
                              {
                                  x.AddProfile<EntityToTradeInfoModel>();
                                  x.AddProfile<TradeInfoModelToEntity>();
                              });

            Mapper.AssertConfigurationIsValid();
        }
    }
}