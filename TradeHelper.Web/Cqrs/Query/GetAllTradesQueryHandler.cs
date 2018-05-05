using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TradeHelper.EntityModel.Entities;
using TradeHelper.EntityModel.Repositories;
using TradeHelper.EntityModel.UnitOfWork;
using TradeHelper.Web.Cqrs.Query.Interfaces;
using TradeHelper.Web.Models.DTO;
using TradeHelper.Web.Models.Queries;
using TradeHelper.Web.Models.QueryResults;

namespace TradeHelper.Web.Cqrs.Query
{
    public class GetAllTradesQueryHandler: IQueryHandler<CommonQuery, GetAllTradesQueryResult>
    {
        private readonly IRepository<TradeInfo> _tradeInfoRepository;

        public GetAllTradesQueryHandler(IUnitOfWork unitOfWork)
        {
            this._tradeInfoRepository = unitOfWork.GetRepository<TradeInfo>();
        }

        #region Implementation of IQueryHandler<in CommonQuery,GetAllTradesQueryResult>

        public async Task<GetAllTradesQueryResult> Retrieve(CommonQuery query)
        {
            var data = await this._tradeInfoRepository.AsQueryable().Select(t => t).ToListAsync();

            var queryResult = new GetAllTradesQueryResult
                              {
                                  Result = AutoMapper.Mapper.Map<IEnumerable<TradeInfoModel>>(data)
                              };

            return queryResult;
        }

        #endregion
    }
}