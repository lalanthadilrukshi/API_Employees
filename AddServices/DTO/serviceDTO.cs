using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
namespace AddServices.DTO
{
    public class serviceDTO
    {      
        public int Id { get; set; }
        public int FKVillageId { get; set; }
        public int FKSubCategoryId { get; set; }
      public string FKUserId { get; set; }
        public DateTime RegisterDate { get; set; }
        public DateTime LastUpdateDate { get; set; }
        public string Name { get; set; }
        public string email { get; set; }
        [Required(ErrorMessage = "phone number is required.")]
        public string PhoneNumber { get; set; }
       
        // public string contact { get; set; }

        public string workExperience { get; set; }
        public string Qualifications { get; set; }
        public string jobDescription { get; set; } // and otherdetails
        public string rates { get; set; }
              
        public Boolean EditMode = false;
        public Microsoft.AspNetCore.Http.IFormFile[] photos { get; set; }
      public  OwnerImage[] OwnerImages { get; set; }

        // temp for testing image download
        public string imagepath  { get; set; }


}
}
