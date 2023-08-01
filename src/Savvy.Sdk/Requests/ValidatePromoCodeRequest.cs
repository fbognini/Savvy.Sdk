using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Savvy.Sdk.Requests
{
    public sealed class ValidatePromoCodeRequest : AuthenticatedRequest
    {
        public required string RequestId { get; set; }
        public required string CardNumber { get; set; }
        public required string Pin { get; set; }
        public required string Currency { get; set; }
    }
}
