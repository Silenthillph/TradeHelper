using System.Threading.Tasks;
using TradeHelper.Web.Models.Commands;

namespace TradeHelper.Web.Cqrs.Command.Interfaces
{
    public interface ICommandHandler<in TParameter> where TParameter : ICommand
    {
        Task<CommandResult> Execute(TParameter command);
    }
}