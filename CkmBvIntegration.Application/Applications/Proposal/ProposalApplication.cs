using AutoMapper;
using CkmBvIntegration.Application.Interfaces.Authentication;
using CkmBvIntegration.Application.TransferObjects.Authentication;
using CkmBvIntegration.Application.TransferObjects.Proposal;
using CkmBvIntegration.Domain.Models.Authentication;
using CkmBvIntegration.Domain.Models.Proposal;
using CkmBvIntegration.Infraestructure.BvNet.Interfaces.Authentication;
using CkmBvIntegration.Infraestructure.BvNet.Interfaces.Proposal;

namespace CkmBvIntegration.Application.Applications.Authentication
{
    public class ProposalApplication : IProposalApplication
    {
        private IMapper _mapper;
        private readonly IProposalRepository _proposalRepository;
        private readonly IAuthenticationApplication _authenticationApplication;
        public ProposalApplication(
            IProposalRepository proposalRepository,
            IMapper mapper)
        {
            _proposalRepository = proposalRepository;
            _mapper = mapper;
        }


        public async Task<ProposalResponseDTO> RequestCreditCardProposal(ProposalRequestDTO proposalRequestDTO, string token)
        {

            var authenticationToken = await _authenticationApplication.GenerateTokenAsync();

            ProposalResponse proposalResponse = await _proposalRepository.RequestCreditCardProposal(_mapper.Map<ProposalRequest>(proposalRequestDTO), authenticationToken.access_token);

            return _mapper.Map<ProposalResponseDTO>(proposalResponse);

        }
    }
}
