using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CkmBvIntegration.Application.TransferObjects.Proposal
{
    public class ProposalRequestDTO
    {

        public string fingerPrint { get; set; }
        public string nome { get; set; }
        public string nomeMae { get; set; }
        public string sexo { get; set; }
        public string codigoProfissao { get; set; }
        public string dataNascimento { get; set; }
        public string cdTipoProfissional { get; set; }
        public ProposalCPFDTO Cpf { get; set; }
        public ProposalRGDTO Rg { get; set; }
        public ProposalEmailDTO Email { get; set; }
        public ProposalHomeAddressDTO EnderecoResidencial { get; set; }
        public ProposalMailingAddressDTO EnderecoCorrespondencia { get; set; }
        public ProposalIncomeDTO Renda { get; set; }
        public ProposalCellPhoneDTO Celular { get; set; }
        public ProposalPhoneDTO Telefone { get; set; }
        public string diaVencimentoFatura { get; set; }
        public string codigoBandeira { get; set; }
        public string codigoTipoCartao { get; set; }
        public List<ProposalCardsDTO> listaCartoesAdicionais { get; set; }
        public string cdMeioVenda { get; set; }
        public ProposalPartnerDTO Parceiro { get; set; }
        public string nacionalidade { get; set; }
        public string flagPessoaPoliticamenteExposta { get; set; }
   
    
          
       

      
    }
}
