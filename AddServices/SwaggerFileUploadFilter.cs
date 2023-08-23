
using Swashbuckle.AspNetCore.Swagger;  
using Swashbuckle.AspNetCore.SwaggerGen;  
using System.Collections.Generic;  
  
namespace AddServices
{
    public class SwaggerFileUploadFilter //: IOperationFilter
    {
        /*
            public void Apply(Operation operation, OperationFilterContext context)
            {
                if (operation.OperationId == "Post")
                {
                    operation.Parameters = new List<IParameter>
                {
                    new NonBodyParameter
                    {
                        Name = "myFile",
                        Required = true,
                        Type = "file",
                        In = "formData"
                    }
                };
                }
            }
         */
    }

}  