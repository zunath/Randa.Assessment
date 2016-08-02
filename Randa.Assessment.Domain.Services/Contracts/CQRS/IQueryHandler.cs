namespace Randa.Assessment.Domain.Services.Contracts.CQRS
{
    public interface IQueryHandler<in TQuery, out TResult>
        where TQuery: IQuery
    {
        TResult Execute(TQuery query);
    }
}
