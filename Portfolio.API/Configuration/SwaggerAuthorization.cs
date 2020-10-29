using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;
using System.Reflection;

namespace Portfolio.API.Configuration
{
    [AttributeUsage(AttributeTargets.Method, Inherited = true)]
    public class SwaggerAuthorization : Attribute, IOperationFilter
    {
        public bool Legacy { get; set; } = false;



        public void Apply(OpenApiOperation operation, OperationFilterContext context)
        {
            if (operation.Parameters == null)
            {
                operation.Parameters = new List<OpenApiParameter>();
            }



            if (context.MethodInfo.GetCustomAttribute<SwaggerAuthorization>() != null)
            {
                if (Legacy)
                {
                    operation.Parameters.Insert(0, new OpenApiParameter
                    {
                        Name = "Authorization",
                        In = ParameterLocation.Header,
                        Required = true
                    });
                }
                else
                {
                    operation.Security.Add(new OpenApiSecurityRequirement {
                   {
                     new OpenApiSecurityScheme
                     {
                       Reference = new OpenApiReference
                       {
                         Type = ReferenceType.SecurityScheme,
                         Id = "Bearer",
                       }
                      },
                      new string[] { }
                    }
                  });
                }
            }
        }
    }
}