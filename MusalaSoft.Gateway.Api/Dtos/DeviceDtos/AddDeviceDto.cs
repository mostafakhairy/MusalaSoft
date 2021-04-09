using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MusalaSoft.GatewayApp.Api.Dtos.DeviceDtos
{
    public class AddDeviceDto
    {
        [Required]
        public string Vendor { get; set; }
    }
}
