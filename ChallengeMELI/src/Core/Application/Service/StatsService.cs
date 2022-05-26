using Challenge.MELI.Domain;
using Challenge.MELI.Domain.Dtos;
using Challenge.MELI.Domain.Interface.Repository.Command;
using Challenge.MELI.Domain.Interface.Repository.Query;
using Challenge.MELI.Domain.Interface.Service;
using System.Threading.Tasks;

namespace Challenge.MELI.Application.Service
{
    public class StatsService : IStatsService
    {
        private readonly IStatsRepository _statsRepository;
        private readonly IStatsQuery _statsQuery;
        public StatsService(IStatsRepository statsRepository,
                            IStatsQuery statsQuery) 
        {
            _statsRepository = statsRepository;
            _statsQuery = statsQuery;
        }
        public async Task AddStatsAsync(InformationFraudDto informationFraudDto)
        {
            StatsDto statsDto = null;

            statsDto = await GetStatsAsync();
            
            if(statsDto != null) 
            {
                await UpdateStatsAsync(statsDto, informationFraudDto);
            }
            else
            {
                statsDto = BuildStatsDto(informationFraudDto, statsDto);

                await _statsRepository.AddStatsAsync(statsDto);
            }
        }

        private static StatsDto BuildStatsDto(InformationFraudDto informationFraudDto, StatsDto statsDto)
        {
            statsDto = new StatsDto();
            statsDto.Call = 1;
            statsDto.Distance = informationFraudDto.Distance;
            statsDto.MaxDist = informationFraudDto.Distance;
            statsDto.MinDist = informationFraudDto.Distance;
            statsDto.Average = informationFraudDto.Distance;

            return statsDto;
        }

        public async Task UpdateStatsAsync(StatsDto statsDto, InformationFraudDto informationFraudDto)
        {
            statsDto.Call++;
            statsDto.Distance += informationFraudDto.Distance;
            statsDto.Average = statsDto.CalculateAvarage(statsDto.Call, statsDto.Distance);
            statsDto.UpdateMinMax(informationFraudDto.Distance);

            await _statsRepository.UpdateStatsAsync(statsDto);
        }

        public async Task<StatsDto> GetStatsAsync()
        {
            return await _statsQuery.GetStatsAsync();
        }
    }
}
