using OzonEdu.MerchandiseApi.Models;
using System.Text.Json;
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
            var body = await response.Content.ReadAsStringAsync(token);
            return JsonSerializer.Deserialize<MerchResponse>(body);
        }

        public async Task<MerchResponse> GetInfo(MerchRequest merchRequest, CancellationToken token)
        {
            using var response = await _httpClient.GetAsync($"api/merchandise/{ merchRequest.EmployeerId}/info/", token);
            var body = await response.Content.ReadAsStringAsync(token);
            return JsonSerializer.Deserialize<MerchResponse>(body);
        }
    }
}
