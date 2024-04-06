using AutoMapper;
using CkmBvIntegration.Application.Interfaces.PDECOffer;
using CkmBvIntegration.Application.TransferObjects.Proposal;
using CkmBvIntegration.Domain.Models.PDECOffer;
using CkmBvIntegration.Domain.Models.Proposal;
using CkmBvIntegration.Infraestructure.BvNet.Interfaces.Proposal;

namespace CkmBvIntegration.Application.Applications.Authentication
{
    public class PDECOfferApplication : IPDECOfferApplication
    {
        private IMapper _mapper;
        private readonly IPDECOfferRepository _iPDECOfferRepository;
        public PDECOfferApplication(
            IPDECOfferRepository iPDECOfferRepository,
            IMapper mapper)
        {
            _iPDECOfferRepository = iPDECOfferRepository;
            _mapper = mapper;
        }

        public async Task<PDECOfferResponseDTO> RequestCreditOfferAsync(PDECOfferRequestDTO requestDTO, string token)
        {
            PDECOfferResponse response = await _iPDECOfferRepository.RequestCreditOfferAsync(_mapper.Map<PDECOfferRequest>(requestDTO), token);

            return _mapper.Map<PDECOfferResponseDTO>(response);
        }
    }
}
