using System;
using FluentAssertions;
using Nuke.SampleApp.Converters;
using Nuke.SampleApp.Tests.Shared.TestFixtures;
using Xamarin.Essentials.Interfaces;
using Xunit;

namespace Nuke.SampleApp.Tests.Unit.Converters
{
    public class SampleConverterTests : BaseTestFixture
    {
        const string DeviceName = "Unit-Test-Device";

        protected override void RegisterTypes()
        {
            RegisterMock<IDeviceInfo>();
        }

        [Fact]
        public void Convert_ReturnsDeviceName()
        {
            // Arrange:
            ResolveMock<IDeviceInfo>(mock =>
            {
                mock.SetupGet(x => x.Name)
                    .Returns(DeviceName);
            });

            var converter = Resolve<SampleConverter>();

            // Act:
            string result = (string)converter.Convert(new(), null, null, null);

            // Assert:
            result.Should().Be(DeviceName);
        }

        [Fact]
        public void ConvertBack_ThrowsNotImplementedException()
        {
            // Arrange:
            var converter = Resolve<SampleConverter>();

            // Act:
            Action jackson = () => converter.ConvertBack(null, null, null, null);

            // Assert:
            Assert.Throws<NotImplementedException>(jackson);
        }
    }
}
