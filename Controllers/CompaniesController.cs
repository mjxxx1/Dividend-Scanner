using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DividendScanner.Domain.Model;
using DividendScanner.Domain.Repositories;
using DividendScanner.Domain.Services;
using DividendScanner.Extensions;
using Microsoft.AspNetCore.Mvc;

namespace DividendScanner.Controllers
{
    [Route("/api/[controller]")]
    public class CompaniesController : Controller
    {
        private readonly ICompanyService _companyService;

        public CompaniesController(ICompanyService companyService)
        {
            _companyService = companyService;
        }

        [HttpGet]
        public async Task<IEnumerable<Company>> GetAllAsync()
        {
            var companies = await _companyService.ListAsync();
            return companies;
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
