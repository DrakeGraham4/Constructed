using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Constructed.Models;
using Constructed.Repositories;

namespace Constructed.Services
{
    public class JobsService
    {
        private readonly JobsRepository _jRepo;
        public JobsService(JobsRepository jRepo)
        {
            _jRepo = jRepo;
        }
        internal List<Job> GetAllCompanyJobs(int id)
        {
            return _jRepo.GetAllCompanyJobs(id);
        }

        internal Job Create(Job jobData)
        {
            return _jRepo.Create(jobData);
        }

        internal List<Job> GetJobsByContractorId(int id)
        {
            return _jRepo.GetJobsByContractorId(id);
        }
    }
}