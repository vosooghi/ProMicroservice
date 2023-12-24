namespace CQRSSamples.Framework
{
    public interface IQueryHandler<TQuery,TQueryResult> where TQuery:IQuery
    {
        Task Query(TQuery query);
    }
}
