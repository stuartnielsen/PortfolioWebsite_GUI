using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.Swagger;
using Swashbuckle.AspNetCore.SwaggerGen;
using System.Reflection;

namespace Portfolio.API.Configuration
{
    [AttributeUsage(AttributeTargets.Property)]
    public class SwaggerBodyIgnore : Attribute, ISchemaFilter
    {
        public void Apply(OpenApiSchema schema, SchemaFilterContext context)
        {
            if (schema?.Properties != null)
            {
                List<OpenApiSchema> properties = schema.Properties.Values.ToList();



                var excludedProperties = context.SchemaRepository.Schemas.Where(property => property.GetType() == typeof(SwaggerBodyIgnore));



                foreach (var excludedProperty in excludedProperties)
                {
                    if (excludedProperty.Key.Length > 0)
                    {
                        string name = char.ToLowerInvariant(excludedProperty.Key[0]) + excludedProperty.Key.Substring(1);
                        if (schema.Properties.ContainsKey(name))
                        {
                            schema.Properties.Remove(name);
                        }
                    }
                }
            }
        }



    }
}