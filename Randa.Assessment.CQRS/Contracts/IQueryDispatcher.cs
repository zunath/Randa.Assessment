namespace Randa.Assessment.CQRS.Contracts
{
    public interface IQueryDispatcher
    {
        TResult Execute<TQuery, TResult>(TQuery query)
            where TQuery : IQuery;
    }
}
