using System.Threading.Tasks;
using TradeHelper.Models.Commands;

namespace TradeHelper.Cqrs.Command.Interfaces
{
    public interface ICommandHandler<in TParameter> where TParameter : ICommand
    {
        Task<CommandResult> Execute(TParameter command);
    }
}