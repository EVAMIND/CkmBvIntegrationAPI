using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CkmBvIntegration.Domain.Models.PDECOffer
{
    public class PDECOfferResponse
    {
        public string idOperacaoCliente { get; set; }
        public PDECOfferResponseResult resultado { get; set; }
    }
}
