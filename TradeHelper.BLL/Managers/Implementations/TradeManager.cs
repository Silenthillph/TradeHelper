using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TradeHelper.BLL.Managers.Interfaces;
using TradeHelper.EntityModel.Entities;
using TradeHelper.EntityModel.Repositories;
using TradeHelper.EntityModel.UnitOfWork;

namespace TradeHelper.BLL.Managers.Implementations
{
    public class TradeManager: ITradeManager
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IRepository<TradeInfo> _repository;

        public TradeManager(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            _repository = _unitOfWork.GetRepository<TradeInfo>();
        }

        public async Task<IEnumerable<TradeInfo>> GetAllTrades()
        {
            List<TradeInfo> data = await this._repository.AsQueryable().Select(t => t).ToListAsync();
            return data;
        }

        public async Task<bool> Remove(List<Guid> items)
        {
            try
            {
                var itemsToRemove =
                    await this._repository.FindQueryable(t => items.Contains(t.Id)).ToListAsync();
                _repository.DeleteAll(itemsToRemove);
                await _unitOfWork.SaveAsync();

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public async Task<TradeInfo> AddOrUpdate(TradeInfo tradeInfo)
        {
            TradeInfo item = await this._repository.FirstOrDefaultAsync(t => t.Id == tradeInfo.Id);
            if (item == null)
            {
                _repository.Add(tradeInfo);
            }
            else
            {
                _repository.Update(tradeInfo);
            }

            await this._unitOfWork.SaveAsync();

            return tradeInfo;
        }
    }
}
