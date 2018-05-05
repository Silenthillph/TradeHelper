using System.Threading.Tasks;
using TradeHelper.Web.Models.Commands;

namespace TradeHelper.Web.Cqrs.Command.Interfaces
{
    public interface ICommandDispatcher
    {
        Task<CommandResult> Dispatch<TParameter>(TParameter command) where TParameter : ICommand;
    }
}