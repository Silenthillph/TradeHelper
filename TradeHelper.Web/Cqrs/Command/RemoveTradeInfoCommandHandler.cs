using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TradeHelper.EntityModel.Entities;
using TradeHelper.EntityModel.Repositories;
using TradeHelper.EntityModel.UnitOfWork;
using TradeHelper.Web.Cqrs.Command.Interfaces;
using TradeHelper.Web.Models.Commands;

namespace TradeHelper.Web.Cqrs.Command
{
    public class RemoveTradeInfoCommandHandler: ICommandHandler<RemoveTradeInfoCommand>
    {
        private readonly IRepository<TradeInfo> _repository;
        private readonly IUnitOfWork _unitOfWork;

        public RemoveTradeInfoCommandHandler(IUnitOfWork unitOfWork)
        {
            this._unitOfWork = unitOfWork;
            this._repository = unitOfWork.GetRepository<TradeInfo>();
        }

        #region Implementation of ICommandHandler<in RemoveTradeInfoCommand>

        public async Task<CommandResult> Execute(RemoveTradeInfoCommand command)
        {
            if (command == null || !command.ItemsToRemove.Any())
            {
                throw new ArgumentException(nameof(command));
            }

            try
            {
                var itemsToRemove = await this._repository.FindQueryable(t => command.ItemsToRemove.Contains(t.Id)).ToListAsync();
                _repository.DeleteAll(itemsToRemove);
                await _unitOfWork.SaveAsync();

                return new CommandResult
                       {
                           Success = true
                       };
            }
            catch (Exception ex)
            {
                return new CommandResult
                       {
                           Success = false,
                           Message = ex.Message,
                           Data = ex
                       };
            }
        }

        #endregion
    }
}