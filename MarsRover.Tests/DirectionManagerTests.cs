using MarsRover.Core.Exceptions;
using MarsRover.Core.Services;
using Xunit;
using static MarsRover.Core.Constants.Constants;

namespace MarsRover.Tests
{
    public class DirectionManagerTests
    {
        [Fact]
        public void When_DirectionLengthIsNotValid_Expect_DirectionException()
        {
            var expectedErrorMessage = "Direction length must be 1 character.";

            var directionManager = new DirectionManager();

            var exception = Assert.Throws<DirectionException>(() => directionManager.SetDirection("N S"));

            Assert.Equal(expectedErrorMessage, exception.Message);
        }

        [Fact]
        public void When_DirectionIsNotValid_Expect_DirectionException()
        {
            var expectedErrorMessage = "Undefined direction. Current direction : X";

            var directionManager = new DirectionManager();
            directionManager.SetDirection("X");

            var exception = Assert.Throws<DirectionException>(() => directionManager.GetDirection());

            Assert.Equal(expectedErrorMessage, exception.Message);
        }

        [Fact]
        public void When_AddSuccessDirection_Expect_Success()
        {
            var expectedResult = Direction.N;

            var directionManager = new DirectionManager();
            directionManager.SetDirection("N");

            Assert.Equal(expectedResult, directionManager.GetDirection());
        }
    }
}
