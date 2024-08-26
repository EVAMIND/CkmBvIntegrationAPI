using CkmBvIntegration.API.Controllers.Authentication;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace CkmBvIntegration.API.Filters.OperationFilter.AuthenticationFilter
{
    public class AuthenticationOperationFilter: IOperationFilter
    {
        public void Apply(OpenApiOperation operation, OperationFilterContext context)
        {
            // Exemplo: Adicionar uma descrição ao corpo da requisição de um método específico
            if (context.MethodInfo.DeclaringType == typeof(AuthenticationController) && context.MethodInfo.Name == "GenerateTokenAsync")
            {
                // Adicionando uma descrição geral para a operação
                operation.Summary = "Utiliza o payload de request para obter um token de autenticação. Este token é usado nas outras requisições da aplicação da BV.";

                // Adicionando ou modificando uma resposta
                operation.Responses.Add("404", new OpenApiResponse { Description = "Não encontrado" });
            }

            if (context.MethodInfo.DeclaringType == typeof(AuthenticationController) &&
               context.MethodInfo.Name == "GenerateTokenAsync")
            {
                // Adicionando uma descrição geral para a operação
                operation.Summary = "Utiliza o payload de request para obter um token de autenticação. Este token é usado nas outras requisições da aplicação da BV.";

                // Adicionando ou modificando uma resposta
                //operation.Responses.Add("404", new OpenApiResponse { Description = "Não encontrado" });
            }


        }
    }
}
