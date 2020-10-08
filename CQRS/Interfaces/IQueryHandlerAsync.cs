using CQRS.Interfaces;
using System.Threading.Tasks;

namespace CQRS.Interfaces
{
    public interface IQueryHandlerAsync<TQuery, TResult> where TQuery : IQuery
    {
        Task<TResult> HandleAsync(TQuery query);
    }
}
