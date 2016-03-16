using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using BowlersBuddyXam.Model;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using Xamarin.Forms;

namespace BowlersBuddyXam.ViewModel
{
    public class GameViewModel : MyViewModelBase
    {
        public const string GameIdPropertyName = "GameId";
        public const string PinBoxSizePropertyName = "PinBoxSize";

        private readonly ObservableCollection<FrameViewModel> _fvmcol = new ObservableCollection<FrameViewModel>();
        private readonly Game _game = new Game();
        private int _gameId;
        //private bool _isSolid = true;
        private int _pinBoxSize = 40;
        //private RelayCommand _pinTapped;

        public GameViewModel()
        {
            _gameId = _game.NewGame();
        }

        public INavigation Navigation { get; set; }

        /// <summary>
        ///     Sets and gets the GameId property.
        ///     Changes to that property's value raise the PropertyChanged event.
        ///     This property's value is broadcasted by the MessengerInstance when it changes.
        /// </summary>
        public int GameId
        {
            get { return _gameId; }

            set
            {
                if (_gameId == value)
                {
                    return;
                }

                var oldValue = _gameId;
                _gameId = value;
                RaisePropertyChanged(GameIdPropertyName, oldValue, value, true);
                OnPropertyChanged("GameId");

            }
        }

        /// <summary>
        ///     Sets and gets the PinBoxSize property.
        ///     Changes to that property's value raise the PropertyChanged event.
        ///     This property's value is broadcasted by the MessengerInstance when it changes.
        /// </summary>
        public int PinBoxSize
        {
            get { return _pinBoxSize; }

            set
            {
                if (_pinBoxSize == value)
                {
                    return;
                }

                var oldValue = _pinBoxSize;
                _pinBoxSize = value;
                RaisePropertyChanged(PinBoxSizePropertyName, oldValue, value, true);
                OnPropertyChanged("PinBoxSize");
            }
        }

        public void AddFrame(FrameViewModel fvm, int frameNbr)
        {
            // add the frame view model passed to the collection
            _fvmcol.Add(fvm);
        }

        public void GetGame(int gameId)
        {
            // get the identified game from the database
            _game.GetGame(gameId);
            GameId = gameId;
        }
    }
}