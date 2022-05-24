using Challenge.MELI.Domain.Interface.Service;
using Challenge.MELI.Helpers;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Challenge.MELI.Application.UseCase.Fraude.Get
{
    public class GetFraudHandler : IRequestHandler<GetIPQuery, Response<GetFraudResponse>>
    {
        private readonly IFraudeService _fraudeService;

        public GetFraudHandler(IFraudeService fraudeService) 
        {
            _fraudeService = fraudeService;
        }
        public async Task<Response<GetFraudResponse>> Handle(GetIPQuery request, CancellationToken cancellationToken)
        {
            var informationFraudeDto = await _fraudeService.GetInformationFraudeAsync(request.Ip);

            return new Response<GetFraudResponse>(new GetFraudResponse(informationFraudeDto));
        }
    }
}
