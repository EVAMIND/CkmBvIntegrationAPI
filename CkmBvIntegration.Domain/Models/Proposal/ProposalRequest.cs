using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CkmBvIntegration.Domain.Models.Proposal
{
    public class ProposalRequest
    {

        public string fingerPrint { get; set; }
        public string nome { get; set; }
        public string nomeMae { get; set; }
        public string sexo { get; set; }
        public string codigoProfissao { get; set; }
        public string dataNascimento { get; set; }
        public string cdTipoProfissional { get; set; }
        public ProposalCPF Cpf { get; set; }
        public ProposalRG Rg { get; set; }
        public ProposalEmail Email { get; set; }
        public ProposalMailingAddress EnderecoCorrespondencia { get; set; }
        public ProposalHomeAddress EnderecoResidencial { get; set; }
        public ProposalIncome Renda { get; set; }
        public ProposalCellPhone Celular { get; set; }
        public ProposalPhone Telefone { get; set; }
        public string diaVencimentoFatura { get; set; }
        public string codigoBandeira { get; set; }
        public string codigoTipoCartao { get; set; }
        public List<ProposalCards> listaCartoesAdicionais { get; set; }
        public string cdMeioVenda { get; set; }
        public ProposalPartner Parceiro { get; set; }
        public string nacionalidade { get; set; }
        public string flagPessoaPoliticamenteExposta { get; set; }






    }
}
