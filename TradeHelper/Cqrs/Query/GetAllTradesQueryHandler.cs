using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using EntityModel;
using Repository;
using TradeHelper.Cqrs.Query.Interfaces;
using TradeHelper.Models.DTO;
using TradeHelper.Models.Queries;
using TradeHelper.Models.QueryResults;

namespace TradeHelper.Cqrs.Query
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