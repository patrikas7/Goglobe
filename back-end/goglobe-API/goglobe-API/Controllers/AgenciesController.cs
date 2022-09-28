using Microsoft.AspNetCore.Mvc;
using goglobe_API.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;
using goglobe_API.Data.Entities;
using goglobe_API.Data.DTOs.Agencies;
using System.Linq;
using AutoMapper;
using System;
using System.Diagnostics;

namespace goglobe_API.Controllers
{
    [ApiController]
    [Route("/api/agencies")]
    public class AgenciesController : ControllerBase
    {
        private readonly IAgencyRepository _agenciesRepository;
        private readonly IMapper _mapper;

        public AgenciesController(IAgencyRepository agenciesRepository, IMapper mapper)
        {
            _agenciesRepository = agenciesRepository;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IEnumerable<AgencyDTO>> GetAll()
        {
            return (await _agenciesRepository.GetAll())
                .Select(obj => _mapper.Map<AgencyDTO>(obj));
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<AgencyDTO>> Get(int id)
        {
            var agency = await _agenciesRepository.Get(id);
            if (agency == null) return NotFound($"Agency with id `{id}` was not found");

            return Ok(_mapper.Map<AgencyDTO>(agency));
        }

        [HttpGet("filter")]
        public async Task<ActionResult<AgencyDTO>> GetByName([FromQuery] string name)
        {
            var agency = await _agenciesRepository.GetByName(name);
            if (agency == null) return NotFound($"Agency with name `{name}` was not found");

            return Ok(_mapper.Map<AgencyDTO>(agency));
        }

        [HttpPost]
        public async Task<ActionResult<AgencyDTO>> Post(CreateAgencyDTO createAgencyDTO)
        {
            var agency = _mapper.Map<Agency>(createAgencyDTO);

            await _agenciesRepository.Create(agency);

            return Created($"/api/agencies.{agency.Id}", _mapper.Map <AgencyDTO>(agency));
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<AgencyDTO>> Put(int id, CreateAgencyDTO createAgencyDTO)
        {
            var agency = await _agenciesRepository.Get(id);
            if (agency == null) return NotFound($"Agency with id `{id}` was not found");

            await _agenciesRepository.Put(agency);

            return Ok(_mapper.Map<AgencyDTO>(agency));
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<AgencyDTO>> Delete(int id)
        {
            var agency = await _agenciesRepository.Get(id);
            if (agency == null) return NotFound($"Agency with id `{id}` was not found");

            await _agenciesRepository.Delete(agency);

            return NoContent() ;
        }
    }
}
