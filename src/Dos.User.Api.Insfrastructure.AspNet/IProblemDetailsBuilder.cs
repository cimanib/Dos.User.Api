using Microsoft.AspNetCore.Mvc;

namespace Dos.User.Api.Insfrastructure.AspNet
{
    public interface IProblemDetailsBuilder
    {
        ProblemDetails Build();
    }
}
