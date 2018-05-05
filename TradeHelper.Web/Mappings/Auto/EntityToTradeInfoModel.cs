using AutoMapper;
using TradeHelper.EntityModel.Entities;
using TradeHelper.Web.Helpers;
using TradeHelper.Web.Models.DTO;

namespace TradeHelper.Web.Mappings.Auto
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