using OzonEdu.MerchandiseApi.Models;
using System.Threading;
using System.Threading.Tasks;

namespace OzonEdu.MerchandiseApi.Services.Interfaces
{
    public interface IMerchandiseService
    {
        Task<MerchResponse> GetMerch(int id, CancellationToken token);

        Task<MerchResponse> GetInfo(int id, CancellationToken token);
    }
}
