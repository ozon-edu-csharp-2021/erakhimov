using OzonEdu.MerchandiseApi.Models;
using System.Threading;
using System.Threading.Tasks;

namespace OzonEdu.MerchandiseApi.HttpClient
{
    public interface IMerchHttpClient
    {
        Task<MerchResponse> GetMerch(MerchRequest merchRequest, CancellationToken token);

        Task<MerchResponse> GetInfo(MerchRequest merchRequest, CancellationToken token);
    }
}
