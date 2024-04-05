using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CkmBvIntegration.Domain.Models.HttpClientSettings
{
    public class HttpClientConfiguration
    {
        public string BaseTokenUrl { get; set; } = string.Empty;
        public string BaseProposalURL { get; set; } = string.Empty;
        public string BaseStatusURL { get; set; } = string.Empty;
        public string BasePDECOfferURL { get; set; } = string.Empty;
    }
}
