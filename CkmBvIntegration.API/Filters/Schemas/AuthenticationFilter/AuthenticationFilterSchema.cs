using CkmBvIntegration.Application.TransferObjects.Authentication;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace CkmBvIntegration.API.Filters.Schemas.AuthenticationFilter
{
    public class AuthenticationFilterSchema : ISchemaFilter
    {
        public void Apply(OpenApiSchema schema, SchemaFilterContext context)
        {
            Type type = context.Type;

            // Exemplo para a classe AuthenticationRequestDTO
            if (type == typeof(AuthenticationRequestDTO))
            {
                schema.Properties[nameof(AuthenticationRequestDTO.client_id)].Description = "Client id enviado via email pelo pessoal da BV.";
                schema.Properties[nameof(AuthenticationRequestDTO.client_secret)].Description = "A senha para login enviada via email pelo pessoal da BV.";
                schema.Properties[nameof(AuthenticationRequestDTO.grant_type)].Description = "tipo de permissão para acesso (value = client_credentials)";
            }
            // Repita para outras classes conforme necessário
        }
    }
}
