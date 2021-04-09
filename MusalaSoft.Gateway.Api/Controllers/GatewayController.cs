using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Localization;
using MusalaSoft.GatewayApp.Api.Core;
using MusalaSoft.GatewayApp.Api.Core.IRepositories;
using MusalaSoft.GatewayApp.Api.Core.Models;
using MusalaSoft.GatewayApp.Api.Dtos.DeviceDtos;
using MusalaSoft.GatewayApp.Api.Dtos.GatewayDtos;
using MusalaSoft.GatewayApp.Api.Resources;

namespace MusalaSoft.GatewayApp.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GatewayController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IGatewayRepository _gateWayRepository;
        private readonly IDeviceRepository _deviceRepository;

        private readonly IMapper _mapper;
        public GatewayController(IUnitOfWork unitOfWork, IGatewayRepository gateWayRepository,
             IMapper mapper, IDeviceRepository deviceRepository)
        {
            _unitOfWork = unitOfWork;
            _gateWayRepository = gateWayRepository;
            _mapper = mapper;
            _deviceRepository = deviceRepository;
        }
        [HttpGet]
        public async Task<IActionResult> Get()
      {
            var query = await _gateWayRepository.GetAllAsync();
            return Ok(query.ProjectTo<GatewayDto>(_mapper.ConfigurationProvider).ToList());
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var query = await _gateWayRepository.GetManyAsync(c=>c.Id == id);
            var device = query.ProjectTo<GatewayDto>(_mapper.ConfigurationProvider).FirstOrDefault();
            if (device == null) return NotFound(); else return Ok(device);
        }
        [HttpPost]

        public async Task<IActionResult> Post(AddGatewayDto gatewayDto)
        {
            if ((await _gateWayRepository.GetManyAsync(c => c.SerialNumber == gatewayDto.SerialNumber)).Any())
            {
                ModelState.AddModelError("Serial Number", "Serial Number Already Exist");
                return BadRequest (ModelState);
            }
            if (gatewayDto.Devices.Count() > 10)
            {
                ModelState.AddModelError("Devices", "Devices Limit Excedded");
                return BadRequest(ModelState);
            }
            var gateway = _mapper.Map<Gateway>(gatewayDto);
            var devices = gateway.Devices;
            gateway.Devices = null;
            await _gateWayRepository.Add(gateway);
            await _unitOfWork.Complete();
            foreach (var c in devices) 
            {
                var dev = await _deviceRepository.GetById(c.Uid);
                dev.GatewayId = gateway.Id;
                dev.Status = true;
            };
            await _unitOfWork.Complete();

            return Ok();
        }
        [HttpPut]
        public async Task<IActionResult> Put(EditGatewayDto gatewayDto)
        {
            if ((await _gateWayRepository
                .GetManyAsync(c => c.SerialNumber == gatewayDto.SerialNumber &&c.Id != gatewayDto.Id )).Any())
            {
                ModelState.AddModelError("Serial Number", "Serial Number Already Exist");
                return BadRequest(ModelState);
            }
            if(gatewayDto.Devices.Count() > 10 )
            {
                ModelState.AddModelError("Devices", "Devices Limit Excedded");
                return BadRequest(ModelState);
            }
            var gateway = _mapper.Map<Gateway>(gatewayDto);
            var devices = gateway.Devices;
            gateway.Devices = null;
            await _gateWayRepository.Update(gateway);
            foreach (var c in devices)
            {
                var dev = await _deviceRepository.GetById(c.Uid);
                dev.GatewayId = gateway.Id;
                dev.Status = true;
            };
            //update removed devices
            var deviceIds = devices.Select(c => c.Uid).ToList();
            var removedDevice = await _deviceRepository.GetManyAsync(c => !deviceIds.Any(a => c.Uid == a) && c.GatewayId == gateway.Id);
            removedDevice.ToList().ForEach(c =>
            {
                c.GatewayId = null;
                c.Status = false;
                _deviceRepository.Update(c);
            });
            await _unitOfWork.Complete();
            return Ok();
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            if (!(await _gateWayRepository.GetManyAsync(c => c.Id == id)).Any())
                return BadRequest();
            var devices = await _deviceRepository.GetManyAsync(c => c.GatewayId == id);
            devices.ToList().ForEach(device =>
            {
                device.Status = false;
                _deviceRepository.Update(device);
            });
            await _gateWayRepository.Delete(id);
            await _unitOfWork.Complete();
            return Ok();
        }
    }
}
