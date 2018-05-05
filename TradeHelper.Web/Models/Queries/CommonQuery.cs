using System;
using TradeHelper.Web.Cqrs.Query.Interfaces;

namespace TradeHelper.Web.Models.Queries
{
    public class CommonQuery: IQuery
    {
        public Guid Id { get; set; }
    }
}