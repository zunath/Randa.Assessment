namespace Randa.Assessment.Domain.Services.Contracts
{
    public interface ICommandHandler<in TCommand>
    {
        void Execute(TCommand command);
    }
}
