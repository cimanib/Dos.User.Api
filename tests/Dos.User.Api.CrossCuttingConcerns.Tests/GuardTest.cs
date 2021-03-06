using Dos.User.Api.Common;
using System;
using Xunit;

namespace Dos.User.Api.CrossCuttingConcerns.Tests
{
    public class GuardTest
    {
        [Fact]
        public void Guard_Against_Null_should_return_Instance()
        {
            //Arrange

            object @object = new
            {
                Test = "test message"
            };

            //Act
            var result = Guard.IsNotNull(@object, nameof(@object));

            //Assert
            Assert.NotNull(result);
        }

        [Fact]
        public void Guard_Against_Null_Throw_ArgumentNullException()
        {
            //Arrange
            object value = null;

            //Assert
            Assert.Throws<ArgumentNullException>(() => Guard.IsNotNull(value, "Test message"));
        }
    }
}