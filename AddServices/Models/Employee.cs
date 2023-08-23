using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace AddServices.Models
{

    [Table("employees")]
    
        public class Employee
    {

            [Key]
            public int Id { get; set; }
       
        public string Name { get; set; } 
        public string Position { get; set; } // for rolebased authentication

        //birhtday
        public string Location { get; set; }
    public float Salary { get; set; }
                      

}
}
