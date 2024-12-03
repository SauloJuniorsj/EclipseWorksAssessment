using Microsoft.OpenApi.Any;
using Microsoft.OpenApi.Extensions;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace EclipseWorksAssessment.WebAPI
{
    public class EnumSchemaFilter : ISchemaFilter
    {
        public void Apply(OpenApiSchema schema, SchemaFilterContext context)
        {
            if (context.Type.IsEnum)
            {
                schema.Enum = Enum.GetValues(context.Type)
                    .Cast<Enum>()
                    .Select(e => new OpenApiString($"{e:D} - {e.GetDisplayName()}"))
                    .ToList<IOpenApiAny>();
            }
        }
    }
}
