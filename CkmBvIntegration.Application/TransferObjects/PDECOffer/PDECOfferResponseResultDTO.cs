using CkmBvIntegration.Domain.Models.PDECOffer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CkmBvIntegration.Application.TransferObjects.Proposal
{
    public class PDECOfferResponseResultDTO
    {
        public string numeroCpf { get; set; }
        public string decisao { get; set; }
        public int limiteCalculado { get; set; }
        public string motivoDecisao { get; set; }
        public string vigenciaOferta { get; set; }
    }
}
