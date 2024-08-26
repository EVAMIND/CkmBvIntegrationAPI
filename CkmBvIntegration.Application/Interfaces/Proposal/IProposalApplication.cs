using CkmBvIntegration.Application.TransferObjects.Authentication;
using CkmBvIntegration.Application.TransferObjects.Proposal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CkmBvIntegration.Application.Interfaces.Authentication
{
    public interface IProposalApplication
    {
        Task<ProposalResponseDTO> RequestCreditCardProposal(ProposalRequestDTO proposalRequestDTO, string token);
    }
}
