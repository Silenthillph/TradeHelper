using TradeHelper.Web.Cqrs.Command.Interfaces;
using TradeHelper.Web.Models.DTO;

namespace TradeHelper.Web.Models.Commands
{
    public class AddOrUpdateTradeInfoCommand: ICommand
    {
        public TradeInfoModel Model { get; set; }
    }
}