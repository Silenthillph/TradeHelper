using AutoMapper;
using TradeHelper.EntityModel.Entities;
using TradeHelper.WebApi.Models;

namespace TradeHelper.WebApi.Mappings.Auto
{
    public class TradeInfoModelToEntity: Profile
    {
        public TradeInfoModelToEntity()
        {
            this.CreateMap<TradeInfoModel, TradeInfo>()
                .ForMember(e => e.Status, src => src.MapFrom(s => (int)s.Status))
                .ForMember(e => e.PositionType, src => src.MapFrom(s => (int)s.Type));
        }
    }
}