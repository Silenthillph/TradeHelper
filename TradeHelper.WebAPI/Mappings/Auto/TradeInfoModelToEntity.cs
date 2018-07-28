using AutoMapper;
using System;
using TradeHelper.EntityModel.Entities;
using TradeHelper.WebApi.Models;

namespace TradeHelper.WebApi.Mappings.Auto
{
    public class TradeInfoModelToEntity : Profile
    {
        public TradeInfoModelToEntity()
        {
            this.CreateMap<TradeInfoDto, TradeInfo>()
                .ForMember(e => e.Id, src => src.ResolveUsing(t => t.Id.GetValueOrDefault(Guid.NewGuid())))
                .ForMember(e => e.PositionType, src => src.MapFrom(s => (int)s.Type));
        }
    }
}