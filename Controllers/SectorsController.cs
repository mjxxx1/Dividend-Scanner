using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using DividendScanner.Domain.Communications;
using DividendScanner.Domain.Model;
using DividendScanner.Domain.Repositories;
using DividendScanner.Domain.Services;
using DividendScanner.Extensions;
using DividendScanner.Resources;
using Microsoft.AspNetCore.Mvc;

namespace DividendScanner.Controllers
{
    [Route("/api/[controller]")]
    public class SectorsController : Controller
    {
        private readonly ISectorService _sectorService;
        private readonly IMapper _mapper;

        public SectorsController(ISectorService sectorService, IMapper mapper)
        {
            _sectorService = sectorService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IEnumerable<SectorResource>> GetAllAsync()
        {
            IEnumerable<Sector> sectors = await _sectorService.ListAsync();
            return _mapper.Map<IEnumerable<Sector>, IEnumerable<SectorResource>>(sectors);
        }



        [HttpPost]
        public async Task<IActionResult> PostAsync([FromBody] SectorResource sectorResource)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState.GetErrorMessages());
            }

            Sector sector = _mapper.Map<SectorResource, Sector>(sectorResource);
            var result = await _sectorService.SaveAsync(sector);

            if (!result._success)
                return BadRequest(result._message);

            return Ok(result);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutAsync(int id, [FromBody] SectorResource sectorResource)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState.GetErrorMessages());
            }

            Sector sector = _mapper.Map<SectorResource, Sector>(sectorResource);
            var result = await _sectorService.UpdateAsync(id, sector);

            if (!result._success)
                return BadRequest(result._message);

            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            SectorResponse response = await _sectorService.DeleteAsync(id);
            return Ok(response);
        }
    }
}
