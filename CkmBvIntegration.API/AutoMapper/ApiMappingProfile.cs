using AutoMapper;
using CkmBvIntegration.Application.TransferObjects.Proposal;
using CkmBvIntegration.Domain.Models.Proposal;
using CkmBVIntegrationApi.DTOs.DataTransferObjects.ProposalDTOs;

namespace CkmBVIntegration.API.AutoMapper;

public class ApiMappingProfile : Profile
{
    public ApiMappingProfile()
    {
       
        CreateMap<ProposalRequestDTO, ProposalRequestView>().ReverseMap();
        CreateMap<ProposalResponseDTO, ProposalResponseView>().ReverseMap();

        CreateMap<ProposalCardsDTO, ProposalCardsView>().ReverseMap();
        CreateMap<ProposalCellPhoneDTO, ProposalCellPhoneView>().ReverseMap();
        CreateMap<ProposalCPFDTO, ProposalCPFView>().ReverseMap();
        CreateMap<ProposalEmailDTO, ProposalEmailView>().ReverseMap();
        CreateMap<ProposalHomeAddressDTO, ProposalHomeAddressView>().ReverseMap();
        CreateMap<ProposalIncomeDTO, ProposalIncomeView>().ReverseMap();
        CreateMap<ProposalMailingAddressDTO, ProposalMailingAddressView>().ReverseMap();
        CreateMap<ProposalPartnerDTO, ProposalPartnerView>().ReverseMap();
        CreateMap<ProposalPhoneDTO, ProposalPhoneView>().ReverseMap();        
        CreateMap<ProposalRGDTO, ProposalRGView>().ReverseMap();
    }
}
