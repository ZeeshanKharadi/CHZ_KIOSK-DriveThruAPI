using POS_Integration_CommonCore.Response;
using POS_IntegrationCommonDTO.Response;

namespace KIOS.Integration.Application.Services.Abstraction
{
    public interface ICreateOrderService
    {
        Task<ResponseModelWithClass<CreateOrderResponse>> CreateOrderCHZ(KIOS.Integration.Application.Commands.CreateRetailTransactionCommand request);
        Task<ResponseModelWithClass<CreateOrderResponse>> CreateOrderCHZA(KIOS.Integration.Application.Commands.CreateRetailTransactionCommand request);
    }
}
