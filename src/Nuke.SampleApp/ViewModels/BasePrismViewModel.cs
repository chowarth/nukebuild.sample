using System.Diagnostics;
using Prism.AppModel;
using Prism.Mvvm;
using Prism.Navigation;

namespace Nuke.SampleApp.ViewModels
{
    public class BasePrismViewModel : BindableBase, IApplicationLifecycleAware, IInitialize, INavigationAware, IPageLifecycleAware, IDestructible
    {
        public BasePrismViewModel()
        {
        }

        /// <summary>
        /// Called when the application is brought to the foreground.
        /// </summary>
        protected virtual void OnResume()
        {
        }

        /// <summary>
        /// Called when the application is sent to the background.
        /// </summary>
        protected virtual void OnSleep()
        {
        }

        /// <summary>
        /// Called after the view model has been created during navigation.
        /// </summary>
        /// <param name="parameters">The parameters being passed to the view model.</param>
        protected virtual void Initialize(INavigationParameters parameters)
        {
        }

        /// <summary>
        /// Called when the view model has been navigated to.
        /// </summary>
        /// <param name="parameters">The parameters being passed to the view model.</param>
        protected virtual void OnNavigatedTo(INavigationParameters parameters)
        {
        }

        /// <summary>
        /// Called when the view model has been navigated away from.
        /// </summary>
        /// <param name="parameters">The parameters being passed to the view model.</param>
        protected virtual void OnNavigatedFrom(INavigationParameters parameters)
        {
        }

        /// <summary>
        /// Called when a view model is being returned to from another view model.
        /// </summary>
        /// <param name="parameters">The parameters being passed to the view model.</param>
        protected virtual void OnReturnedTo(INavigationParameters parameters)
        {
        }

        /// <summary>
        /// Called when the page associated with the view model is appearing.
        /// </summary>
        protected virtual void OnAppearing()
        {
        }

        /// <summary>
        /// Called when the page associated with the view model is disappearing.
        /// </summary>
        protected virtual void OnDisappearing()
        {
        }

        /// <summary>
        /// Called when the view model is being destroyed. Unhook events, release unmanaged memory etc. here.
        /// </summary>
        protected virtual void OnDestroy()
        {
        }

        #region IApplicationLifecycleAware

        void IApplicationLifecycleAware.OnResume()
        {
            Debug.WriteLine($"{GetType().Name}: OnResume");
            OnResume();
        }

        void IApplicationLifecycleAware.OnSleep()
        {
            Debug.WriteLine($"{GetType().Name}: OnSleep");
            OnSleep();
        }

        #endregion // IApplicationLifecycleAware

        #region IInitialize

        void IInitialize.Initialize(INavigationParameters parameters)
        {
            Debug.WriteLine($"{GetType().Name}: Initialize");
            Initialize(parameters);
        }

        #endregion // Initialize

        #region INavigationAware

        void INavigatedAware.OnNavigatedTo(INavigationParameters parameters)
        {
            NavigationMode navMode = parameters.GetNavigationMode();

            if (navMode == NavigationMode.New)
            {
                Debug.WriteLine($"{GetType().Name}: OnNavigatedTo");
                OnNavigatedTo(parameters);
            }
            else
            {
                Debug.WriteLine($"{GetType().Name}: OnReturnedTo");
                OnReturnedTo(parameters);
            }
        }

        void INavigatedAware.OnNavigatedFrom(INavigationParameters parameters)
        {
            Debug.WriteLine($"{GetType().Name}: OnNavigatedFrom");
            OnNavigatedFrom(parameters);
        }

        #endregion // INavigationAware

        #region IPageLifeCycleAware

        void IPageLifecycleAware.OnAppearing()
        {
            Debug.WriteLine($"{GetType().Name}: OnAppearing");
            OnAppearing();
        }

        void IPageLifecycleAware.OnDisappearing()
        {
            Debug.WriteLine($"{GetType().Name}: OnDisappearing");
            OnDisappearing();
        }

        #endregion // IPageLifeCycleAware

        #region IDestructible

        void IDestructible.Destroy()
        {
            Debug.WriteLine($"{GetType().Name}: Destroy");
            OnDestroy();
        }

        #endregion // IDestructible
    }
}
