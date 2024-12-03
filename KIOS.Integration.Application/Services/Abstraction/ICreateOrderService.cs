using KIOS.Integration.Application.Commands;
using POS_Integration_CommonCore.Response;
using POS_IntegrationCommonDTO.Response;

namespace KIOS.Integration.Application.Services.Abstraction
{
    public interface ICreateOrderService
    {
        Task<ResponseModelWithClass<CustomCreateOrderResponse>> CreateOrderCHZ(KIOS.Integration.Application.Commands.CreateRetailTransactionCommand request);
        Task<ResponseModelWithClass<CustomCreateOrderResponse>> CreateOrderCHZA(KIOS.Integration.Application.Commands.CreateRetailTransactionCommand request);
        Task<ResponseModelWithClass<CustomCreateOrderResponse>> UpdateOrderCHZ(KIOS.Integration.Application.Commands.UpdateOrderRequest request);
        Task<ResponseModelWithClass<CustomCreateOrderResponse>> DeleteOrderCHZ(string thirdPartyOrderId);
    }
}
