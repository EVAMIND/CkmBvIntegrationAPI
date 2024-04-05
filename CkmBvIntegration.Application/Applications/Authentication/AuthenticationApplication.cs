using AutoMapper;
using CkmBvIntegration.Application.Interfaces.Authentication;
using CkmBvIntegration.Application.TransferObjects;
using CkmBvIntegration.Domain.Models.Authentication;
using CkmBvIntegration.Infraestructure.BvNet.Interfaces.Authentication;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CkmBvIntegration.Application.Applications.Authentication
{
    public class AuthenticationApplication : IAuthenticationApplication
    {
        private IMapper _mapper;
        private readonly IAuthenticationRepository _authenticationRepository;
        public AuthenticationApplication(IAuthenticationRepository authenticationRepository, IMapper mapper)
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
