using CkmBvIntegration.API.Controllers.Base;
using CkmBvIntegration.API.Extensions;
using CkmBvIntegration.Application.Interfaces.ProposalStatus;
using CkmBvIntegration.Application.TransferObjects.ProposalStatus;
using CkmBvIntegration.Domain.Exceptions.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace CkmBvIntegration.API.Controllers.ProposalStatus
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProposalStatusController : BaseController
    {
        private ILogger _logger;
        private readonly IProposalStatusApplication _proposalStatusApplication;
        public ProposalStatusController(
            ILogger<ProposalStatusController> logger,
            IOptions<ProposalStatusExceptions> exceptionMessages,
            IProposalStatusApplication proposalStatusApplication) : base(logger)
        {
            _proposalStatusApplication = proposalStatusApplication;
            _logger = logger;
        }

        [HttpPost("GetProposalStatusAsync")]
        public async Task<ActionResult<ProposalStatusResponseDTO>> GetProposalStatusAsync([FromBody] ProposalStatusRequestDTO proposalStatusRequestDTO)
        {
            var token = HttpContext.GetBearerToken();

            if (string.IsNullOrEmpty(token))
            {
                return Unauthorized();
            }

            return await ExecuteAsync(async () =>
            {
                ProposalStatusResponseDTO responseDTO = await _proposalStatusApplication.GetProposalStatusAsync(proposalStatusRequestDTO, token);

                return responseDTO == null ? throw new Exception("") : responseDTO;
            });
        }
    }
}
