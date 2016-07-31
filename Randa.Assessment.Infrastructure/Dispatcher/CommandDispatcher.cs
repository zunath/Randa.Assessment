using System;
using Autofac;
using Randa.Assessment.Domain.Services.Contracts;

namespace Randa.Assessment.Infrastructure.Dispatcher
{
    public class CommandDispatcher: ICommandDispatcher
    {
        private readonly IComponentContext _context;

        public CommandDispatcher(IComponentContext context)
        {
            _context = context;
        }

        public void Execute<TCommand>(TCommand command) where TCommand : ICommand
        {
            if (command == null)
            {
                throw new ArgumentNullException(nameof(command));
            }

            var handler = _context.Resolve<ICommandHandler<TCommand>>();

            if (handler == null)
            {
                throw new Exception("Unable to find command handler. Command name: " + nameof(TCommand));
            }

            handler.Execute(command);
        }
    }
}
