using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Savvy.Sdk.Requests
{
    public sealed class InitializeVirtualCardRequest : AuthenticatedRequest
    {
        public required string RequestId { get; set; }
        public double Amount { get; set; }
        public required string Currency { get; set; }
    }
}
