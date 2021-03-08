using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace Dos.User.Api.Web.Filters
{
    public class HttpGlobalExceptionFilter : IExceptionFilter
    {
        private readonly ILogger<HttpGlobalExceptionFilter> _logger;
        private readonly IHostEnvironment _environment;

        public HttpGlobalExceptionFilter(IHostEnvironment environment, ILogger<HttpGlobalExceptionFilter> logger)
        {
            _environment = environment;
            _logger = logger;
        }

        public void OnException(ExceptionContext context)
        {
            var exception = context.Exception;
            IActionResult result;

            switch (exception)
            {
                case KeyNotFoundException _:
                    _logger.LogWarning("Requested resource {Resource} not found", exception.Message);
                    result = new NotFoundResult();
                    break;

                case UnauthorizedAccessException _:
                    _logger.LogWarning("The request did not include a valid authentication token");
                    result = new UnauthorizedResult();
                    break;

                case OperationCanceledException _:
                    {
                        _logger.LogError("The request did not complete in the permitted time");

                        // Gateway timeout
                        var json = ResolveErrorMessage(context);
                        result = new ServerErrorObjectResult(json, HttpStatusCode.GatewayTimeout);
                        break;
                    }
                default:
                    {
                        _logger.LogError(context.Exception, "An unexpected exception has occurred!");

                        // Unhandled/unexpected
                        var json = ResolveErrorMessage(context);
                        result = new ServerErrorObjectResult(json, HttpStatusCode.InternalServerError);
                        break;
                    }
            }

            context.Result = result;
            context.ExceptionHandled = true;
        }

        private object ResolveErrorMessage(ExceptionContext context)
        {
            var exception = context.Exception.GetBaseException();

            if (_environment.IsDevelopment())
            {
                return new { Messages = new[] { "An unexpected error has occurred" }, DeveloperMessage = exception };
            }

            return new { Messages = new[] { "An unexpected error has occurred" } };
        }
    }
}
