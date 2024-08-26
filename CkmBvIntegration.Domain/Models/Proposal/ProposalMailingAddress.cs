using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CkmBvIntegration.Domain.Models.Proposal
{
    public class ProposalMailingAddress
    {
        public string cep { get; set; }
        public string logradouro { get; set; }
        public string numero { get; set; }
        public string bairro { get; set; }
        public string complemento { get; set; }
        public string cidade { get; set; }
        public string uf { get; set; }
        public string flagEnderecoCorrespondencia { get; set; }
        public string tipoEndereco { get; set; }
    }
}
