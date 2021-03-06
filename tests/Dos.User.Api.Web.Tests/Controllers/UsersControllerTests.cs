using Dos.User.Api.Messages.Models;
using Dos.User.Api.Messages.Queries;
using Dos.User.Api.Web.Controllers;
using MediatR;
using Moq;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;

namespace Dos.User.Api.Web.Tests.Controllers
{

    public class UsersControllerTests
    {
        private readonly Mock<IMediator> _mediator = new Mock<IMediator>();
        private readonly UsersController _usersController;

        public UsersControllerTests()
        {
            _usersController = new UsersController(_mediator.Object);
        }

        [Fact]
        public async Task GetUsers_should_return_ListOfUsers()
        {
            //Arrange

            var users = new UserResponse
            {
                Users = new List<UserDto>
                {
                    new UserDto
                    {
                        FirstName = "Bulelani",
                        LastName = "Cimani",
                        City = "Cape Town",
                        Address = "test address",
                        Country = "South Africa",
                        DateOfBirth = "80/01/01",
                        EmailAddress = "test@gmail.com",
                        ZipCode = "12323"
                    }

                }

            };
            _mediator.Setup(x => x.Send(It.IsAny<GetUsersQuery>(), default))
               .ReturnsAsync(users)
               .Verifiable();

            //Act
            var result = await _usersController.Dispatcher.Send(new GetUsersQuery("Bulelani", "Cimani"));
            _mediator.Verify();
            //Assert
            Assert.NotNull(result);
            Assert.Equal(result.Users[0].FirstName, users.Users[0].FirstName);
            Assert.Equal(result.Users[0].LastName, users.Users[0].LastName);
            Assert.Equal(result.Users[0].Address, users.Users[0].Address);
            Assert.Equal(result.Users[0].EmailAddress, users.Users[0].EmailAddress);
            Assert.Equal(result.Users[0].City, users.Users[0].City);
            Assert.Equal(result.Users[0].Country, users.Users[0].Country);
            Assert.Equal(result.Users[0].ZipCode, users.Users[0].ZipCode);
        }
    }
}
