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
        public async Task<ResponseModelWithClass<CreateOrderResponse>> CreateOrderCHZ(KIOS.Integration.Application.Commands.CreateRetailTransactionCommand request)
        {
            ResponseModelWithClass<CreateOrderResponse> response = new ResponseModelWithClass<CreateOrderResponse>();

            try
            {
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
    }
}