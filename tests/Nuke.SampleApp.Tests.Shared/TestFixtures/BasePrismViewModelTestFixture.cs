using Nuke.SampleApp.ViewModels;
using Prism.AppModel;
using Prism.Navigation;

namespace Nuke.SampleApp.Tests.Shared.TestFixtures
{
    public abstract class BasePrismViewModelTestFixture : BaseTestFixture
    {
        #region IInitialize

        /// <summary>
        /// Resolves a viewmodel and calls <see cref="IInitialize.Initialize"/>.
        /// </summary>
        /// <typeparam name="TViewModel">The viewmodel type to resolve</typeparam>
        /// <param name="parameters">The navigation parameters to pass through to <see cref="IInitialize.Initialize"/></param>
        /// <returns>The resolved instance of the viewmodel</returns>
        protected TViewModel ResolveAndCallInitialize<TViewModel>(INavigationParameters? parameters = default)
            where TViewModel : BasePrismViewModel, IInitialize
        {
            SetPrismInternalNavigationParameters(ref parameters, NavigationMode.New);

            TViewModel vm = Resolve<TViewModel>();
            vm.Initialize(parameters);

            return vm;
        }

        #endregion IInitialize

        #region INavigatedAware

        /// <summary>
        /// Resolves a viewmodel and calls <see cref="INavigatedAware.OnNavigatedTo"/>.
        /// </summary>
        /// <typeparam name="TViewModel">The viewmodel type to resolve</typeparam>
        /// <param name="parameters">The navigation parameters to pass through to <see cref="INavigatedAware.OnNavigatedTo"/></param>
        /// <returns>The resolved instance of the viewmodel</returns>
        protected TViewModel ResolveAndCallOnNavigatedTo<TViewModel>(INavigationParameters? parameters = default)
            where TViewModel : BasePrismViewModel, INavigationAware
        {
            SetPrismInternalNavigationParameters(ref parameters, NavigationMode.New);

            TViewModel vm = Resolve<TViewModel>();
            vm.OnNavigatedTo(parameters);

            return vm;
        }

        /// <summary>
        /// Resolves a viewmodel and calls <see cref="INavigatedAware.OnNavigatedFrom"/>.
        /// </summary>
        /// <typeparam name="TViewModel">The viewmodel type to resolve</typeparam>
        /// <param name="parameters">The navigation parameters to pass through to <see cref="INavigatedAware.OnNavigatedFrom"/></param>
        /// <returns>The resolved instance of the viewmodel</returns>
        protected TViewModel ResolveAndCallOnNavigatedFrom<TViewModel>(INavigationParameters? parameters = default)
            where TViewModel : BasePrismViewModel, INavigationAware
        {
            SetPrismInternalNavigationParameters(ref parameters, NavigationMode.New);

            TViewModel vm = Resolve<TViewModel>();
            vm.OnNavigatedFrom(parameters);

            return vm;
        }

        /// <summary>
        /// Resolves the viewmodel and calls <see cref="BasePrismViewModel.OnReturnedTo"/>.
        /// </summary>
        /// <typeparam name="T">The ViewModel type to resolve</typeparam>
        /// <param name="parameters">The navigation parameters to pass through to OnReturnedTo</param>
        /// <returns>The resolved instance of the desired ViewModel</returns>
        protected TViewModel ResolveAndCallOnReturnedTo<TViewModel>(INavigationParameters? parameters = default)
            where TViewModel : BasePrismViewModel, INavigationAware
        {
            SetPrismInternalNavigationParameters(ref parameters, NavigationMode.Back);

            TViewModel vm = Resolve<TViewModel>();
            vm.OnNavigatedTo(parameters);

            return vm;
        }

        #endregion INavigatedAware

        #region IPageLifeCycleAware

        /// <summary>
        /// Resolves a viewmodel and calls <see cref="IPageLifecycleAware.OnAppearing"/>.
        /// </summary>
        /// <typeparam name="TViewModel">The viewmodel type to resolve</typeparam>
        /// <returns>The resolved instance of the viewmodel</returns>
        protected TViewModel ResolveAndCallOnAppearing<TViewModel>()
             where TViewModel : BasePrismViewModel, IPageLifecycleAware
        {
            TViewModel vm = Resolve<TViewModel>();
            vm.OnAppearing();

            return vm;
        }

        /// <summary>
        /// Resolves a viewmodel and calls <see cref="IPageLifecycleAware.OnDisappearing"/>.
        /// </summary>
        /// <typeparam name="TViewModel">The viewmodel type to resolve</typeparam>
        /// <returns>The resolved instance of the viewmodel</returns>
        protected TViewModel ResolveAndCallOnDisappearing<TViewModel>()
            where TViewModel : BasePrismViewModel, IPageLifecycleAware
        {
            TViewModel vm = Resolve<TViewModel>();
            vm.OnDisappearing();

            return vm;
        }

        #endregion IPageLifeCycleAware

        #region IApplicationLifecycleAware

        /// <summary>
        /// Resolves a viewmodel and calls <see cref="IApplicationLifecycleAware.OnSleep"/>.
        /// </summary>
        /// <typeparam name="TViewModel">The viewmodel type to resolve</typeparam>
        /// <returns>The resolved instance of the viewmodel</returns>
        protected TViewModel ResolveAndCallOnSleep<TViewModel>()
            where TViewModel : BasePrismViewModel, IApplicationLifecycleAware
        {
            TViewModel vm = Resolve<TViewModel>();
            vm.OnSleep();

            return vm;
        }

        /// <summary>
        /// Resolves a viewmodel and calls <see cref="IApplicationLifecycleAware.OnResume"/>.
        /// </summary>
        /// <typeparam name="TViewModel">The viewmodel type to resolve</typeparam>
        /// <returns>The resolved instance of the viewmodel</returns>
        protected TViewModel ResolveAndCallOnResume<TViewModel>()
            where TViewModel : BasePrismViewModel, IApplicationLifecycleAware
        {
            TViewModel vm = Resolve<TViewModel>();
            vm.OnResume();

            return vm;
        }

        #endregion IApplicationLifecycleAware

        #region IDestructible

        /// <summary>
        /// Resolves a viewmodel and calls <see cref="IDestructible.Destroy"/>.
        /// </summary>
        /// <typeparam name="TViewModel">The viewmodel type to resolve</typeparam>
        /// <returns>The resolved instance of the viewmodel</returns>
        protected TViewModel ResolveAndCallDestroy<TViewModel>()
            where TViewModel : BasePrismViewModel, IDestructible
        {
            TViewModel vm = Resolve<TViewModel>();
            vm.Destroy();

            return vm;
        }

        #endregion IDestructible

        /// <summary>
        /// Sets the Prism internal navigation parameter <see cref="NavigationMode"/>.
        /// </summary>
        /// <param name="parameters">Navigation parameters to have NavigationMode set on</param>
        /// <param name="navMode">NavigationMode to add to parameters</param>
        private static void SetPrismInternalNavigationParameters(ref INavigationParameters? parameters, NavigationMode navMode)
        {
            if (parameters is null)
                parameters = new NavigationParameters();

            INavigationParametersInternal? internalParams = parameters as INavigationParametersInternal;
            internalParams?.Add("__NavigationMode", navMode);
        }
    }
}
