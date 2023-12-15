using FluentAssertions;
using HantecBonusManager.Models;

namespace HantecBonusManager.UnitTests
{
    public class TestBonusManager
    {
        [Fact]
        public void Call_OnSuccess_ReturnListOfProcessResults()
        {
            // Arrange
            var sut = new BonusManager();
            // Act
            var result = sut.ProcessBonusForAccounts();
            // Assert
            result.Should().NotBeNull();
            result.Should().BeOfType<Task<List<ProcessResults>>>();
        }
    }
}