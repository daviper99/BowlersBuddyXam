using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using SQLite;

namespace BowlersBuddyXam.Model
{
    internal class Bowler : INotifyPropertyChanged
    {
        private readonly SQLiteConnection _db = App.conn;
        private tblBowler _newBowler;

        public Bowler(int bowlerid)
        {
            var _qry = new TableQuery<tblBowler>(_db);


            _qry = from s in _db.Table<tblBowler>()
                where s.bowler_id == bowlerid
                select s;

            if (_qry.Any())
            {
                // Assign existing record to internal variable
                _newBowler = _qry.ElementAt(0);
                _bowlerid = bowlerid;
            }
            else
            {
                // Build a new record
                AddToDb();
            }
        }

        public Bowler()
        {
            // Build a new record
            AddToDb();
        }

        ~Bowler()
        {
            // make sure changes are applied to database
            UpdateToDb();
        }


        private int _bowlerid { get; set; }

        private bool AddToDb()
        {
            var helper = new Helper<tblBowler>();


            // Create new game record
            _newBowler = new tblBowler();

            _bowlerid = helper.AddToTable(_newBowler);


            return _bowlerid > 0 ? true : false;
        }

        public bool RetrieveRecord(int bowlerid)
        {
            var retVal = false;

            // Load from database

            return retVal;
        }

        public bool UpdateToDb()
        {
            var helper = new Helper<tblBowler>();

            return helper.UpdateToDb(_newBowler);
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