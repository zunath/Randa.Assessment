namespace Randa.Assessment.CQRS.Contracts
{
    public interface ICommandDispatcher
    {
        void Execute<TCommand>(TCommand command)
            where TCommand : ICommand;
    }
}
