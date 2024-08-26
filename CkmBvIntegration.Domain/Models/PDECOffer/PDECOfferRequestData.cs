using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CkmBvIntegration.Domain.Models.PDECOffer
{
    public class PDECOfferRequestData
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
