using CkmBvIntegration.Application.TransferObjects.Proposal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CkmBvIntegration.Application.Interfaces.PDECOffer
{
    public interface IPDECOfferApplication
    {
        Task<PDECOfferResponseDTO> RequestCreditOfferAsync(PDECOfferRequestDTO requestDTO, string token);
    }
}
