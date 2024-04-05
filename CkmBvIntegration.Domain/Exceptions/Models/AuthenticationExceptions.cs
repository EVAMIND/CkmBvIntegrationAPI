using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CkmBvIntegration.Domain.Exceptions.Models
{
    public class AuthenticationExceptions
    {
        public string ItemNotFound { get; set; }
        public string UnauthorizedAccess { get; set; }
        public string BadRequest { get; set; }
        public string UnexpectedError { get; set; }
    }
}
