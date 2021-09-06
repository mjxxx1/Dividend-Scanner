using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using DividendScanner.Domain.Model;
using DividendScanner.Domain.Repositories;
using DividendScanner.Domain.Services;
using DividendScanner.Extensions;
using DividendScanner.Resources;
using Microsoft.AspNetCore.Mvc;

namespace DividendScanner.Controllers
{
    [Route("/api/[controller]")]
    public class CompaniesController : Controller
    {
        private readonly ICompanyService _companyService;
        private readonly IMapper _mapper;

        public CompaniesController(ICompanyService companyService, IMapper mapper)
        {
            _companyService = companyService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IEnumerable<CompanyResource>> GetAllAsync()
        {
            var companies = await _companyService.ListAsync();
            var resource = _mapper.Map<IEnumerable<Company>, IEnumerable<CompanyResource>>(companies);
            return resource;
        }



        [HttpPost]
        public async Task<IActionResult> PostAsync([FromBody] Company company)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState.GetErrorMessages());
            }

            var result = await _companyService.SaveAsync(company);

            if (!result._success)
                return BadRequest(result._message);

            return Ok(result);
        }

        [HttpPut("{isin}")]
        public async Task<IActionResult> PutAsync(string isin, [FromBody] Company company)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState.GetErrorMessages());
            }

            var result = await _companyService.UpdateAsync(isin, company);

            if (!result._success)
                return BadRequest(result._message);

            return Ok(result);
        }
    }
}
