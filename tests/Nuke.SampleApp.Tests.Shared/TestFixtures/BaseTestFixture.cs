using System;
using DryIoc;
using Moq;

namespace Nuke.SampleApp.Tests.Shared.TestFixtures
{
    public abstract class BaseTestFixture : IDisposable
    {
        private Container? _container;
        private IResolverContext? _scopeContext;

        protected BaseTestFixture()
        {
            _container = new Container(rules => rules.WithConcreteTypeDynamicRegistrations()
                                                     .WithTrackingDisposableTransients()
                                                     .WithDefaultReuse(new CurrentScopeReuse()));

            _scopeContext = _container.OpenScope();

            RegisterTypes();
        }

        /// <summary>
        /// Register dependency types for the test fixture
        /// </summary>
        protected abstract void RegisterTypes();

        protected void Register<T>()
            where T : class
        {
            _container.Register<T>();
        }

        protected void Register<TInterface, TImplementation>()
            where TInterface : class
            where TImplementation : TInterface, new()
        {
            _container.Register<TInterface, TImplementation>();
        }

        protected T Resolve<T>()
            where T : class
        {
            return _scopeContext.Resolve<T>();
        }

        /// <summary>
        /// Regsiter a <see cref="Mock"/> type with the container
        /// </summary>
        /// <typeparam name="T">The type of the <see cref="Mock"/> object to be registered</typeparam>
        /// <param name="setupCallback">Optional setup callback</param>
        protected void RegisterMock<T>(Action<Mock<T>>? setupCallback = default)
            where T : class
        {
            Mock<T> mock = new Mock<T>();

            _container.Register<T>(Made.Of<T>(() => CreateAndInitialiseMockInstance(setupCallback, mock)));
        }

        private static T CreateAndInitialiseMockInstance<T>(Action<Mock<T>>? setupCallback, Mock<T> mock) where T : class
        {
            Action<Mock<T>>? callback = setupCallback;
            callback?.Invoke(mock);

            return mock.Object;
        }

        /// <summary>
        /// Resovles the <see cref="Mock"/> object for the given type <typeparamref name="T"/>
        /// </summary>
        /// <typeparam name="T">The type of the <see cref="Mock"/> object to be resolved</typeparam>
        /// <returns>The <see cref="Mock"/> object of type <typeparamref name="T"/></returns>
        protected Mock<T> ResolveMock<T>()
            where T : class
        {
            return Mock.Get<T>(Resolve<T>());
        }

        /// <summary>
        /// Resovles the <see cref="Mock"/> object for the given type <typeparamref name="T"/>
        /// </summary>
        /// <typeparam name="T">The type of the <see cref="Mock"/> object to be resolved</typeparam>
        /// <param name="setupCallback"><see cref="Mock"/> setup callback</param>
        /// <returns>The <see cref="Mock"/> object of type <typeparamref name="T"/></returns>
        protected Mock<T> ResolveMock<T>(Action<Mock<T>> setupCallback)
            where T : class
        {
            Mock<T> mock = ResolveMock<T>();

            Action<Mock<T>> callback = setupCallback;
            callback?.Invoke(mock);

            return mock;
        }

        #region IDisposable Support

        // To detect redundant calls
        private bool _disposedValue = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!_disposedValue)
            {
                if (disposing)
                {
                    _scopeContext?.Dispose();
                    _scopeContext = null;

                    _container?.Dispose();
                    _container = null;
                }

                // Free unmanaged resources

                _disposedValue = true;
            }
        }

        public void Dispose()
        {
            Dispose(disposing: true);
            GC.SuppressFinalize(this);
        }

        #endregion
    }
}
