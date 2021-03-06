using Dos.User.Api.Data.Queries;
using Dos.User.Api.Domain.AggregateModels;
using Dos.User.Api.Handlers;
using Dos.User.Api.Messages.Queries;
using Moq;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;

namespace Dos.User.Api.Application.Tests.Handlers
{
    public class GetUsersQueryHandlerTests
    {
        private readonly Mock<IUserRespository> _userRespository = new Mock<IUserRespository>();
        private readonly GetUsersQueryHandler _getUsersQueryHandler;

        public GetUsersQueryHandlerTests()
        {
            _getUsersQueryHandler = new GetUsersQueryHandler(_userRespository.Object);
        }

        [Fact]
        public async Task GetUsers_should_return_Users()
        {
            //Arrange

            _userRespository.Setup(x => x.FilterUsers(It.IsAny<string>(), It.IsAny<string>(), default))
                .ReturnsAsync(new List<UserEntity>
                {
                    new UserEntity
                    {
                    }
                })
                .Verifiable();

            var query = new GetUsersQuery("Bulelani", "Cimani");

            //Act
            var result = await _getUsersQueryHandler.Handle(query, default);
            _userRespository.Verify();

            //Assert
            Assert.NotNull(result);
        }
    }
}