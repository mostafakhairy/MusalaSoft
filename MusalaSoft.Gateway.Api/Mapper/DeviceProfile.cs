using AutoMapper;
using MusalaSoft.GatewayApp.Api.Core.Models;
using MusalaSoft.GatewayApp.Api.Dtos.DeviceDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MusalaSoft.GatewayApp.Api.Mapper
{
    public class DeviceProfile : Profile
    {
        public DeviceProfile()
        {
            CreateMap<Device, DeviceDto>().ReverseMap();
            CreateMap<Device, EditDeviceDto>().ReverseMap();
            CreateMap<Device, AddDeviceDto>().ReverseMap();
        }
    }
}
