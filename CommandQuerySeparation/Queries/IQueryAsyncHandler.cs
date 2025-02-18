using CommandQuerySeparation.Results;

namespace CommandQuerySeparation.Queries
{
    public interface IQueryAsyncHandler<TQuery, TResult>
        where TQuery : IQueryDefinition<TResult>
    {
        Result<TResult> ExecuteAsync(TQuery query);
    }
}
