using System;
using TradeHelper.Cqrs.Query.Interfaces;

namespace TradeHelper.Models.Queries
{
    public class CommonQuery: IQuery
    {
        public Guid Id { get; set; }
    }
}