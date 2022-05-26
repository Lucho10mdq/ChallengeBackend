using Challenge.MELI.Domain.Interface.Service;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace ChallengeMELI.UseCase.Stast.V1
{
    [ApiController]
    [Route("stats")]
    public partial class StatsController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IStatsService _statsService;

        public StatsController(IMediator mediator, IStatsService statsService)
        {
            _mediator = mediator;
            _statsService = statsService;
        }
    }
}
