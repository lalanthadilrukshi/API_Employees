using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AddServices.DTO
{
    public class OwnerImage // for service image must map to front end app/angular interface OwnerImage
    {      
 public int   Id { get; set; }
        // FKServicelds: string;
        public int FKServiceId { get; set; }
      public string ImagePath { get; set; }




    }
}
