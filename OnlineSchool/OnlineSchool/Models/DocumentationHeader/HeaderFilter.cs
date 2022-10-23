using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineSchool.Models.DocumentationHeader
{
    [NotMapped]
    public class HeaderFilter :  IOperationFilter
    {
        public void Apply(OpenApiOperation operation, OperationFilterContext context)
        {
            //if (operation.Parameters == null)
            //    operation.Parameters = new List();

            operation.Parameters.Add(new OpenApiParameter
            {
                Name = "ApiKey", // Request header name 
                In = ParameterLocation.Header, // Type of the parameter
                Description = "Use Your JWT-TOKEN", // Description of the parameter
                Required = true,  // Whether it is mandatory or not
                Schema = new OpenApiSchema // Parameter variable format 
                {
                    Type = "string"
                }
            });
        }


    }
}
