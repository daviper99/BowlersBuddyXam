using GalaSoft.MvvmLight.Ioc;
using Microsoft.Practices.ServiceLocation;

namespace BowlersBuddyXam.ViewModel
{
    /// <summary>
    ///     This class contains static references to all the view models in the
    ///     application and provides an entry point for the bindings.
    /// </summary>
    public class ViewModelLocator
    {
        /// <summary>
        ///     Initializes a new instance of the ViewModelLocator class.
        /// </summary>
        public ViewModelLocator()
        {
            ServiceLocator.SetLocatorProvider(() => SimpleIoc.Default);

            // Provide a registration for each ViewModel
            SimpleIoc.Default.Register<MainViewModel>();
            SimpleIoc.Default.Register<GameViewModel>();
        }

        // Public accessor for each ViewModel
        public MainViewModel MainBaseVm => ServiceLocator.Current.GetInstance<MainViewModel>();
        public GameViewModel GameBaseVm => ServiceLocator.Current.GetInstance<GameViewModel>();

        public static void Cleanup()
        {
            // TODO Clear the ViewModels
        }
    }
}