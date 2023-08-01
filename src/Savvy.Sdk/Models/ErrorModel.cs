using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Savvy.Sdk.Models
{
    public class ErrorModel
    {
        /// <summary>
        /// Gets or Sets Reasontext
        /// </summary>
        public string? Reasontext { get; set; }

        /// <summary>
        /// 01 = Not yet active, 02 = Not Yet Valid, 03 = Cancelled, 04 = Used, 10 = Non-existent Code, 11 = Zero Balance, 15 = Code Expired, 20 Minimum Stay Breach, 21 Maximum Stay Breach, 22 Minimum Order Value Breach, 23 Maximum Order Value Breach
        /// </summary>
        /// <value>01 = Not yet active, 02 = Not Yet Valid, 03 = Cancelled, 04 = Used, 10 = Non-existent Code, 11 = Zero Balance, 15 = Code Expired, 20 Minimum Stay Breach, 21 Maximum Stay Breach, 22 Minimum Order Value Breach, 23 Maximum Order Value Breach</value>
        public string? Reasoncode { get; set; }

        /// <summary>
        /// Gets or Sets Limitvalue
        /// </summary>
        public double? Limitvalue { get; set; }
    }
}
