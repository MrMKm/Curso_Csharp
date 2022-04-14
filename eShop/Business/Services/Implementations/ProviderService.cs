using Business.Services.Interfaces;
using Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Services.Implementations
{
    public class ProviderService : IProviderService
    {
        private List<Provider> providersList = TestData.ProvidersList;

        public void CreateProvider(Provider provider)
        {
            providersList.Add(provider);
        }

        public Provider GetProviderByID(int ProviderID)
        {
            return providersList
                .FirstOrDefault(p => p.ID.Equals(ProviderID));
        }

        public List<Provider> GetProviders()
        {
            return providersList;
        }
    }
}
