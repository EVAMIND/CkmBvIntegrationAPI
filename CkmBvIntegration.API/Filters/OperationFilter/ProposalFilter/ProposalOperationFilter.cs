using CkmBvIntegration.API.Controllers.Authentication;
using CkmBvIntegration.API.Controllers.Proposal;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace CkmBvIntegration.API.Filters.OperationFilter.AuthenticationFilter
{
    public class ProposalOperationFilter : IOperationFilter
    {
        public void Apply(OpenApiOperation operation, OperationFilterContext context)
        {
            // Exemplo: Adicionar uma descrição ao corpo da requisição de um método específico
            if (context.MethodInfo.DeclaringType == typeof(ProposalController) && context.MethodInfo.Name == "RequestCreditCardProposal")
            {
                // Adicionando uma descrição geral para a operação
                operation.Summary = "Solicita proposta de Cartão de Crédito.";

                // Adicionando ou modificando uma resposta
                operation.Responses.Add("404", new OpenApiResponse { Description = "Não encontrado" });
            }

            if (context.MethodInfo.DeclaringType == typeof(ProposalController) &&
               context.MethodInfo.Name == "RequestCreditCardProposal")
            {
                // Adicionando uma descrição geral para a operação
                operation.Summary = "Solicita proposta de Cartão de Crédito.";

                // Adicionando ou modificando uma resposta
                //operation.Responses.Add("404", new OpenApiResponse { Description = "Não encontrado" });
            }


        }
    }
}
