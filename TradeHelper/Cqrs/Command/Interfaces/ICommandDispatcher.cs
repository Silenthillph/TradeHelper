using System.Threading.Tasks;
using TradeHelper.Models.Commands;

namespace TradeHelper.Cqrs.Command.Interfaces
{
    public interface ICommandDispatcher
    {
        Task<CommandResult> Dispatch<TParameter>(TParameter command) where TParameter : ICommand;
    }
}