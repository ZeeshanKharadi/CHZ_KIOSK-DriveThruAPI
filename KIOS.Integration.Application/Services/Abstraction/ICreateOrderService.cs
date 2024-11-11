using POS_Integration_CommonCore.Response;
using POS_IntegrationCommonDTO.Response;

namespace KIOS.Integration.Application.Services.Abstraction
{
    public interface ICreateOrderService
    {
        Task<ResponseModelWithClass<CreateOrderResponse>> CreateOrderKFC(KIOS.Integration.Application.Commands.CreateRetailTransactionCommand request);
        Task<ResponseModelWithClass<CreateOrderResponse>> CreateOrderKFCA(KIOS.Integration.Application.Commands.CreateRetailTransactionCommand request);
    }
}
