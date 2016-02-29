using System.ComponentModel;
using System.IO;
using System.Windows.Input;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using Xamarin.Forms;

namespace BowlersBuddyXam.ViewModel
{
    /// <summary>
    /// This class contains properties that the main View can data bind to.
    /// <para>
    /// Use the <strong>mvvminpc</strong> snippet to add bindable properties to this ViewModel.
    /// </para>
    /// <para>
    /// You can also use Blend to data bind with the tool's support.
    /// </para>
    /// <para>
    /// See http://www.galasoft.ch/mvvm
    /// </para>
    /// </summary>
    public class MainViewModel : ViewModelBase
    {
        private string _analysis;
        private string _homelbl;
        private string _newGame;
        private string _newSeries;
        private string _settings;

        /// <summary>
        /// Initializes a new instance of the MainViewModel class.
        /// </summary>
        public MainViewModel()
        {
            //NewSeriesCommand = new Command(StartNewSeries);
            //NewGameCommand = new Command(StartNewGame);
            //SettingsCommand = new Command(StartSettings);
            //AnalysisCommand = new Command(StartAnalysis);
        }

        public string NewSeries
        {
            get { return _newSeries; }
            set
            {
                _newSeries = value;
                //OnPropertyChanged("NewSeries");
            }
        }

        public string NewGame
        {
            get { return _newGame; }
            set
            {
                _newGame = value;
                //OnPropertyChanged("NewGame");
            }
        }

        public string Settings
        {
            get { return _settings; }
            set
            {
                _settings = value;
                //OnPropertyChanged("Settings");
            }
        }

        public string Analysis
        {
            get { return _analysis; }
            set
            {
                _analysis = value;
                //OnPropertyChanged("Analysis");
            }
        }

        public string HomeLbl
        {
            get { return _homelbl; }
            set
            {
                _homelbl = value;
                //OnPropertyChanged("HomeLbl");
            }
        }

        public RelayCommand NewSeriesCommand { get; set; }
        public RelayCommand NewGameCommand { get; set; }
        public RelayCommand SettingsCommand { get; set; }
        public RelayCommand AnalysisCommand { get; set; }


        // BEGIN SAMPLE CODE
        private int _clickCount;
        public const string ClickCountPropertyName = "ClickCount";

        public RelayCommand IncrementCommand
        {
            get
            {
                return _incrementCommand
                    ?? (_incrementCommand = new RelayCommand(
                    () =>
                    {
                        ClickCount++;
                    }));
            }
        }

        public string ClickCountFormatted
        {
            get
            {
                return string.Format("Click {0}", ClickCount);
            }
        }

        private RelayCommand _incrementCommand;

        public int ClickCount
        {
            get
            {
                return _clickCount;
            }
            set
            {
                if (Set(() => ClickCount, ref _clickCount, value))
                {
                    RaisePropertyChanged(() => ClickCountFormatted);
                }
            }
        }

        // END SAMPLE CODE

        public void StartNewSeries()
        {
            // Open a new series view
        }

        public void StartNewGame()
        {
            // Open a new game view
        }

        public void StartSettings()
        {
            // Open the settings view
        }

        public void StartAnalysis()
        {
            // Open the analysis home view
        }

        #region INPC

        //public void OnPropertyChanged(string propertyName)
        //{
        //    if (PropertyChanged != null)
        //        PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        //}

        //public event PropertyChangedEventHandler PropertyChanged;

        #endregion
    }
}