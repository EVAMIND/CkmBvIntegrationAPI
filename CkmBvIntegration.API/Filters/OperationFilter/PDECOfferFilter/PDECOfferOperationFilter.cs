using CkmBvIntegration.API.Controllers.Authentication;
using CkmBvIntegration.API.Controllers.PDECOffer;
using CkmBvIntegration.API.Controllers.Proposal;
using CkmBvIntegration.API.Controllers.ProposalStatus;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace CkmBvIntegration.API.Filters.OperationFilter.AuthenticationFilter
{
    public class PDECOfferOperationFilter : IOperationFilter
    {
        public void Apply(OpenApiOperation operation, OperationFilterContext context)
        {
            // Exemplo: Adicionar uma descrição ao corpo da requisição de um método específico
            if (context.MethodInfo.DeclaringType == typeof(PDECOfferController) && context.MethodInfo.Name == "RequestCreditOfferAsync")
            {
                // Adicionando uma descrição geral para a operação
                operation.Summary = "Solicita oferta de cartão de crédito.";

                // Adicionando ou modificando uma resposta
                operation.Responses.Add("404", new OpenApiResponse { Description = "Não encontrado" });
            }

            if (context.MethodInfo.DeclaringType == typeof(PDECOfferController) &&
               context.MethodInfo.Name == "RequestCreditOfferAsync")
            {
                // Adicionando uma descrição geral para a operação
                operation.Summary = "Solicita oferta de cartão de crédito.";

                // Adicionando ou modificando uma resposta
                //operation.Responses.Add("404", new OpenApiResponse { Description = "Não encontrado" });
            }


        }
    }
}
