using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using Constructed.Models;
using Dapper;

namespace Constructed.Repositories
{
    public class ContractorsRepository
    {

        private readonly IDbConnection _db;
        public ContractorsRepository(IDbConnection db)
        {
            _db = db;
        }
        internal List<Contractor> GetAll()
        {
            string sql = @"
            SELECT * FROM contractors;
            ";
            return _db.Query<Contractor>(sql).ToList();
        }

        internal Contractor GetById(int id)
        {
            string sql = @"
            SELECT * FROM contractors
            WHERE id = @id;
            ";
            return _db.Query<Contractor>(sql, new { id }).FirstOrDefault();
        }

        internal Contractor Create(Contractor contractorData)
        {
            string sql = @"
            INSERT INTO contractors
            (name)
            VALUES
            (@Name);
            SELECT LAST_INSERT_ID();
            ";
            int id = _db.ExecuteScalar<int>(sql, contractorData);
            contractorData.Id = id;
            return contractorData;
        }

        internal string Remove(int id)
        {
            string sql = @"
            DELETE FROM contractors
            WHERE id = @id LIMIT 1;
            ";
            int rowsAffected = _db.Execute(sql, new { id });
            if (rowsAffected > 0)
            {
                return "delorted";
            }
            throw new Exception("Nope");
        }
    }
}