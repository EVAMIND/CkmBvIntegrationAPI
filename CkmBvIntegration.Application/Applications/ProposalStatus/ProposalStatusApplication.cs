using AutoMapper;
using CkmBvIntegration.Application.Interfaces.Authentication;
using CkmBvIntegration.Application.Interfaces.ProposalStatus;
using CkmBvIntegration.Application.TransferObjects.Proposal;
using CkmBvIntegration.Application.TransferObjects.ProposalStatus;
using CkmBvIntegration.Domain.Models.Proposal;
using CkmBvIntegration.Domain.Models.ProposalStatus;
using CkmBvIntegration.Infraestructure.BvNet.Interfaces.Proposal;
using CkmBvIntegration.Infraestructure.BvNet.Repositories.ProposalRepository;
using Newtonsoft.Json.Linq;

namespace CkmBvIntegration.Application.Applications.Authentication
{
    public class ProposalStatusApplication : IProposalStatusApplication
    {
        private IMapper _mapper;
        private readonly IProposalStatusRepository _proposalStatusRepository;
        public ProposalStatusApplication(
            IProposalStatusRepository proposalStatusRepository,
            IMapper mapper)
        {
            _proposalStatusRepository = proposalStatusRepository;
            _mapper = mapper;
        }

        public async Task<ProposalStatusResponseDTO> GetProposalStatusAsync(ProposalStatusRequestDTO proposalStatusRequestDTO, string token)
        {
            ProposalStatusResponse proposalStatusResponse = await _proposalStatusRepository.GetProposalStatusAsync(_mapper.Map<ProposalStatusRequest>(proposalStatusRequestDTO), token);

            return _mapper.Map<ProposalStatusResponseDTO>(proposalStatusResponse);
        }
    }
}
