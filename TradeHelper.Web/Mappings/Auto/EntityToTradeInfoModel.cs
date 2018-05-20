using AutoMapper;
using TradeHelper.BLL.Common;
using TradeHelper.EntityModel.Entities;
using TradeHelper.Web.Models;

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