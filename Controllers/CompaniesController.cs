using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DividendScanner.Domain.Model;
using DividendScanner.Domain.Repositories;
using DividendScanner.Domain.Services;
using Microsoft.AspNetCore.Mvc;

namespace DividendScanner.Controllers
{
    [Route("/api/[controller]")]
    public class CompaniesController : Controller
    {
        private readonly ICompanyRepository _companiesService;

        public CompaniesController(ICompanyRepository companiesService)
        {
            _companiesService = companiesService;
        }

        [HttpGet]
        public async Task<IEnumerable<Company>> GetAllAsync()
        {
            var companies = await _companiesService.ListAsync();
            return companies;
        }
    }
}
