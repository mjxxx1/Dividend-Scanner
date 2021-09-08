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
            IEnumerable<Company> companies = await _companyService.ListAsync();
            return _mapper.Map<IEnumerable<Company>, IEnumerable<CompanyResource>>(companies);
        }



        [HttpPost]
        public async Task<IActionResult> PostAsync([FromBody] CompanyResource companyResource)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState.GetErrorMessages());
            }

            Company company = _mapper.Map<CompanyResource, Company>(companyResource);
            var result = await _companyService.SaveAsync(company);

            if (!result._success)
                return BadRequest(result._message);

            return Ok(result);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutAsync(int id, [FromBody] CompanyResource companyResource)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState.GetErrorMessages());
            }

            Company company = _mapper.Map<CompanyResource, Company>(companyResource);
            var result = await _companyService.UpdateAsync(id, company);

            if (!result._success)
                return BadRequest(result._message);

            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            CompanyResponse response = await _companyService.DeleteAsync(id);
            return Ok(response);
        }
    }
}
