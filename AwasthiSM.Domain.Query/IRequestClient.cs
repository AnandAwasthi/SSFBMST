using System.Threading;
using System.Threading.Tasks;

namespace AwasthiSM.Domain.Query
{
    public interface IRequestClient<TRequest, TResponse>
    {
        Task<TResponse> Request(TRequest request, CancellationToken cancellationToken);
    }
}
