using AutoMapper;
using TradeHelper.WebApi.Mappings.Auto;

namespace TradeHelper.WebApi.Mappings
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