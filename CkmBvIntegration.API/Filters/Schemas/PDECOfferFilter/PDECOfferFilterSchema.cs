using CkmBvIntegration.Application.TransferObjects.Authentication;
using CkmBvIntegration.Domain.Models.PDECOffer;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace CkmBvIntegration.API.Filters.Schemas.AuthenticationFilter
{
    public class PDECOfferFilterSchema : ISchemaFilter
    {
        public void Apply(OpenApiSchema schema, SchemaFilterContext context)
        {
            Type type = context.Type;

            // Exemplo para a classe AuthenticationRequestDTO
            if (type == typeof(PDECOfferRequest))
            {
                //schema.Properties[nameof(PDECOfferRequest.client_id)].Description = "Client id enviado via email pelo pessoal da BV.";
                //schema.Properties[nameof(PDECOfferRequest.client_secret)].Description = "A senha para login enviada via email pelo pessoal da BV.";
                //schema.Properties[nameof(PDECOfferRequest.grant_type)].Description = "tipo de permissão para acesso (value = client_credentials)";
            }
            // Repita para outras classes conforme necessário
        }
    }
}
