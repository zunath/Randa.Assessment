namespace Randa.Assessment.Domain.Services.Contracts.CQRS
{
    public interface ICommandHandler<in TCommand>
    {
        void Execute(TCommand command);
    }
}
