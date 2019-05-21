using System;  
using System.Collections.Generic;  
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.ModelBinding;
using System.Web.Http.Results;

namespace OptLib.Web
{
    public class BaseApiController : ApiController
    {
        public class HttpActionResult : IHttpActionResult
        {
            private readonly string _message;
            private readonly HttpStatusCode _statusCode;

            public HttpActionResult(HttpStatusCode statusCode, string message)
            {
                _statusCode = statusCode;
                _message = message;
            }

            public Task<HttpResponseMessage> ExecuteAsync(CancellationToken cancellationToken)
            {
                HttpResponseMessage response = new HttpResponseMessage(_statusCode)
                {
                    Content = new StringContent(_message)
                };
                return Task.FromResult(response);
            }
        }
        public class NotFoundPlainTextActionResult : IHttpActionResult
        {
            public NotFoundPlainTextActionResult(HttpRequestMessage request, string message)
            {
                Request = request;
                Message = message;
            }

            public string Message { get; private set; }
            public HttpRequestMessage Request { get; private set; }

            public Task<HttpResponseMessage> ExecuteAsync(CancellationToken cancellationToken)
            {
                return Task.FromResult(ExecuteResult());
            }

            public HttpResponseMessage ExecuteResult()
            {
                var response = new HttpResponseMessage();

                if (!string.IsNullOrWhiteSpace(Message))
                    //response.Content = new StringContent(Message);
                    response = Request.CreateErrorResponse(HttpStatusCode.NotFound, new Exception(Message));

                response.RequestMessage = Request;
                return response;
            }
        }
        public sealed class EmptyResult : IHttpActionResult
        {
            public Task<HttpResponseMessage> ExecuteAsync(CancellationToken cancellationToken)
            {
                return Task.FromResult(new HttpResponseMessage(System.Net.HttpStatusCode.NoContent) { Content = new StringContent("Empty result") });
            }
        }
        public virtual InvalidModelStateResultNegareh BadRequestNegareh(ModelStateDictionary modelState)
        {
            return new InvalidModelStateResultNegareh(modelState, this);
        }
        public virtual InvalidModelStateResultNegareh BadRequestNegareh(ModelStateDictionary modelState, params string[] modelNames)
        {
            return new InvalidModelStateResultNegareh(modelState, this, modelNames);
        }
    }
}