using AutoMapper;
using CkmBvIntegration.Application.TransferObjects.Authentication;
using CkmBvIntegration.Application.TransferObjects.Proposal;
using CkmBvIntegration.Application.TransferObjects.ProposalStatus;
using CkmBvIntegration.Domain.Models.Authentication;
using CkmBvIntegration.Domain.Models.PDECOffer;
using CkmBvIntegration.Domain.Models.Proposal;
using CkmBvIntegration.Domain.Models.ProposalStatus;

namespace CkmBvIntegration.Application.AutoMapper;

public class ApiMappingProfile : Profile
{
    public ApiMappingProfile()
    {
        #region Authentication
            CreateMap<AuthenticationRequestDTO, AuthenticationRequest>().ReverseMap();
            CreateMap<AuthenticationResponseDTO, AuthenticationResponse>().ReverseMap();
        #endregion Authentication

        #region Proposal
            CreateMap<ProposalCardsDTO, ProposalCards>().ReverseMap();
            CreateMap<ProposalCellPhoneDTO, ProposalCellPhone>().ReverseMap();
            CreateMap<ProposalCPFDTO, ProposalCPF>().ReverseMap();
            CreateMap<ProposalEmailDTO, ProposalEmail>().ReverseMap();
            CreateMap<ProposalHomeAddressDTO, ProposalHomeAddress>().ReverseMap();
            CreateMap<ProposalIncomeDTO, ProposalIncome>().ReverseMap();
            CreateMap<ProposalMailingAddressDTO, ProposalMailingAddress>().ReverseMap();
            CreateMap<ProposalPartnerDTO, ProposalPartner>().ReverseMap();
            CreateMap<ProposalPhoneDTO, ProposalPhone>().ReverseMap();
            CreateMap<ProposalRequestDTO, ProposalRequest>().ReverseMap();
            CreateMap<ProposalResponseDTO, ProposalResponse>().ReverseMap();
            CreateMap<ProposalRGDTO, ProposalRG>().ReverseMap();
        #endregion

        #region ProposalStatus
            CreateMap<ProposalStatusRequestDTO, ProposalStatusRequest>().ReverseMap();
            CreateMap<ProposalStatusResponseDTO, ProposalStatusResponse>().ReverseMap();
        #endregion

        #region PDECOffer
            CreateMap<PDECOfferRequestDTO, PDECOfferRequest>().ReverseMap();
            CreateMap<PDECOfferRequestDataDTO, PDECOfferRequestData>().ReverseMap();
            CreateMap<PDECOfferResponseDTO, PDECOfferResponse>().ReverseMap();
            CreateMap<PDECOfferResponseResultDTO, PDECOfferResponseResult>().ReverseMap();
        #endregion

    }
}
