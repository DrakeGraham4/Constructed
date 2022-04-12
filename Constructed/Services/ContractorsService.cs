using System.Collections.Generic;
using Constructed.Models;
using Constructed.Repositories;

namespace Constructed.Services
{
    public class ContractorsService
    {
        private readonly ContractorsRepository _contRepo;
        public ContractorsService(ContractorsRepository contRepo)
        {
            _contRepo = contRepo;
        }
        internal List<Contractor> GetAll()
        {
            return _contRepo.GetAll();
        }

        internal Contractor GetById(int id)
        {
            return _contRepo.GetById(id);
        }

        internal Contractor Create(Contractor contractorData)
        {
            return _contRepo.Create(contractorData);
        }

        internal string Remove(int id)
        {
            return _contRepo.Remove(id);
        }
    }
}