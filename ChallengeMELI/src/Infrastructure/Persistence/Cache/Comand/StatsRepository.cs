using Challenge.MELI.Domain.Dtos;
using Challenge.MELI.Domain.Interface.Repository.Command;
using Challenge.MELI.Helpers;
using Microsoft.Extensions.Caching.Distributed;
using System;
using System.Threading.Tasks;

namespace Challenge.MELI.Persistence.Cache.Comand
{
    public class StatsRepository : IStatsRepository
    {
        private readonly IDistributedCache _distributedCache;
        private readonly string KEY = "stats";
        public StatsRepository(IDistributedCache distributedCache)
        {
            _distributedCache = distributedCache;
        }

        public async Task AddStatsAsync(StatsDto statsDto)
        {
            DistributedCacheEntryOptions options = SetTimeCache();

            await _distributedCache.SetAsync(KEY, Common.ToByteCache(statsDto), options);
        }

       
        public async Task UpdateStatsAsync(StatsDto statsDto)
        {
            DistributedCacheEntryOptions options = SetTimeCache();

            await _distributedCache.SetAsync(KEY, Common.ToByteCache(statsDto), options);
        }

        private static DistributedCacheEntryOptions SetTimeCache()
        {
            return new DistributedCacheEntryOptions()
                                           .SetSlidingExpiration(TimeSpan.FromSeconds(86400000));
        }
    }
}
