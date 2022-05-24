using System;
using System.Collections.Generic;
using System.Net;

namespace Challenge.MELI.Helpers
{
    public class Response<T>
    {
        public bool Succeeded { get; set; }
        public string Message { get; set; }
        public HttpStatusCode Status { get; set; }
        public Guid Tracer { get; set; }
        public List<ProblemDetail> Error { get; set; }
        public T Data { get; set; }

        public Response()
        {
            Tracer = Guid.NewGuid();
        }
        public Response(T data, string message = null)
        {
            Succeeded = true;
            Status = HttpStatusCode.OK;
            Message = MessageGeneral.Successful;
            Data = data;
            Tracer = Guid.NewGuid();
        }

        public Response(string message)
        {
            Succeeded = false;
            Message = message;
            Tracer = Guid.NewGuid();
        }
    }
}
