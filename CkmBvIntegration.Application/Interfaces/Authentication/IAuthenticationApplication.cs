using CkmBvIntegration.Application.TransferObjects.Authentication;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CkmBvIntegration.Application.Interfaces.Authentication
{
    public interface IAuthenticationApplication
    {
        Task<AuthenticationResponseDTO> GenerateTokenAsync(AuthenticationRequestDTO? authenticationDTO);
    }
}
