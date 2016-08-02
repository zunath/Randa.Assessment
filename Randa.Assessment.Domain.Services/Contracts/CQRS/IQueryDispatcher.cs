namespace Randa.Assessment.Domain.Services.Contracts.CQRS
{
    public interface IQueryDispatcher
    {
        TResult Execute<TQuery, TResult>(TQuery query)
            where TQuery : IQuery
            where TResult: IQueryResult;
    }
}
