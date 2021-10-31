using OzonEdu.MerchandiseApi.Models;
using System.Net.Http.Json;
using System.Threading;
using System.Threading.Tasks;

namespace OzonEdu.MerchandiseApi.HttpClient
{
    public class MerchHttpClient : IMerchHttpClient
    {
        private readonly System.Net.Http.HttpClient _httpClient;

        public MerchHttpClient(System.Net.Http.HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<MerchResponse> GetMerch(MerchRequest merchRequest, CancellationToken token)
        {
            using var response = await _httpClient.GetAsync($"api/merchandise/{merchRequest.EmployeerId}/merch/", token);
            var merchResult = await response.Content.ReadFromJsonAsync<MerchResponse>(cancellationToken: token);

            return merchResult;
        }

        public async Task<MerchResponse> GetInfo(MerchRequest merchRequest, CancellationToken token)
        {
            using var response = await _httpClient.GetAsync($"api/merchandise/{ merchRequest.EmployeerId}/info/", token);
            var infoResult = await response.Content.ReadFromJsonAsync<MerchResponse>(cancellationToken: token);

            return infoResult;
        }
    }
}
