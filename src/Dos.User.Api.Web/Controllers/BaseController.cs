using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Dos.User.Api.Web.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public abstract class BaseController : ControllerBase
    {
        private protected IMediator _mediator;
        public IMediator Dispatcher => this._mediator;

        public BaseController(IMediator mediator)
        {
            _mediator = mediator;
        }
    }
}