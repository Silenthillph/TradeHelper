using AutoMapper;
using TradeHelper.EntityModel.Entities;
using TradeHelper.Web.Models;

namespace TradeHelper.Web.Mappings.Auto
{
    public class TradeInfoModelToEntity: Profile
    {
        public TradeInfoModelToEntity()
        {
            this.CreateMap<TradeInfoModel, TradeInfo>()
                .ForMember(e => e.StatusId, src => src.MapFrom(s => (int)s.Status))
                .ForMember(e => e.PositionId, src => src.MapFrom(s => (int)s.Type));
        }
    }
}