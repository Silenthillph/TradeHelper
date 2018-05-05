//using System;
//using System.Linq;
//using System.Reflection;
//using System.Threading.Tasks;
//using Ninject;
//using TradeHelper.Web.Cqrs.Command.Interfaces;
//using TradeHelper.Web.Models.Commands;

//namespace TradeHelper.Web.Cqrs
//{
//    public class CommandDispatcher: ICommandDispatcher
//    {
//        private readonly IKernel _kernel;

//        public CommandDispatcher(IKernel kernel)
//        {
//            if (kernel == null)
//            {
//                throw new ArgumentNullException(nameof(kernel));
//            }

//            _kernel = kernel;
//        }

//        public async Task<CommandResult> Dispatch<TParameter>(TParameter command) where TParameter : ICommand
//        {
//            if (command == null)
//            {
//                throw new ArgumentNullException(nameof(command));
//            }

//            try
//            {
//                dynamic handler = Assembly.GetExecutingAssembly()
//                                          .GetTypes()
//                                          .Where(t => typeof(ICommandHandler<>)
//                                                          .MakeGenericType(command.GetType()).IsAssignableFrom(t)
//                                                      && !t.IsAbstract
//                                                      && !t.IsInterface)
//                                          .Select(i => _kernel.Resolve(i)).FirstOrDefault();

//                if (handler == null)
//                {
//                    throw new NullReferenceException("Command handler not registered");
//                }

//                return await handler.Execute(command);
//            }
//            catch (Exception ex)
//            {
//                //TODO: descriptive error messages
//                throw new Exception(string.Empty, ex);
//            }
//        }
//    }
//}