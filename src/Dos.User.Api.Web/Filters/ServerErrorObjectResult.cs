using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace Dos.User.Api.Web.Filters
{
    public class ServerErrorObjectResult
        : ObjectResult
    {
        public ServerErrorObjectResult(object error, HttpStatusCode code)
            : base(error) => StatusCode = (int)code;
    }
}
