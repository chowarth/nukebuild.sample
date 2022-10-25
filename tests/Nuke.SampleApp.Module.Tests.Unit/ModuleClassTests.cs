using FluentAssertions;
using Nuke.SampleApp.Module;
using Nuke.SampleApp.Tests.Shared.TestFixtures;
using Xunit;

namespace Nuke.SampleApp.Module.Tests.Unit
{
    public class ModuleClassTests : BaseTestFixture
    {
        protected override void RegisterTypes()
        {
            // No dependencies
        }

        [Fact]
        public void Add_TwoNumbers_ReturnsCorrectResult()
        {
            // Arrange:
            var sut = Resolve<ModuleClass>();

            // Act:
            var result = sut.Add(1, 5);

            // Assert:
            result.Should().Be(6);
        }
    }
}
