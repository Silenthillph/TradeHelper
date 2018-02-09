using TradeHelper.Cqrs.Command.Interfaces;
using TradeHelper.Models.DTO;

namespace TradeHelper.Models.Commands
{
    public class AddOrUpdateTradeInfoCommand: ICommand
    {
        public TradeInfoModel Model { get; set; }
    }
}