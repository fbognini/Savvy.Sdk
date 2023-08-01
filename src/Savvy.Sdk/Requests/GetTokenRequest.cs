using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Savvy.Sdk.Requests
{
    public class GetTokenRequest
    {
        public int AdminTeamId { get; set; }
        public required string MerchantId { get; set; }
        public required string Password { get; set; }
    }
}
