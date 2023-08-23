using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using AddServices.Data;
using AddServices.Models;
using Microsoft.AspNetCore.Authorization;
using AddServices.DTO;
using AddServices.Configuration;


using Microsoft.AspNetCore.Mvc; //
using System.Net.Http.Headers; // for file upload
using System.IO;// for file upload

namespace AddServices.Controllers
{
    // [Route("api/[controller]/[action]")] //### when there are many post/put etc
    /*
     [Route("api/[controller]/[action]")]
 public class AccountController : Controller
 {
     [HttpPost, ActionName("Login")]
     public async Task<IActionResult> UserLogin(LoginDto user) { / *..* /
}
}
and the url should look like this
var uri = "............/api/Account/Login"
    */
    [Route("api/[controller]")]  
    [ApiController] 

    /*
    [Route("api/Services")]
    [Authorize] // to allowaccess only to authorized uses
    [ApiController]
    */

    public class ServicesController : ControllerBase
        
    {

        public const String ResourcesPath = "Resources";
        private readonly AddServicesDbContext _context;
        private const int MaxPicCountForUser= 3;
        public ServicesController(AddServicesDbContext context)
        {
            _context = context;
        }

        // GET: api/Services
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Service>>> GetService()
        {
            return await _context.Service.ToListAsync();
        }

        // GET: api/Services/5
        [HttpGet("{id}")]
        public async Task<ActionResult<serviceDTO>> GetService(int id)
             //public async Task<ActionResult<Service>> GetService(int id)
        {
           // var service = await _context.Service.FindAsync(id);
           var service = await _context.Service.Include(Im => Im.Service_Images).FirstOrDefaultAsync(m => m.Id == id);

          
            if (service == null)
            {
                return NotFound();
            }

            serviceDTO model = new serviceDTO();
            convertServiceToServiceDTO(model, service);
            //model.imagepath = "Resources/ServicePics/1_1";
            model.imagepath = "Resources/ServicePics/1.jpg";
            return model;
            //return service;
        }

        // PUT: api/Services/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
       // [HttpPut("{id}")] //### when there is only one put
       // [HttpPut("{id}"), Route("UpdateService")] //##not successful
       // [HttpPut("{id}", Name = nameof(PutService))]
        [HttpPut("PutService/{id}")]
        // public async Task<IActionResult> UpdateService(int id, Service service)
        public async Task<IActionResult> PutService(int id, serviceDTO model)
        {

            var service = new Service();
            service.Name = model.Name;
            service.PhoneNumber = model.PhoneNumber;
            service.FKSubCategoryId = ModelBuilderExtenstions.SubCategoryIdSoftwareEngineer; //### if the referenced table does not contain the foreign key the record wont be committed
            service.FKUserId = AdminConfiguration.adminId;//### if the referenced table does not contain the foreign key the record wont be committed
            service.FKVillageId = ModelBuilderExtenstions.VillageIdPettah;//### if the referenced table does not contain the foreign key the record wont be committed
            service.RegisterDate = DateTime.Now; // ## if date is null the record wont be committed to the database
            service.LastUpdateDate = DateTime.Now; // ## if date is null the record wont be committed to the database
            service.Id = model.Id;

            if (id != service.Id)
            {
                return BadRequest();
            }

            _context.Entry(service).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ServiceExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
                      return NoContent();
        }

        // POST: api/Services
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754

        private static void convertServiceToServiceDTO(serviceDTO model, Service service)
        {
            model.Id =service.Id;
            model.Name =service.Name;
            model.PhoneNumber = service.PhoneNumber;
            model.FKSubCategoryId = service.FKSubCategoryId;
            model.FKUserId = service.FKUserId;
            model.FKVillageId = service.FKVillageId;
            model.RegisterDate = service.RegisterDate;
            model.LastUpdateDate = service.LastUpdateDate;

            var addcount = service.Service_Images.Count;
            model.OwnerImages = new OwnerImage[addcount];
            for (int i = 0; i < addcount; i++)// in the view (.cshtml) if the photopath is empty, that Service_Image item wont be added to the page, there fore in the return list of Service_Image s (in the Model)  , the  item will not be there 
            {
                OwnerImage oi = new OwnerImage();// model.OwnerImages[i];
                model.OwnerImages[i] = oi;
                Service_Image si = service.Service_Images[i];
                oi.Id = si.Id;
                oi.ImagePath = si.ImagePath;
                oi.FKServiceId = si.FKServiceId;
               // oi.LastUpdateDate = si.LastUpdateDate;

               
            }

        }
        [HttpPost] //##to create service and service_images 

       
        public async Task<ActionResult<serviceDTO>> PostService([FromBody] serviceDTO model)

           //  public async Task<ActionResult<Service>> PostService(Service service)
        {


            try
            {
                var service = new Service();
                service.Name = model.Name;
                service.PhoneNumber = model.PhoneNumber;
                service.FKSubCategoryId = ModelBuilderExtenstions.SubCategoryIdSoftwareEngineer; //### if the referenced table does not contain the foreign key the record wont be committed
                service.FKUserId = AdminConfiguration.adminId;//### if the referenced table does not contain the foreign key the record wont be committed
                service.FKVillageId = ModelBuilderExtenstions.VillageIdPettah;//### if the referenced table does not contain the foreign key the record wont be committed
                service.RegisterDate = DateTime.Now; // ## if date is null the record wont be committed to the database
                service.LastUpdateDate = DateTime.Now; // ## if date is null the record wont be committed to the database


                service.Id = 0; // if Id is not zero , the primary key cant be set manually and there will be an sql exception
                
             

                // imagleist
                
               

                // imagleist

                int maxCount = MaxPicCountForUser;
                int addcount = maxCount - service.Service_Images.Count;
                for (int i = 0; i < addcount; i++)// in the view (.cshtml) if the photopath is empty, that Service_Image item wont be added to the page, there fore in the return list of Service_Image s (in the Model)  , the  item will not be there 
                {

/*
                    var si = _context.Service_Images.Add(new Service_Image()
                    {
                        ImagePath = "",
                        FKServiceId = service.Id,
                        LastUpdateDate = DateTime.MinValue

                    }).Entity;
                    */
                    var si = new Service_Image()
                    {
                        ImagePath = "",
                        FKServiceId = service.Id,
                        LastUpdateDate = DateTime.Now , //''DateTime.MinValue
                    };
                   
                    service.Service_Images.Insert(0, si);
                }

                _context.Service.Add(service);
                await _context.SaveChangesAsync();
                convertServiceToServiceDTO(model, service);

                return CreatedAtAction("GetService", new { id = service.Id }, model);


                //return CreatedAtAction("GetService", new { id = service.Id }, service);  //### do not return objects with complex data types . there will be an error in jason conversion
            }
            catch (Exception e)
            {
                return null;

            }
            // return CreatedAtAction("GetService", new { id = service.Id }, service);
        }


      





            

        // DELETE: api/Services/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteService(int id)
        {
            var service = await _context.Service.FindAsync(id);
            if (service == null)
            {
                return NotFound();
            }

            _context.Service.Remove(service);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ServiceExists(int id)
        {
            return _context.Service.Any(e => e.Id == id);
        }

        /*
        [HttpPost, DisableRequestSizeLimit]
        public IActionResult Upload()
        {
            try
            {
                var files = Request.Form.Files;
                var folderName = Path.Combine("StaticFiles", "Images");
                var pathToSave = Path.Combine(Directory.GetCurrentDirectory(), folderName);

                if (files.Any(f => f.Length == 0))
                {
                    return BadRequest();
                }

                foreach (var file in files)
                {
                    var fileName = ContentDispositionHeaderValue.Parse(file.ContentDisposition).FileName.Trim('"');
                    var fullPath = Path.Combine(pathToSave, fileName);
                    var dbPath = Path.Combine(folderName, fileName); //you can add this path to a list and then return all dbPaths to the client if require

                    using (var stream = new FileStream(fullPath, FileMode.Create))
                    {
                        file.CopyTo(stream);
                    }
                }

                return Ok("All the files are successfully uploaded.");
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Internal server error");
            }
        }
        */
       // [HttpPut("{id}")]
             
        [HttpPut("Uploadfile/{id}")]// successful url hit with swager (but not internal code of the method). use '[name]/{id} ' when there are more than one httpput


       // [HttpGet("GetByUrlSlag/{urlSlag}")]
       // public IActionResult GetByUrlSlag([FromQuery] string urlSlag)
      
            public async Task<string> Uploadfile(int id, IFormFile file)
        // public async Task<string> UploadProfilePicture([FromForm(Name = "uploadedFile")] IFormFile file, long userId)
        {
            //### in startup : IOperationFilter
            //### in startup app.UseStaticFiles(new StaticFileOptions() // for file upload
            if (file == null || file.Length == 0)
                //throw new UserFriendlyException("Please select profile picture");
            throw new Exception("Please select profile picture");
            var folderName = Path.Combine(ResourcesPath, "ProfilePics");
            var filePath = Path.Combine(Directory.GetCurrentDirectory(), folderName);

            if (!Directory.Exists(filePath))
            {
                Directory.CreateDirectory(filePath);
            }

            //var fileUniqueId = Guid.NewGuid().ToString().ToLower().Replace("-", string.Empty);
            var uniqueFileName = $"{id}_profilepic.png";
           // var uniqueFileName = $"{serviceId}_.png";

            var dbPath = Path.Combine(folderName, uniqueFileName);

            using (var fileStream = new FileStream(Path.Combine(filePath, uniqueFileName), FileMode.Create))
            {
                await file.CopyToAsync(fileStream);
            }

            return dbPath;
        }

       // [HttpPost, DisableRequestSizeLimit]
        //[HttpPost("Uploadfile/{id}"), DisableRequestSizeLimit]
       // [HttpPost("Uploadfile"), DisableRequestSizeLimit]
        [HttpPost("Uploadfile")]
        //###  https://localhost:44343/api/Services/Uploadfile // successful with swagger and angular  front end
        
        //[FromForm] links formData from frontend
        public async Task<IActionResult> Upload([FromForm] serviceUpdateDto dto)//IFormCollection data)// or try [FromForm] string serviceId ) // or you can give a model
        {
            Dictionary<string, string> resp = new Dictionary<string, string>();
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                //getting user from the database
                // var user = await _context.Users.FindAsync(userProfileModel.UserId);
                //if (user != null)
                //{
                var folderName = Path.Combine(ResourcesPath, "ServicePics");
                var path = Path.Combine(Directory.GetCurrentDirectory(), folderName);
                // var path = Path.Combine(_hostingEnvironment.WebRootPath, "images/");

                //checking if folder not exist then create it
                if ((!Directory.Exists(path)))
                {
                    Directory.CreateDirectory(path);
                }
                //getting file name and combine with path and save it
                var file = dto.file; // formCollection.Files.First();
                int imageCount = 1;
                String serviceId = dto.serviceId;
                //var fullPath = Path.Co mbine(pathToSave, fileName);


                string filename = serviceId + "_" + imageCount;// userProfileModel.Image.FileName;
                var dbPath = Path.Combine(folderName, filename);
                using (var fileStream = new FileStream(Path.Combine(path, filename), FileMode.Create))
                {
                    await file.CopyToAsync(fileStream);
                }
                // user.ProfilePicture = "/images/" + filename;
                //user.UpdatedAt = DateTime.UtcNow;
                // await _context.SaveChangesAsync();
                //adding image url dictionery for returning in response
                resp.Add("imageurl ", dbPath);//user.ProfilePicture);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            return Ok(resp);
}
    
          

        



        /*

        // POST api/values
        [HttpPost]
        public void Post(IFormFile file)
        {
            //TODO:Save file...
        }
        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, IFormFile file)
        {
            //TODO:Save file...
        }

        */


    }
}

/*
 * using System;  
using System.Threading.Tasks;  
using Microsoft.AspNetCore.Http;  
using Microsoft.AspNetCore.Mvc;  
using System.IO;  
namespace FileUploadSample.Controllers  
{  
[Route("[controller]")]  
public class UploadsController : ControllerBase  
{  
const String folderName = "files";  
readonly String folderPath = Path.Combine(Directory.GetCurrentDirectory(), folderName);  
public UploadsController()  
  {  
            if (!Directory.Exists(folderPath))  
            {  
                Directory.CreateDirectory(folderPath);  
            }  
        }  
  
        [HttpPost]  
        public async Task<IActionResult> Post(  
            [FromForm(Name = "myFile")]IFormFile myFile)  
        {  
                using (var fileContentStream = new MemoryStream())  
                {  
                    await myFile.CopyToAsync(fileContentStream);  
                    await System.IO.File.WriteAllBytesAsync(Path.Combine(folderPath, myFile.FileName), fileContentStream.ToArray());  
                }  
                return CreatedAtRoute(routeName: "myFile", routeValues: new { filename = myFile.FileName }, value: null); ;  
        }  
  
        [HttpGet("{filename}", Name = "myFile")]  
        public async Task<IActionResult> Get([FromRoute] String filename)  
        {  
            var filePath = Path.Combine(folderPath, filename);  
            if (System.IO.File.Exists(filePath))  
            {  
                return File(await System.IO.File.ReadAllBytesAsync(filePath), "application/octet-stream", filename);  
            }  
            return NotFound();  
        }  
    }  
}  
*/
      
