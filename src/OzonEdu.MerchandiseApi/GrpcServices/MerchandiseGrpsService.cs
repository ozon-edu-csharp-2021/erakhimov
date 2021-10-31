using Grpc.Core;
using Ozon.MerchandiseApi.Grpc;
using OzonEdu.MerchandiseApi.Services.Interfaces;
using System.Threading.Tasks;

namespace OzonEdu.MerchandiseApi.GrpcServices
{
    public sealed class MerchandiseGrpsService : MerchandiseApiGrpc.MerchandiseApiGrpcBase
    {
        private readonly IMerchandiseService _merchandiseService;

        public MerchandiseGrpsService(IMerchandiseService merchandiseService)
        {
            _merchandiseService = merchandiseService;
        }

        public override async Task<GetMerchResponse> GetMerch(GetMerchRequest request, ServerCallContext context)
        {
            var response = await _merchandiseService.GetMerch(request.EmloyeeId, context.CancellationToken);

            return new GetMerchResponse()
            {
                EmloyeeId = response.EmployeerId,
                IsIssued = response.IsIssued
            };
        }

        public override async Task<GetMerchResponse> GetInfo(GetMerchRequest request, ServerCallContext context)
        {
            var response = await _merchandiseService.GetMerch(request.EmloyeeId, context.CancellationToken);
            return new GetMerchResponse()
            {
                EmloyeeId = response.EmployeerId,
                IsIssued = response.IsIssued
            };
        }
    }
}
