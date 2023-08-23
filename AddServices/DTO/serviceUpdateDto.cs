using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AddServices.DTO
{
    public class serviceUpdateDto
    { 
    [Required]
    public String serviceId { get; set; }
   
    
   
    [Required]
    public IFormFile file { get; set; }



}
}
