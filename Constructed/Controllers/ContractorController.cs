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
    public class ContractorsController : ControllerBase
    {
        private readonly ContractorsService _contService;
        private readonly JobsService _js;
        public ContractorsController(ContractorsService contService, JobsService js)
        {
            _contService = contService;
            _js = js;
        }

        [HttpGet]
        public ActionResult<List<Contractor>> GetAll()
        {
            try
            {
                List<Contractor> contractors = _contService.GetAll();
                return Ok(contractors);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpGet("{id}")]
        public ActionResult<Contractor> GetById(int id)
        {
            try
            {
                Contractor contractor = _contService.GetById(id);
                return Ok(contractor);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPost]
        public ActionResult<Contractor> Create([FromBody] Contractor contractorData)
        {
            try
            {
                Contractor contractor = _contService.Create(contractorData);
                return Ok(contractorData);
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
                _contService.Remove(id);
                return Ok("delorted");
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpGet("{id}/jobs")]
        public ActionResult<Job> GetJobByContractorId(int id)
        {
            try
            {
                List<Job> jobs = _js.GetJobsByContractorId(id);
                return Ok(jobs);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }




    }

}