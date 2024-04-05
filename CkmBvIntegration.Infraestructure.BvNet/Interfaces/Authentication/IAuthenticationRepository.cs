using CkmBvIntegration.Domain.Models.Authentication;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CkmBvIntegration.Infraestructure.BvNet.Interfaces.Authentication
{
    public interface IAuthenticationRepository
    {
        Task<AuthenticationResponse> GenerateTokenAsync(AuthenticationRequest authenticationRequest);
    }
}
