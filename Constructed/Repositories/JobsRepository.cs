using System.Collections.Generic;
using System.Data;
using System.Linq;
using Constructed.Models;
using Dapper;

namespace Constructed.Repositories
{
    public class JobsRepository
    {
        private readonly IDbConnection _db;
        public JobsRepository(IDbConnection db)
        {
            _db = db;
        }
        internal List<Job> GetAllCompanyJobs(int id)
        {
            string sql = @"
            SELECT * FROM jobs j
            WHERE j.companyId = @id;
            ";
            return _db.Query<Job>(sql, new { id }).ToList();
        }

        internal Job Create(Job jobData)
        {
            string sql = @"
            INSERT INTO jobs
            (companyId, contractorId)
            VALUES
            (@CompanyId, @ContractorId);
            SELECT LAST_INSERT_ID();";
            int id = _db.ExecuteScalar<int>(sql, jobData);
            jobData.Id = id;
            return jobData;
        }

        internal List<Job> GetJobsByContractorId(int id)
        {
            string sql = @"
            SELECT * FROM jobs j
            WHERE j.contractorId = @id;
            ";
            return _db.Query<Job>(sql, new { id }).ToList();
        }
    }
}