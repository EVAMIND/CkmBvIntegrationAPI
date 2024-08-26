using CkmBvIntegration.Domain.Models.Proposal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CkmBvIntegration.Infraestructure.BvNet.Interfaces.Proposal
{
    public interface IProposalRepository
    {
        Task<ProposalResponse> RequestCreditCardProposal(ProposalRequest proposalRequest, string token);
    }
}
