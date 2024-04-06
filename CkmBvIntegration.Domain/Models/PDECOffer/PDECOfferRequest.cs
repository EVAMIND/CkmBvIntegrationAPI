using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CkmBvIntegration.Domain.Models.PDECOffer
{
    public class PDECOfferRequest
    {
        public string idOperacaoCliente { get; set; }
        public PDECOfferRequestData dados { get; set; }
    }
}
