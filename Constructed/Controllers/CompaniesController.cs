using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Constructed.Models;
using Constructed.Services;
using Microsoft.AspNetCore.Mvc;

namespace Constructed.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CompaniesController : ControllerBase
    {
        private readonly CompaniesService _compService;
        private readonly JobsService _jService;
        public CompaniesController(CompaniesService compService, JobsService jService)
        {
            _compService = compService;
            _jService = jService;
        }

        [HttpGet]
        public ActionResult<List<Company>> GetAll()
        {
            try
            {
                List<Company> companies = _compService.GetAll();
                return Ok(companies);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpGet("{id}")]
        public ActionResult<Company> GetById(int id)
        {
            try
            {
                Company companies = _compService.GetById(id);
                return Ok(companies);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPost]
        public ActionResult<Company> Create([FromBody] Company companyData)
        {
            try
            {
                Company companies = _compService.Create(companyData);
                return Ok(companyData);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpDelete("{id}")]

        public ActionResult<string> Delete(int id)
        {
            try
            {
                _compService.Remove(id);
                return Ok("delorted");
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        //Jobs

        [HttpGet("{id}/jobs")]
        public ActionResult<Job> GetAllCompanyJobs(int id)
        {
            try
            {
                List<Job> jobs = _jService.GetAllCompanyJobs(id);
                return Ok(jobs);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }


    }
}