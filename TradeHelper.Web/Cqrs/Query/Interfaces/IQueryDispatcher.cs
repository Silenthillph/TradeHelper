using System.Threading.Tasks;

namespace TradeHelper.Web.Cqrs.Query.Interfaces
{
    public interface IQueryDispatcher
    {
        Task<TResult> Dispatch<TParameter, TResult>(TParameter query = null)
            where TParameter : class, IQuery, new()
            where TResult : IQueryResult;
    }
}
