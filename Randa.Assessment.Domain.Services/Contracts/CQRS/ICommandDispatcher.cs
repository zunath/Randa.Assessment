namespace Randa.Assessment.Domain.Services.Contracts.CQRS
{
    public interface ICommandDispatcher
    {
        void Execute<TCommand>(TCommand command)
            where TCommand : ICommand;
    }
}
