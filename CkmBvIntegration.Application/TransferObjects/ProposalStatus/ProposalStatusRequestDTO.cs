using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CkmBvIntegration.Application.TransferObjects.ProposalStatus
{
    public class ProposalStatusRequestDTO
    {
        public string nuCpfCnpj { get; set; }
        public int cdMeioVenda { get; set; }
        public string nmParceiro { get; set; }
    }
}
