using System.ComponentModel;
using System.Threading.Tasks;
using BowlersBuddyXam.Resource;
using BowlersBuddyXam.Views;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using Xamarin.Forms;

namespace BowlersBuddyXam.ViewModel
{
    /// <summary>
    ///     This class contains properties that the main View can data bind to.
    ///     <para>
    ///         Use the <strong>mvvminpc</strong> snippet to add bindable properties to this ViewModel.
    ///     </para>
    ///     <para>
    ///         You can also use Blend to data bind with the tool's support.
    ///     </para>
    ///     <para>
    ///         See http://www.galasoft.ch/mvvm
    ///     </para>
    /// </summary>
    public class MainViewModel : BaseViewModel
    {
        public INavigation Navigation { get; set; }

        private RelayCommand _newEquipmentCommand;
        private RelayCommand _newGameCommand;
        private RelayCommand _newLocationsCommand;
        private RelayCommand _newSeriesCommand;
        private RelayCommand _newSettingsCommand;

        public RelayCommand NewSeriesCommand => _newSeriesCommand
                                                ?? (_newSeriesCommand = OpenSeries());

        public RelayCommand NewGameCommand => _newGameCommand
                                              ?? (_newGameCommand = OpenGame());

        public RelayCommand SettingsCommand => _newSettingsCommand
                                               ?? (_newSettingsCommand = OpenSettings());

        public RelayCommand LocationsCommand => _newLocationsCommand
                                                ?? (_newLocationsCommand = OpenLocations());

        public RelayCommand EquipmentCommand => _newEquipmentCommand
                                                ?? (_newEquipmentCommand = OpenEquipment());


        public RelayCommand OpenSeries() => new RelayCommand(() => { });

        public RelayCommand OpenGame() => new RelayCommand(async() => await Navigation.PushAsync(new GameView()));

        public RelayCommand OpenSettings() => new RelayCommand(() => { });

        public RelayCommand OpenLocations() => new RelayCommand(() => { });

        public RelayCommand OpenEquipment() => new RelayCommand(() => { });

        #region Localized Strings

        public string NewSeriesLocalized => LocalizedResources.NewSeries;
        public string NewGameLocalized => LocalizedResources.NewGame;
        public string SettingsLocalized => LocalizedResources.Settings;
        public string LocationsLocalized => LocalizedResources.Locations;
        public string EquipmentLocalized => LocalizedResources.Equipment;

        #endregion

    }
}