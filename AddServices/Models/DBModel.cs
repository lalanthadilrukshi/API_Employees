



using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Security.Claims;
using Microsoft.AspNetCore.Http;

namespace AddServices.Models
{
    public class DBModel
    {
    }




    [Table("Province")]
    public class Province
    {
        [Key]
        public int Id { get; set; }
        public string Name
        {
            get; set;
        }

        public ICollection<District> Districts { get; set; }
    }

    [Table("District")]
    public class District
    {
        [Key]
        public int Id { get; set; }
        [ForeignKey("Province")]
        public int FKProvinceId { get; set; }
        public string Name { get; set; }

        public Province Province
        {
            get; set;
        }
        public ICollection<City> Citys { get; set; }



    }


    [Table("City")]// local government area (eg - kaduwela )
    public class City
    {
        [Key]
        public int Id { get; set; }
        [ForeignKey("District")]
        public int FKDistrictId { get; set; }
        public string Name { get; set; }

        public District District
        {
            get; set;
        }
        public ICollection<Village> Villages { get; set; }
    }

    [Table("Village")]
    public class Village // there can be many villages connected to the city/local government
    {
        [Key]
        public int Id { get; set; }
        [ForeignKey("City")]
        public int FKCityId { get; set; }
        public string Name { get; set; }

        public City City
        {
            get; set;
        }
        public ICollection<Service> Services { get; set; }
    }



    [Table("MainCategory")]
    public class MainCategory
    {
        [Key]
        public int Id { get; set; }

        public string Name { get; set; }

        public ICollection<SubCategory> SubCategorys { get; set; }

    }


    [Table("SubCategory")]
    public class SubCategory
    {
        [Key]
        public int Id { get; set; }
        [ForeignKey("MainCategory")]
        public int FKCategoryId { get; set; }
        public string Name { get; set; }
        public MainCategory MainCategory
        {
            get; set;
        }
        public ICollection<Service> Services { get; set; }

    }



    public class ApplicationUser : IdentityUser
    {
        //public virtual Service Service { get;  set; }
        // [Required(ErrorMessage="Please enter a name")] // if you state that this is required there will be an exception when login
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string ImagePath { get; set; }


        // pass word and confirm password is used if identity scaffolding is not done
        // [Required]
        // [StringLength(255, ErrorMessage = "Must be between 5 and 255 characters", MinimumLength = 5)]
        //[DataType(DataType.Password)]
        // public string Password { get; set; }

        /*
        [NotMapped] // only for details/edit view, not for database
        [Required]
        [StringLength(255, ErrorMessage = "Must be between 5 and 255 characters", MinimumLength = 5)]
        [DataType(DataType.Password)]
        [Compare("Password")]
        public string ConfirmPassword { get; set; }

*/
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime BirthDate { get; set; }
        //public byte[] ProfilePicture { get; set; }
        public virtual ICollection<Service> Services { get; set; }

    }



    [Table("Service")]
    public class Service
    {
        [Key]
        public int Id { get; set; }
        [ForeignKey("Village")]
        public int FKVillageId { get; set; }

        [ForeignKey("SubCategory")]
        public int FKSubCategoryId { get; set; }

        [ForeignKey("ApplicationUser")]// one user (with ability to register /login) will have many services to offer
        public string FKUserId { get; set; }

        // [DataType(DataType.Date)]
        // [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        //public DateTime BirthDate { get; set; }


        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime RegisterDate { get; set; }


        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime LastUpdateDate { get; set; }


        public string Name { get; set; } //## can include short title

        public string email { get; set; }

        // [DataType(DataType.PhoneNumber)]

        // public string PhoneNumber { get; set; }
        [Phone] public string PhoneNumber { get; set; }
        // public string contact { get; set; }

        public string workExperience { get; set; }
        public string Qualifications { get; set; }
        public string jobDescription { get; set; } // and otherdetails
        //# add address before next migration
        //public string Address { get; set; } // for saloons
        public string rates { get; set; }

        [NotMapped] // only for details/edit view, not for database
        public Boolean EditMode = false;
        public Village Village
        {
            get; set;
        }
        public SubCategory SubCategory
        {
            get; set;
        }

        public Service()
        {

            Service_Images = new List<Service_Image>();
        }

        // public virtual ApplicationUser User { get; set; }
        public ApplicationUser User { get; set; }

        //[ForeignKey("ApplicationUser")]
        //public string ApplicationUserID { get; set; }


        // public  ICollection<Service_Image> Service_Images { get; set; }
        public List<Service_Image> Service_Images { get; set; }
        /*[NotMapped] // the following is not mapped to a column in database table
        public List<IFormFile> files { get; set; }*/
    }
    [Table("Service_Image")]
    public class Service_Image // a service has many images
    {
        [Key]
        public int Id { get; set; } // this key is not necessary but on migration  , there will be an error message The entity type 'Service_Image' requires a primary key to be defined. If you intended to use a keyless entity type, call 'HasNoKey' in 'OnModelCreating'. For more information on keyless entity types, see https://go.microsoft.com/fwlink/?linkid=2141943.

        [ForeignKey("Service")]// set foreign key in 'OnModelCreating' in dbcontext file otherwise auto FK is generated
        //### refer    modelBuilder.Entity<Service_Image>()       AddServicesDbContext  OnModelCreating(   for 1 to many relationship configure for delete, add , etc cascade
        public int FKServiceId { get; set; }// int? is not nullable //Nullable<int> or int?
        //public int? FKServiceId { get; set; }// int? is not nullable //Nullable<int> or int?
        public string ImagePath { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime LastUpdateDate { get; set; }// date is required when needed to replace old images with new ones

        public Service service { get; set; }

    }
    /*
        [Table("Image")]
        public class ImageModel

        {
            [Key]
            public int Id { get; set; }
            [ForeignKey("Service")]
            public int FKServiceId { get; set; }
            [Column(TypeName = "nvarchar(50)")]
            public string Title { get; set; }
            [Column(TypeName = "nvarchar(100)")]
            public string ImageName { get; set; }

            [NotMapped]// to prevent adding a column to table
            [DisplayName("Upload File")]
            public IFormFile ImageFile { get; set; }

        }

    */
}

