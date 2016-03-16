using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using SQLite;

namespace BowlersBuddyXam.Model
{
    internal class Game : INotifyPropertyChanged
    {
        private readonly SQLiteConnection _db = App.conn;
        private tblGame _newGame;
        private ObservableCollection<Frame> _frames { get; set; }
        private int _gameid { get; set; }

        public int GameScore
        {
            get { return _newGame.final_score; }
            set{_newGame.final_score = value;}
        }

        public DateTime GameDate
        {
            get { return _newGame.game_date; }
            set { _newGame.game_date = value; }
        }


        public bool GetGame(int gameid)
        {
            var _qry = new TableQuery<tblGame>(_db);
            bool retval = false;

            _qry = from s in _db.Table<tblGame>()
                where s.game_id == gameid
                select s;

            if (_qry.Any())
            {
                // Assign existing record to internal variable
                _newGame = _qry.ElementAt(0);
                _gameid = gameid;
                retval = true;
            }

            return retval;
        }

        public int NewGame()
        {
            // Build a new record
            AddToDb();
            return _gameid;
        }

        ~Game()
        {
            // make sure changes are applied to database
            UpdateToDb();
        }

        private bool AddToDb()
        {
            var helper = new Helper<tblGame>();
            var frame = new Frame();


            // Create new game record
            _newGame = new tblGame();

            _gameid = helper.AddToTable(_newGame);

            if (_gameid > 0)
            {
                _newGame.game_date = DateTime.Now;

                // Create 9 normal frames
                for (var i = 1; i < 10; i++)
                {

                    _frames.Insert(i, frame.NewFrame(2, i, _gameid));
                }

                // Add the tenth frame
                _frames.Insert(10, frame.NewFrame(2, 10, _gameid));
            }

            return _gameid > 0 ? true : false;
        }

        public Frame GetFrame(int index)
        {
            return _frames[index - 1];
        }

        public bool UpdateToDb()
        {
            var helper = new Helper<tblGame>();

            return helper.UpdateToDb(_newGame);
        }

        public int AssignToSeries(int seriesId)
        {
            var tsg = new tblSeriesGames();
            var helper = new Helper<tblSeriesGames>();

            // Create a new series relationship
            tsg.game_id = _gameid;
            tsg.series_id = seriesId;

            // Save to table
            return helper.AddToTable(tsg);
        }

        #region INPC

        public void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }

        public event PropertyChangedEventHandler PropertyChanged;

        #endregion
    }
}