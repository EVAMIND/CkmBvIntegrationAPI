using CkmBvIntegration.Domain.Models.Proposal;
using CkmBvIntegration.Domain.Models.ProposalStatus;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CkmBvIntegration.Infraestructure.BvNet.Interfaces.Proposal
{
    public interface IProposalStatusRepository
    {
        Task<ProposalStatusResponse> GetProposalStatusAsync(ProposalStatusRequest proposalStatusRequest, string token);
    }
}
