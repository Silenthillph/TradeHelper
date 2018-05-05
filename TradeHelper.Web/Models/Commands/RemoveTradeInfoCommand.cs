using System;
using System.Collections.Generic;
using TradeHelper.Web.Cqrs.Command.Interfaces;

namespace TradeHelper.Web.Models.Commands
{
    public class RemoveTradeInfoCommand: ICommand
    {
        public List<Guid> ItemsToRemove { get; set; }

        public RemoveTradeInfoCommand()
        {
            this.ItemsToRemove = new List<Guid>();
        }
    }
}