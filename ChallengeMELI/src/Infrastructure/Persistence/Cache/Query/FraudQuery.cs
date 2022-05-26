using Challenge.MELI.Domain;
using Challenge.MELI.Domain.Interface.Repository.Query;
using Challenge.MELI.Helpers;
using Microsoft.Extensions.Caching.Distributed;
using System.Threading.Tasks;

namespace Challenge.MELI.Persistence.Cache.Query
{
    public class FraudQuery : IFraudeQuery
    {
        private readonly IDistributedCache _distributedCache;
        public FraudQuery(IDistributedCache distributedCache) 
        {
            _distributedCache = distributedCache;
        }
        public async Task<InformationFraudDto> GetInformationFraudeAsync(string ip)
        {
            InformationFraudDto informationFraudeDto = null;
            var cache = await _distributedCache.GetAsync(ip);

            if(cache != null) 
            {
                return Common.FromByteCache<InformationFraudDto>(cache);

            }

            return informationFraudeDto;
        }
    }
}
