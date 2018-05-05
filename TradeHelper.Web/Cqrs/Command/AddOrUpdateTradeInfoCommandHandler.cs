using System;
using System.Threading.Tasks;
using TradeHelper.EntityModel.Entities;
using TradeHelper.EntityModel.Repositories;
using TradeHelper.EntityModel.UnitOfWork;
using TradeHelper.Web.Cqrs.Command.Interfaces;
using TradeHelper.Web.Models.Commands;

namespace TradeHelper.Web.Cqrs.Command
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
                    this._repository.Add(item);
                }
                else
                {
                    item = AutoMapper.Mapper.Map<TradeInfo>(command.Model);
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