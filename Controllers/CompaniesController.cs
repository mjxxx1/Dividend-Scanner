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
        public async Task<IActionResult> PostAsync([FromBody] CompanyResource companyResource)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState.GetErrorMessages());
            }

            var company = _mapper.Map<CompanyResource, Company>(companyResource);
            var result = await _companyService.SaveAsync(company);

            if (!result._success)
                return BadRequest(result._message);

            return Ok(result);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutAsync(int id, [FromBody] Company company)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState.GetErrorMessages());
            }

            var result = await _companyService.UpdateAsync(id, company);

            if (!result._success)
                return BadRequest(result._message);

            var companyResource = _mapper.Map<Company, CompanyResource>(result._company);
            return Ok(companyResource);
        }
    }
}
