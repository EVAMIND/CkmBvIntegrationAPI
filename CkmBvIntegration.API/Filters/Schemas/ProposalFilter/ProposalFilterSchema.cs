using CkmBvIntegration.Application.TransferObjects.Authentication;
using CkmBvIntegration.Application.TransferObjects.Proposal;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace CkmBvIntegration.API.Filters.Schemas.AuthenticationFilter
{
    public class ProposalFilterSchema : ISchemaFilter
    {
        public void Apply(OpenApiSchema schema, SchemaFilterContext context)
        {
            Type type = context.Type;

            // Exemplo para a classe AuthenticationRequestDTO
            if (type == typeof(ProposalRequestDTO))
            {
                //schema.Properties[nameof(ProposalRequestDTO.)].Description = "Client id enviado via email pelo pessoal da BV.";
                //schema.Properties[nameof(ProposalRequestDTO.)].Description = "A senha para login enviada via email pelo pessoal da BV.";
                //schema.Properties[nameof(ProposalRequestDTO.)].Description = "tipo de permissão para acesso (value = client_credentials)";
            }
            // Repita para outras classes conforme necessário
        }
    }
}
