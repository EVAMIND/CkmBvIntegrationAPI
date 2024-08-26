using CkmBvIntegration.Domain.Models.PDECOffer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CkmBvIntegration.Application.TransferObjects.Proposal
{
    public class PDECOfferRequestDTO
    {
        public string idOperacaoCliente { get; set; }
        public PDECOfferRequestDataDTO dados { get; set; }
    }
}
