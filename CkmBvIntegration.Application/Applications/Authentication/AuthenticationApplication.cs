using AutoMapper;
using CkmBvIntegration.Application.Interfaces.Authentication;
using CkmBvIntegration.Application.TransferObjects.Authentication;
using CkmBvIntegration.Domain.Models.Authentication;
using CkmBvIntegration.Infraestructure.BvNet.Interfaces.Authentication;
using Helpers.Core.Extensions;
using Microsoft.Extensions.Configuration;

namespace CkmBvIntegration.Application.Applications.Authentication
{
    public class AuthenticationApplication : IAuthenticationApplication
    {
        private IMapper _mapper;
        private readonly IAuthenticationRepository _authenticationRepository;
        private AuthenticationResponse _authenticationResponse;
        private readonly IConfiguration _configuration;

        public AuthenticationApplication(IAuthenticationRepository authenticationRepository, IMapper mapper, AuthenticationResponse authenticationResponse, IConfiguration configuration)
        {
            _authenticationRepository = authenticationRepository;
            _mapper = mapper;
            _authenticationResponse = authenticationResponse;            
            _configuration = configuration;
        }
        public async Task<AuthenticationResponseDTO> GenerateTokenAsync()
        {
            if (_authenticationResponse.IsValid)
                return _mapper.Map<AuthenticationResponseDTO>(_authenticationResponse); ;

            var authenticationDTO = new AuthenticationRequestDTO()
            {
                client_id = _configuration.GetValue<string>("Authentication:client_id")!.ToString().DecodeString(),
                client_secret = _configuration.GetValue<string>("Authentication:client_secret")!.ToString().DecodeString(),
                grant_type = _configuration.GetValue<string>("Authentication:grant_type")!.DecodeString()
            };

            var token = await _authenticationRepository.GenerateTokenAsync(_mapper.Map<AuthenticationRequest>(authenticationDTO));

            var newToken = _mapper.Map<AuthenticationResponseDTO>(token);
            newToken.TokenDate = DateTime.UtcNow;

            return newToken;
        }
    }
}
