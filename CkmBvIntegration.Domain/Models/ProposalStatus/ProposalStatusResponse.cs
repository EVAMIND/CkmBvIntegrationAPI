namespace CkmBvIntegration.Domain.Models.ProposalStatus
{
    public class ProposalStatusResponse
    {
        public string nuCpfCnpj { get; set; }
        public string email { get; set; }
        public string produtoProposta { get; set; }
        public string statusProposta { get; set; }
        public string dtStatusProposta { get; set; }
        public string dtEntradaProposta { get; set; }
        public string flAtivado { get; set; }
        public string dtAtivacao { get; set; }
    }
}
