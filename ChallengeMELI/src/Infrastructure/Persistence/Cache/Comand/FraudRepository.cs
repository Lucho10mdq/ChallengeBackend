using Challenge.MELI.Domain;
using Challenge.MELI.Domain.Interface.Repository.Command;
using Challenge.MELI.Helpers;
using Microsoft.Extensions.Caching.Distributed;
using System;
using System.Threading.Tasks;

namespace Challenge.MELI.Persistence.Cache.Comand
{
    public class FraudRepository : IIFraudeRepository
    {
        private readonly IDistributedCache _distributedCache;
        public FraudRepository(IDistributedCache distributedCache) 
        {
            _distributedCache = distributedCache;
        }
        public async Task AddFraudeAsync(InformationFraudDto informationFraudDto)
        {
            DistributedCacheEntryOptions options = SetTimeCache();
            await _distributedCache.SetAsync(informationFraudDto.Ip, Common.ToByteCache(informationFraudDto), options);
        }

        private static DistributedCacheEntryOptions SetTimeCache()
        {
            return new DistributedCacheEntryOptions()
                                           .SetSlidingExpiration(TimeSpan.FromSeconds(3600));
        }
    }
}
