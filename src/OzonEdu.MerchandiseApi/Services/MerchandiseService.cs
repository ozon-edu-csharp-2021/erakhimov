using OzonEdu.MerchandiseApi.Models;
using OzonEdu.MerchandiseApi.Services.Interfaces;
using System.Threading;
using System.Threading.Tasks;

namespace OzonEdu.MerchandiseApi.Services
{
    public class MerchandiseService : IMerchandiseService
    {
        public async Task<MerchResponse> GetInfo(int id, CancellationToken token)
        {
            return new MerchResponse(id, true);
        }

        public async Task<MerchResponse> GetMerch(int id, CancellationToken token)
        {
            return new MerchResponse(id, true);
        }
    }
}
