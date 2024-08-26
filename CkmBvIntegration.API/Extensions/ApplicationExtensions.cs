using CkmAuthorizationTools.DTOs.DataTransferObjects.ModuleDTOs;
using Helpers.Core.Extensions;

namespace CkmBvIntegration.API.Extensions;

public static class ApplicationExtensions
{
    /*
    /// <summary>
    /// 
    /// </summary>
    /// <param name="app"></param>
    public static void ConfigureDevEnvironment(this WebApplication app)
    {
        app.UseSwagger();

        var descriptionProvider = app.Services.GetRequiredService<IApiVersionDescriptionProvider>();
        app.UseSwaggerUI(options =>
        {
            // Build a swagger endpoint for each discovered API version
            foreach (var description in descriptionProvider.ApiVersionDescriptions)
            {
                options.SwaggerEndpoint($"{description.GroupName}/swagger.json", $"API - {description.GroupName.ToUpperInvariant()}");
            }
        });
    }*/

    /// <summary>
    /// 
    /// </summary>
    /// <param name="services"></param>
    /// <param name="configuration"></param>
    /// <returns></returns>
    public static async Task<IEnumerable<string>>? GetApplicationPermissions(this IServiceCollection services, IConfiguration configuration)
    {
        try
        {
            var accessApiUri = configuration.GetValue<string>("AccessApiUri")!;

            using (var client = new HttpClient() { BaseAddress = new Uri(accessApiUri) })
            {
                client.AddHeader("api-version", "1.0");

                var permissions = await client.GetFromJsonAsync<IEnumerable<ModulePermission>>($"api/Module/Permissions");

                if (permissions == default)
                    return new List<string>();

                return permissions.Select(r => r.PermissionValue);
            }
        }
        catch
        {
            return new List<string>();
        }
    }
}
