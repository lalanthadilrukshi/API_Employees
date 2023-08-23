using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AddServices.DTO
{
    public class CompanyDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string FullAddress { get; set; }
    }
}
