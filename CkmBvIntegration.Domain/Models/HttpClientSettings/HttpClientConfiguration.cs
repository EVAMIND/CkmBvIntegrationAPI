using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CkmBvIntegration.Domain.Models.HttpClientSettings
{
    public class HttpClientConfiguration
    {
        public string BaseTokenUrl { get; set; }
        public string BaseProposalURL { get; set; }
        public string BaseStatusURL { get; set; }
        public string BasePDECOfferURL { get; set; }
    }
}
