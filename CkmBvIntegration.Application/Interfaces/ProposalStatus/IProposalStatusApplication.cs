using CkmBvIntegration.Application.TransferObjects.ProposalStatus;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CkmBvIntegration.Application.Interfaces.ProposalStatus
{
    public interface IProposalStatusApplication
    {
        Task<ProposalStatusResponseDTO> GetProposalStatusAsync(ProposalStatusRequestDTO proposalStatusRequestDTO, string token);
    }
}
