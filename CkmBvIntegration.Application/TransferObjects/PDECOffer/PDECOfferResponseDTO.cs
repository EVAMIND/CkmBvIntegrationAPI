using CkmBvIntegration.Domain.Models.PDECOffer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CkmBvIntegration.Application.TransferObjects.Proposal
{
    public class PDECOfferResponseDTO
    {
        public string idOperacaoCliente { get; set; }
        public PDECOfferResponseResultDTO resultado { get; set; }
    }
}
