using Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Services.Interfaces
{
    public interface IProviderService
    {
        public List<Provider> GetProviders();
        public Provider GetProviderByID(int ProviderID);
        public void CreateProvider(Provider provider);
    }
}
