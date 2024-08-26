using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CkmBvIntegration.Domain.Models.ProposalStatus
{
    public class ProposalStatusRequest
    {
        public string nuCpfCnpj { get; set; }
        public int cdMeioVenda { get; set; }
        public string nmParceiro { get; set; }
    }
}
