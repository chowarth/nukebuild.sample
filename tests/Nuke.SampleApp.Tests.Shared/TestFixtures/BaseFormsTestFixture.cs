using Xamarin.Forms.Mocks;

namespace Nuke.SampleApp.Tests.Shared.TestFixtures
{
    /// <summary>
    /// Base test fixture for any Xamarin.Forms based tests
    /// </summary>
    public abstract class BaseFormsTestFixture : BaseTestFixture
    {
        public BaseFormsTestFixture()
        {
            MockForms.Init();
        }
    }
}
