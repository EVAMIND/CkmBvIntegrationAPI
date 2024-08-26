using CkmBvIntegration.Domain.Models.PDECOffer;
using CkmBvIntegration.Domain.Models.Proposal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CkmBvIntegration.Infraestructure.BvNet.Interfaces.Proposal
{
    public interface IPDECOfferRepository
    {
        Task<PDECOfferResponse> RequestCreditOfferAsync(PDECOfferRequest pDECOfferRequest, string token);
    }
}
