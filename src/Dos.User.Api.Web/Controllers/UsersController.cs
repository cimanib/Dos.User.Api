using Dos.User.Api.Messages.Queries;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Dos.User.Api.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : BaseController
    {
        public UsersController(IMediator mediator) : base(mediator)
        {
        }
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [Produces("application/json")]
        public async Task<IActionResult> GetUsers(
            [FromQuery] string name,
            [FromQuery] string surname)
        {
            var response = await Dispatcher.Send(new GetUsersQuery(name, surname));

            return Ok(response);
        }
    }
}