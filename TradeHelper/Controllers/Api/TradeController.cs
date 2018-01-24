using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Http;
using EntityModel;
using Repository;

namespace TradeHelper.Controllers.Api
{
    public class TradeController: ApiController
    {
        private readonly IUnitOfWork unitOfWork;

        public TradeController(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }
        
        [System.Web.Http.HttpGet]
        public async Task<IEnumerable<string>> GetAllTrades()
        {
            var repo = this.unitOfWork.GetRepository<TradeInfo>();
            var data = repo.GetAll();
            
            return data.Select(d => d.PairCode);
        }
    }
}