using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MusalaSoft.GatewayApp.Api.Dtos.DeviceDtos
{
    public class EditDeviceDto
    {
        [Required]
        public int Uid { get; set; }
        [Required]
        public string Vendor { get; set; }
        public DateTime Date { get; set; }
        public bool Status { get; set; }
        public int? GatewayId { get; set; }
    }
}
