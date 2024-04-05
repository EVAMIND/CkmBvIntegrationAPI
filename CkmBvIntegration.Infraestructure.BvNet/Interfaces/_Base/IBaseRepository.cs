using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CkmBvIntegration.Infraestructure.BvNet.Interfaces._Base
{
    public interface IBaseRepository<T>
    {
        public Task<string> GetAsync(string uri);
    }
}
