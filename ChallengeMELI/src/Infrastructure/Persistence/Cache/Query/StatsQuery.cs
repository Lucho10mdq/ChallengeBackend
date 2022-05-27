using Challenge.MELI.Domain.Dtos;
using Challenge.MELI.Domain.Interface.Repository.Query;
using Challenge.MELI.Helpers;
using Microsoft.Extensions.Caching.Distributed;
using System.Threading.Tasks;

namespace Challenge.MELI.Persistence.Cache.Query
{
    public class StatsQuery : IStatsQuery
    {
        private readonly IDistributedCache _distributedCache;
        private readonly string KEY = "stats";
        public StatsQuery(IDistributedCache distributedCache) 
        {
            _distributedCache = distributedCache;
        }
        public async Task<StatsDto> GetStatsAsync()
        {
            StatsDto statsDto  = null;

           var cache = await _distributedCache.GetAsync(KEY);

            if (cache != null) 
            {
                statsDto = Common.FromByteCache<StatsDto>(cache);
            }
            return statsDto;
        }
    }
}
