using Dos.User.Api.Insfrastructure.AspNet;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;

namespace Dos.User.Api.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [ApiExplorerSettings(IgnoreApi = true)]
    public class ErrorsController : ControllerBase
    {
        private readonly ILogger<ErrorsController> _log;

        public ErrorsController(ILogger<ErrorsController> log)
        {
            this._log = log;
        }

        [Route("error")]
        public IActionResult Error()
        {
            var context = HttpContext.Features.Get<IExceptionHandlerFeature>();

            var exception = context.Error;

            this._log.LogError(exception, exception.Message);

            var handler = this.GetExceptionHandler(context.Error);

            return handler.Invoke(context.Error);
        }
        private Func<Exception, IActionResult> GetExceptionHandler(Exception ex)
        {

            return this.UnregisteredExceptionHandler;
        }
        private IActionResult UnregisteredExceptionHandler(Exception ex)
        {
            var problemDetails = new ProblemDetailsBuilder(this.HttpContext)
                .WithTitle("An error occurred while processing your request.")
                .WithType("https://tools.ietf.org/html/rfc7231#section-6.6.1")
                .WithDetail(ex.Message)
                .Build();

            return new OkObjectResult(problemDetails);
        }
    }
}