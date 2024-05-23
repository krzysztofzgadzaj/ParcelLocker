using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace ParcelLocker.Shared.Infrastructure.Api;

public class GroupByModuleNameDocumentFilter : IDocumentFilter
{
    public void Apply(OpenApiDocument swaggerDoc, DocumentFilterContext context)
    {
        var paths = swaggerDoc.Paths.ToList();
        var newPaths = new OpenApiPaths();

        foreach (var path in paths)
        {
            var pathKey = path.Key;
            var pathItem = path.Value;

            // Extract module name from URL
            var segments = pathKey.Split('/');
            if (segments.Length > 1)
            {
                var moduleName = segments[1];
                var newKey = $"/{moduleName}{pathKey}";

                // Add the path to the new dictionary
                newPaths.Add(newKey, pathItem);
            }
            else
            {
                newPaths.Add(pathKey, pathItem);
            }
        }

        // Clear the existing paths and replace with new paths
        swaggerDoc.Paths.Clear();
        foreach (var path in newPaths.OrderBy(p => p.Key))
        {
            swaggerDoc.Paths.Add(path.Key, path.Value);
        }
    }
}