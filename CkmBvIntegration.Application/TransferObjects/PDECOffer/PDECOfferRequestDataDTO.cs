using CkmBvIntegration.Domain.Models.PDECOffer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CkmBvIntegration.Application.TransferObjects.Proposal
{
    public class PDECOfferRequestDataDTO
    {
        public string numeroCpf { get; set; }
        public int rendaInformada { get; set; }
        public int rendaPresumida { get; set; }
        public int codigoProfissao { get; set; }
        public int codigoGrupoSubProduto { get; set; }
        public int codigoParceiro { get; set; }
        public string dataDeNascimento { get; set; }
        public int scoreParceiro { get; set; }
        public int scoreParceiro1 { get; set; }
        public int scoreParceiro2 { get; set; }
    }
}
