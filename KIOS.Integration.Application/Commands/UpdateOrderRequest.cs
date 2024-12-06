using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using POS_IntegrationCommonDTO.Request;

namespace KIOS.Integration.Application.Commands
{
    public class UpdateOrderRequest
    {
        public string ThirdPartyOrderId { get; set; }
        public IList<SalesLine> salesLines { get; set; }

        public UpdateOrderRequest()
        {
            salesLines = new List<SalesLine>();
        }
    }
}
