using System.Collections.Generic;
using TradeHelper.Cqrs.Command.Interfaces;

namespace TradeHelper.Models.Commands
{
    public class RemoveTradeInfoCommand: ICommand
    {
        public List<int> ItemsToRemove { get; set; }

        public RemoveTradeInfoCommand()
        {
            this.ItemsToRemove = new List<int>();
        }
    }
}