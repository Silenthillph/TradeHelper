using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using EntityModel;
using Repository;
using TradeHelper.Cqrs.Command.Interfaces;
using TradeHelper.Models.Commands;

namespace TradeHelper.Cqrs.Command
{
    public class AddOrUpdateTradeInfoCommandHandler: ICommandHandler<AddOrUpdateTradeInfoCommand>
    {
        private readonly IRepository<TradeInfo> _repository;
        private readonly IUnitOfWork _unitOfWork;

        public AddOrUpdateTradeInfoCommandHandler(IUnitOfWork unitOfWork)
        {
            this._unitOfWork = unitOfWork;
            this._repository = unitOfWork.GetRepository<TradeInfo>();
        }

        #region Implementation of ICommandHandler<in AddOrUpdateTradeInfoCommand>

        public async Task<CommandResult> Execute(AddOrUpdateTradeInfoCommand command)
        {
            if (command?.Model == null)
            {
                throw new ArgumentException(nameof(command));
            }
            try
            {
                // check if item exists
                TradeInfo item = await this._repository.FirstOrDefaultAsync(t => t.Id == command.Model.Id);
                if (item == null)
                {
                    item = AutoMapper.Mapper.Map<TradeInfo>(command.Model);
                    var lastItemId = await this._repository.AsQueryable().Select(t => t.Id).DefaultIfEmpty(0).MaxAsync();
                    item.Id = lastItemId + 1;
                    this._repository.Add(item);
                }
                else
                {
                    item = AutoMapper.Mapper.Map<TradeInfo>(command.Model);
                    this._repository.Update(item);
                }

                await this._unitOfWork.SaveAsync();
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