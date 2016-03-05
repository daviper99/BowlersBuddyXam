using System.Collections.ObjectModel;
using BowlersBuddyXam.Controls;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Messaging;
using Xamarin.Forms;


namespace BowlersBuddyXam.ViewModel
{
    public class GameViewModel : ViewModelBase
    {
        public INavigation Navigation { get; set; }

        /// <summary>
            /// The <see cref="GameId" /> property's name.
            /// </summary>
        public const string GameIdPropertyName = "GameId";

        private int _gameId = 0;

        /// <summary>
        /// Sets and gets the GameId property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// This property's value is broadcasted by the MessengerInstance when it changes.
        /// </summary>
        public int GameId
        {
            get
            {
                return _gameId;
            }

            set
            {
                if (_gameId == value)
                {
                    return;
                }

                var oldValue = _gameId;
                _gameId = value;
                RaisePropertyChanged(GameIdPropertyName, oldValue, value, true);
            }
        }
    }
}