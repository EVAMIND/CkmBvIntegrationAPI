using CkmBvIntegration.API.Controllers.Authentication;
using CkmBvIntegration.API.Controllers.Base;
using CkmBvIntegration.Application.Interfaces.Authentication;
using CkmBvIntegration.Domain.Exceptions.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace CkmBvIntegration.API.Controllers.Proposal
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProposalController : BaseController
    {
        private ILogger _logger;
        private readonly IProposalApplication _proposalApplication;
        public ProposalController(
            ILogger<ProposalController> logger, 
            IProposalApplication proposalApplication,
            IOptions<AuthenticationExceptions> exceptionMessages) : base(logger)
        {
            _logger = logger;
            _proposalApplication = proposalApplication;
        }


    }
}
