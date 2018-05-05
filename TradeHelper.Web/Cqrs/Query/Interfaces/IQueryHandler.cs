using System.Threading.Tasks;

namespace TradeHelper.Web.Cqrs.Query.Interfaces
{
    public interface IQueryHandler<in TParameter, TResult>
        where TResult : IQueryResult
        where TParameter : IQuery
    {
        Task<TResult> Retrieve(TParameter query);
    }
}
