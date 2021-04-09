using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MusalaSoft.GatewayApp.Api.Core.Models
{
    public class Gateway
    {
        public int Id { get; set; }
        public string SerialNumber { get; set; }
        public string Name { get; set; }
        public string IPV4 { get; set; }
        public List<Device> Devices { get; set; }
    }
}
