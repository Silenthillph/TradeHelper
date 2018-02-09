using AutoMapper;
using TradeHelper.Mappings.Auto;

namespace TradeHelper.Mappings
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