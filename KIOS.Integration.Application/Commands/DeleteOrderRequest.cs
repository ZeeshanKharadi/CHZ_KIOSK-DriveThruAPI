using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KIOS.Integration.Application.Commands
{
    public class DeleteOrderRequest
    {
        public string thirdPartyOrderId { get; set; }
    }
}
