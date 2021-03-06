﻿using AutoMapper;
using TradeHelper.BLL.Common;
using TradeHelper.EntityModel.Entities;
using TradeHelper.WebApi.Models;

namespace TradeHelper.WebApi.Mappings.Auto
{
    public class EntityToTradeInfoModel: Profile
    {
        public EntityToTradeInfoModel()
        {
            this.CreateMap<TradeInfo, TradeInfoModel>()
                .ForMember(e => e.Status, src => src.MapFrom(s => (PositionStatus)s.Status))
                .ForMember(e => e.Type, src => src.MapFrom(s => (PositionType)s.PositionType))
                .ForMember(e => e.Summary, src => src.Ignore());                          
        }
    }
}