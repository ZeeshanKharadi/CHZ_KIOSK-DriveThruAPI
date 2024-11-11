using Microsoft.AspNetCore.Mvc;
using KIOS.Integration.Application.Services.Abstraction;
using System.Net;
using POS_Integration_CommonCore.Response;
using POS_IntegrationCommonDTO.Response;
using POS_Integration_CommonCore.Enums;

namespace KIOS.Integration.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MPOSStatusController : ControllerBase
    {
        private readonly ICheckPosStatusService _checkPosStatusService;

        public MPOSStatusController(ICheckPosStatusService checkPosStatusService)
        {
            _checkPosStatusService = checkPosStatusService;
        }
               
         //http://localhost:8082/api/MPOSStatus/check-pos-status?storeId=0072
        [HttpGet]
        [Route("check-pos-status")]
        public async Task<ResponseModelWithClass<CheckPOSStatusReposne>> CheckPosStatusAsync(string storeId)
        {
            ResponseModelWithClass<CheckPOSStatusReposne> response = new ResponseModelWithClass<CheckPOSStatusReposne>();

            try
            {
                return await _checkPosStatusService.CheckPosStatusAsync(storeId);

            }
            catch (Exception ex)
            {
                response.Result = null;
                response.Message = ex.Message;
                response.HttpStatusCode = (int)HttpStatusCode.InternalServerError;
                response.MessageType = (int)MessageType.Error;
                return response;
            }
        }
        
    }
}