using AutoMapper;
using EntityModel;
using TradeHelper.Helpers;
using TradeHelper.Models.DTO;

namespace TradeHelper.Mappings.Auto
{
    public class EntityToTradeInfoModel: Profile
    {
        public EntityToTradeInfoModel()
        {
            this.CreateMap<TradeInfo, TradeInfoModel>()
                .ForMember(e => e.Status, src => src.MapFrom(s => (PositionStatus)s.StatusId))
                .ForMember(e => e.Type, src => src.MapFrom(s => (PositionType)s.PositionId));
        }
    }
}