using KIOS.Integration.Application.Commands;
using KIOS.Integration.Application.Services.Abstraction;
using Microsoft.AspNetCore.Mvc;
using POS_Integration_CommonCore.Enums;
using POS_Integration_CommonCore.Response;
using POS_IntegrationCommonDTO.Response;
using System.Net;

namespace KIOS.Integration.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderManagementController : ControllerBase
    {
        private readonly ILogger<OrderManagementController> _logger;
        private readonly ICreateOrderService _createOrderService;

        public OrderManagementController(ILogger<OrderManagementController> logger, ICreateOrderService createOrderService)
        {
            _logger = logger;
            _createOrderService = createOrderService;
        }

        [HttpPost]
        [Route("create-order")]
        public async Task<ResponseModelWithClass<CustomCreateOrderResponse>> CreateOrderCHZ(KIOS.Integration.Application.Commands.CreateRetailTransactionCommand request)
        {
            ResponseModelWithClass<CustomCreateOrderResponse> response = new ResponseModelWithClass<CustomCreateOrderResponse>();

            try
            {
                // Validate OrderStatus
                if (request.orderStatus != "Created" && request.orderStatus != "Finalized")
                {
                    return new ResponseModelWithClass<CustomCreateOrderResponse>
                    {                      
                        Message = "Invalid OrderStatus. It must be either 'Created' or 'Finalized'."
                    };
                }

                request.Payment_method = PaymentMethod.Cash;
                request.AmountCur = 0;
                request.TenderTypeId = null;
                request.TableNum = null;

                return await _createOrderService.CreateOrderCHZ(request);
            }
            catch (Exception ex)
            {
                response.Result = null;
                response.HttpStatusCode = (int)HttpStatusCode.InternalServerError;
                response.MessageType = (int)MessageType.Error;
                response.Message = "server error msg: " + ex.Message + " | Inner exception:  " + ex.InnerException;
                return response;
            }
        }

        [HttpPut]
        [Route("update-order/{thirdPartyOrderId}")]
        public async Task<ResponseModelWithClass<CustomCreateOrderResponse>> UpdateOrderCHZ(string thirdPartyOrderId, KIOS.Integration.Application.Commands.UpdateOrderRequest request)
        {
            ResponseModelWithClass<CustomCreateOrderResponse> response = new ResponseModelWithClass<CustomCreateOrderResponse>();

            try
            {
                request.ThirdPartyOrderId = thirdPartyOrderId;

                return await _createOrderService.UpdateOrderCHZ(request);
            }
            catch (Exception ex)
            {
                response.Result = null;
                response.HttpStatusCode = (int)HttpStatusCode.InternalServerError;
                response.MessageType = (int)MessageType.Error;
                response.Message = "server error msg: " + ex.Message + " | Inner exception:  " + ex.InnerException;
                return response;
            }
        }
        [HttpDelete]
        [Route("delete-order")]
        public async Task<ResponseModelWithClass<CustomCreateOrderResponse>> DeleteOrderCHZ([FromBody] KIOS.Integration.Application.Commands.DeleteOrderRequest request)
        {
            ResponseModelWithClass<CustomCreateOrderResponse> response = new ResponseModelWithClass<CustomCreateOrderResponse>();

            try
            {
                // Validate input
                if (string.IsNullOrWhiteSpace(request.thirdPartyOrderId))
                {
                    return new ResponseModelWithClass<CustomCreateOrderResponse>
                    {
                        HttpStatusCode = (int)HttpStatusCode.BadRequest,
                        MessageType = (int)MessageType.Error,
                        Message = "Invalid request. 'thirdPartyOrderId' is required."
                    };
                }

                // Perform deletion logic using the thirdPartyOrderId
                return await _createOrderService.DeleteOrderCHZ(request.thirdPartyOrderId);
                //bool isDeleted = await _createOrderService.DeleteOrderCHZ(request.thirdPartyOrderId);

                
                    response.HttpStatusCode = (int)HttpStatusCode.OK;
                    response.MessageType = (int)MessageType.Success;
                    response.Message = "Order deleted successfully.";
                
            }
            catch (Exception ex)
            {
                response.HttpStatusCode = (int)HttpStatusCode.InternalServerError;
                response.MessageType = (int)MessageType.Error;
                response.Message = "server error msg: " + ex.Message + " | Inner exception: " + ex.InnerException;
            }

            return response;
        }

        [HttpPost]
        [Route("complete-order")]
        public async Task<ResponseModelWithClass<CustomCreateOrderResponse>> CompleteOrderCHZ(KIOS.Integration.Application.Commands.CreateRetailTransactionCommand request)
        {
            ResponseModelWithClass<CustomCreateOrderResponse> response = new ResponseModelWithClass<CustomCreateOrderResponse>();

            try
            {
                return await _createOrderService.CreateOrderCHZ(request);
            }
            catch (Exception ex)
            {
                response.Result = null;
                response.HttpStatusCode = (int)HttpStatusCode.InternalServerError;
                response.MessageType = (int)MessageType.Error;
                response.Message = "server error msg: " + ex.Message + " | Inner exception:  " + ex.InnerException;
                return response;
            }
        }
    }
}