using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Dos.User.Api.Web.Filters
{
    public class InternalServerErrorObjectResult : ObjectResult
    {
        public InternalServerErrorObjectResult(object error)
            : base(error)
        {
            StatusCode = StatusCodes.Status500InternalServerError;
        }
    }
}
