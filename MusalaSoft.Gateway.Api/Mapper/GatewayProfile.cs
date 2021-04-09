using AutoMapper;
using MusalaSoft.GatewayApp.Api.Core.Models;
using MusalaSoft.GatewayApp.Api.Dtos.GatewayDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MusalaSoft.GatewayApp.Api.Mapper
{
    public class GatewayProfile : Profile
    {
        public GatewayProfile()
        {
            CreateMap<Gateway, GatewayDto>().ReverseMap();
            CreateMap<Gateway, EditGatewayDto>().ReverseMap();
            CreateMap<Gateway, AddGatewayDto>().ReverseMap();
        }
    }
}
