using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MusalaSoft.GatewayApp.Api.Core;
using MusalaSoft.GatewayApp.Api.Core.IRepositories;
using MusalaSoft.GatewayApp.Api.Core.Models;
using MusalaSoft.GatewayApp.Api.Dtos.DeviceDtos;

namespace MusalaSoft.GatewayApp.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DeviceController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IDeviceRepository _deviceRepository;
        private readonly IMapper _mapper;

        public DeviceController(IUnitOfWork unitOfWork, IDeviceRepository deviceRepository, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _deviceRepository = deviceRepository;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var query = await _deviceRepository.GetAllAsync();
             return Ok(query.ProjectTo<DeviceDto>(_mapper.ConfigurationProvider).ToList());
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var device = await _deviceRepository.GetById(id);
            if (device == null) return NotFound(); else return Ok(_mapper.Map<DeviceDto>( device));
        }
        [HttpPost]

        public async Task<IActionResult> Post(AddDeviceDto deviceDto)
        {
            var device = _mapper.Map<Device>(deviceDto);
            await _deviceRepository.Add(device);
            await _unitOfWork.Complete();
            return Ok();
        }
        [HttpPut]
        public async Task<IActionResult> Put(EditDeviceDto deviceDto)
        {
            var device = _mapper.Map<Device>(deviceDto);
            await _deviceRepository.Update(device);
            await _unitOfWork.Complete();
            return Ok();
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            if (!(await _deviceRepository.GetManyAsync(c => c.Uid == id)).Any())
                return BadRequest();
            await _deviceRepository.Delete(id);
            await _unitOfWork.Complete();
            return Ok();
        }
    }
}
