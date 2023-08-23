using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AddServices.Models;
namespace AddServices.Contracts
{
    public interface ICompanyRepository
    {
        IEnumerable<Company> GetAllCompanies(bool trackChanges);
    }
}
