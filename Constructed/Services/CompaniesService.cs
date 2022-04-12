using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Constructed.Models;
using Constructed.Repositories;

namespace Constructed.Services
{
    public class CompaniesService
    {
        private readonly CompaniesRepository _compRepo;
        public CompaniesService(CompaniesRepository compRepo)
        {
            _compRepo = compRepo;
        }
        internal List<Company> GetAll()
        {
            return _compRepo.GetAll();
        }

        internal Company GetById(int id)
        {
            return _compRepo.GetById(id);
        }

        internal Company Create(Company companyData)
        {
            return _compRepo.Create(companyData);
        }

        internal string Remove(int id)
        {
            return _compRepo.Remove(id);
        }


    }
}