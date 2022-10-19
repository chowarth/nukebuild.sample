using FluentAssertions;
using Nuke.SampleApp.Tests.Shared.TestFixtures;
using Nuke.SampleApp.Views;
using Xunit;

namespace Nuke.SampleApp.Tests.Unit.Views
{
    public class MainPageTests : BaseFormsTestFixture
    {
        protected override void RegisterTypes()
        {
            // No dependencies
        }

        [Fact]
        public void MainPage_WhenCreated_TitleEqualsMainPage()
        {
            // Arrange
            // Act
            var page = Resolve<MainPage>();

            // Assert
            page.Title.Should().NotBeNullOrWhiteSpace();
            page.Title.Should().Be("Main Page");
        }
    }
}
