namespace Randa.Assessment.CQRS.Contracts
{
    public interface ICommandHandler<in TCommand>
    {
        void Execute(TCommand command);
    }
}
