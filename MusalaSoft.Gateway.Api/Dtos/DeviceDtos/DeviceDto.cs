using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MusalaSoft.GatewayApp.Api.Dtos.DeviceDtos
{
    public class DeviceDto
    {
        public int Uid { get; set; }
        public string Vendor { get; set; }
        public DateTime Date { get; set; }
        public bool Status { get; set; }
        public int? GatewayId { get; set; }
    }
}
