using MusalaSoft.GatewayApp.Api.Dtos.DeviceDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MusalaSoft.GatewayApp.Api.Dtos.GatewayDtos
{
    public class GatewayDto
    {
        public int Id { get; set; }
        public string SerialNumber { get; set; }
        public string Name { get; set; }
        public string IPV4 { get; set; }
        public List<DeviceDto> Devices { get; set; }
    }
}
