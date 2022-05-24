using Challenge.MELI.Application.Exceptions;
using Challenge.MELI.Helpers;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text.Json;
using System.Threading.Tasks;

namespace ChallengeMELI.Middleware
{
    public class ErrorHandlerMiddleware
    {
        private readonly RequestDelegate _next;

        public ErrorHandlerMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {
                var response = context.Response;
                response.ContentType = "application/json";

                var responseModel = new Response<string>() { Succeeded = false, Message = ex?.Message, Error = new List<ProblemDetail>() };

                switch (ex)
                {
                    case GenericException e:
                        response.StatusCode = (int)HttpStatusCode.NotFound;
                        responseModel.Status = HttpStatusCode.NotFound;
                        responseModel.Error.Add(new ProblemDetail(e.ErrorMessage));
                        break;
                }

                var result = JsonSerializer.Serialize(responseModel);

                await response.WriteAsync(result);
            }

        }
    }
}
