using MusalaSoft.GatewayApp.Api.Dtos.DeviceDtos;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MusalaSoft.GatewayApp.Api.Dtos.GatewayDtos
{
    public class AddGatewayDto
    {
        [Required]
        public string SerialNumber { get; set; }
        [Required]
        [RegularExpression("^[A-Za-z ]{3,}$", ErrorMessage = "Name should only contain characters and spaces")]
        public string Name { get; set; }
        [Required]
        [RegularExpression("^([0-9]{1,3})\\.([0-9]{1,3})\\.([0-9]{1,3})\\.([0-9]{1,3})$",ErrorMessage = "Please enter valid ip")]
        public string IPV4 { get; set; }
        public List<DeviceDto> Devices { get; set; }
    }
}
