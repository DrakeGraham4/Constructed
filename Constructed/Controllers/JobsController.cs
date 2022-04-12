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
    public class JobsController : ControllerBase
    {
        private readonly JobsService _jService;
        public JobsController(JobsService jService)
        {
            _jService = jService;
        }

        [HttpPost]
        public ActionResult<Job> Create([FromBody] Job jobData)
        {
            try
            {
                Job job = _jService.Create(jobData);
                return Ok(jobData);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }

        }
    }
}