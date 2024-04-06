using CkmBvIntegration.API.Controllers.Base;
using CkmBvIntegration.Application.Interfaces.Authentication;
using CkmBvIntegration.Application.TransferObjects.Authentication;
using CkmBvIntegration.Domain.Exceptions.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace CkmBvIntegration.API.Controllers.Authentication
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticationController : BaseController
    {
        private ILogger _logger;
        private readonly IAuthenticationApplication _authenticationApplication;
        private readonly AuthenticationExceptions _exceptionMessages;
        public AuthenticationController(
            ILogger<AuthenticationController> logger, 
            IAuthenticationApplication authenticationApplication,
            IOptions<AuthenticationExceptions> exceptionMessages
            ) 
            : base(logger)
        {
            _authenticationApplication = authenticationApplication;
            _exceptionMessages = exceptionMessages.Value;
            _logger = logger;
        }

        [HttpPost("GenerateTokenAsync")]
        public async Task<ActionResult<AuthenticationResponseDTO>> GenerateTokenAsync([FromBody] AuthenticationRequestDTO authenticationDTO)
        {
            return await ExecuteAsync(async () =>
            {
                _logger.LogInformation("Iniciando processo de geração de Token");

                var token = await _authenticationApplication.GenerateTokenAsync(authenticationDTO);

                return token == null ? throw new ArgumentException(_exceptionMessages.ItemNotFound) : token;
            });
        }
    }
}
