using AutoMapper;
using CkmBvIntegration.Application.Interfaces.Authentication;
using CkmBvIntegration.Application.TransferObjects.Authentication;
using CkmBvIntegration.Domain.Models.Authentication;
using CkmBvIntegration.Infraestructure.BvNet.Interfaces.Authentication;

namespace CkmBvIntegration.Application.Applications.Authentication
{
    public class ProposalApplication : IProposalApplication
    {
        private IMapper _mapper;
        private readonly IAuthenticationRepository _authenticationRepository;
        public ProposalApplication(IAuthenticationRepository authenticationRepository, IMapper mapper)
        {
            _authenticationRepository = authenticationRepository;
            _mapper = mapper;
        }
        public async Task<AuthenticationResponseDTO> GenerateTokenAsync(AuthenticationRequestDTO authenticationDTO)
        {
         
            var token = await _authenticationRepository.GenerateTokenAsync(_mapper.Map<AuthenticationRequest>(authenticationDTO));

            return _mapper.Map<AuthenticationResponseDTO>(token);
        }
    }
}
