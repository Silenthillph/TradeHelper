//using System;
//using System.Linq;
//using System.Reflection;
//using System.Threading.Tasks;
//using Ninject;
//using Ninject.Activation;
//using TradeHelper.Web.Cqrs.Query.Interfaces;

//namespace TradeHelper.Web.Cqrs
//{
//    public class QueryDispatcher : IQueryDispatcher
//    {
//        private readonly IKernel _kernel;

//        public QueryDispatcher(IKernel kernel)
//        {
//            this._kernel = kernel;
//        }

//        public async Task<TResult> Dispatch<TParameter, TResult>(TParameter query = null)
//            where TParameter : class, IQuery, new()
//            where TResult : IQueryResult
//        {
//            query = query ?? new TParameter();

//            dynamic handler = Assembly.GetExecutingAssembly()
//                                      .GetTypes()
//                                      .Where(t => typeof(IQueryHandler<,>)
//                                                      .MakeGenericType(query.GetType(), typeof(TResult)).IsAssignableFrom(t)
//                                                  && !t.IsAbstract
//                                                  && !t.IsInterface)
//                                      .Select(i => this._kernel.Resolve(new Request(GetType(i), null, p))).FirstOrDefault();

//            if (handler == null)
//            {
//                throw new NullReferenceException("Query handler not registered");
//            }

//            return await handler.Retrieve(query);
//        }
//    }
//}