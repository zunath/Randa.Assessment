namespace Randa.Assessment.Domain.Services.Contracts
{
    public interface IQueryHandler<in TQuery, out TResult>
        where TQuery: IQuery
    {
        TResult Execute(TQuery query);
    }
}
