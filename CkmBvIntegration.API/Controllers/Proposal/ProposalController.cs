using AutoMapper;
using CkmBvIntegration.API.Controllers.Base;
using CkmBvIntegration.API.Extensions;
using CkmBvIntegration.Application.Applications.Authentication;
using CkmBvIntegration.Application.Interfaces.Authentication;
using CkmBvIntegration.Application.TransferObjects.Proposal;
using CkmBvIntegration.Domain.Exceptions.Models;
using CkmBVIntegrationApi.DTOs.DataTransferObjects.ProposalDTOs;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace CkmBvIntegration.API.Controllers.Proposal
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class ProposalController : BaseController
    {
        private ILogger _logger;
        private readonly IProposalApplication _proposalApplication;
        private readonly ProposalExceptions _exceptionMessages;
        private IMapper _mapper;
        public ProposalController(
            ILogger<ProposalController> logger, 
            IProposalApplication proposalApplication,
            IOptions<ProposalExceptions> exceptionMessages,
            IMapper mapper) : base(logger)
        {
            _logger = logger;
            _proposalApplication = proposalApplication;
            _exceptionMessages = exceptionMessages.Value;
            _mapper = mapper;
        }

        [HttpPost("RequestCreditCardProposal")]
        public async Task<ActionResult<ProposalResponseView>> RequestCreditCardProposal([FromBody] ProposalRequestView proposalRequestView)
        {
            var token = HttpContext.GetBearerToken();

            if (string.IsNullOrEmpty(token))
                return Unauthorized();

            return await ExecuteAsync(async () =>
            {
                _logger.LogInformation("Iniciando processo de solicitação de proposta");
                                
                ProposalResponseDTO ProposalRequestDTO = await _proposalApplication.RequestCreditCardProposal(_mapper.Map<ProposalRequestDTO>(proposalRequestView), token);

                return ProposalRequestDTO == null ? throw new Exception(_exceptionMessages.UnexpectedError) : _mapper.Map<ProposalResponseView>(ProposalRequestDTO);
            });
        }

    }
}
