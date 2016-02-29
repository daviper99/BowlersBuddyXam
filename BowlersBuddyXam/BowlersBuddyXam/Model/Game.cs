using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using SQLite;

namespace BowlersBuddyXam.Model
{
    internal class Game : INotifyPropertyChanged
    {
        private readonly SQLiteConnection _db = App.conn;

        public ObservableCollection<Frame> Frames { get; private set; }
        private int _gameid { get; set; }
        private tblGame _newGame;

        public Game(int gameid)
        {
            var _qry = new TableQuery<tblGame>(_db);


            _qry = from s in _db.Table<tblGame>()
                   where s.game_id == gameid 
                   select s;

            if (_qry.Any())
            {
                // Assign existing record to internal variable
                _newGame = _qry.ElementAt(0);
                _gameid = gameid;
            }
            else
            {
                // Build a new record
                AddToDb();
            }

        }

        public Game()
        {
            // Build a new record
            AddToDb();
        }

        ~Game()
        {
            // make sure changes are applied to database
            UpdateToDb();
        }

        private bool AddToDb()
        {
            Helper<tblGame> helper = new Helper<tblGame>();
            

            // Create new game record
            _newGame = new tblGame();

             _gameid = helper.AddToTable(_newGame);

            if (_gameid > 0)
            {
                // Create 9 normal frames
                for (var i = 1; i < 10; i++)
                {
                    Frames.Insert(i, new Frame(2, i, _gameid));
                }

                // Add the tenth frame
                Frames.Insert(10, new Frame(3, 10, _gameid));
            }

            return _gameid > 0 ? true : false;

        }

        public bool RetrieveRecord(int gameId)
        {
            var retVal = false;

            // Load from database

            return retVal;
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