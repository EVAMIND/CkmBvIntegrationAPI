using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;

namespace CkmBvIntegration.Application.TransferObjects.ProposalStatus
{
    public class ProposalStatusResponseDTO
    {
         public string nuCpfCnpj {get;set;}
         public string email {get;set;}
         public string produtoProposta {get;set;}
         public string statusProposta {get;set;}
         public string dtStatusProposta {get;set;}
         public string dtEntradaProposta {get;set;}
         public string flAtivado {get;set;}
         public string dtAtivacao { get; set; }
    }
}
