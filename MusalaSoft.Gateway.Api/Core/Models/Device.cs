using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MusalaSoft.GatewayApp.Api.Core.Models
{
    public class Device
    {
        public int Uid { get; set; }
        public string Vendor { get; set; }
        public DateTime Date { get; set; }
        public bool Status { get; set; }
        public int? GatewayId { get; set; }
        public Gateway Gateway { get; set; }
    }
}
