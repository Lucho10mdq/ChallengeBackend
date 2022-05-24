using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace ChallengeMELI.UseCase.Fraud.V1
{
    [ApiController]
    [Route("fraudes")]
    public partial class FraudController : ControllerBase
    {
        private readonly IMediator _mediator;

        public FraudController(IMediator mediator)
        {
            _mediator = mediator;
        }
    }
}
