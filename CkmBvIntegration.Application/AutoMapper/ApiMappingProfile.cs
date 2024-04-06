using AutoMapper;
using CkmBvIntegration.Application.TransferObjects.Authentication;
using CkmBvIntegration.Domain.Models.Authentication;

namespace CkmBvIntegration.Application.AutoMapper;

public class ApiMappingProfile : Profile
{
    public ApiMappingProfile()
    {
        #region Authentication
        CreateMap<AuthenticationRequestDTO, AuthenticationRequest>().ReverseMap();
        CreateMap<AuthenticationResponseDTO, AuthenticationResponse>().ReverseMap();

        #endregion Authentication

    }
}
