using System.ComponentModel;
using System.Linq;
using SQLite;

namespace BowlersBuddyXam.Model
{
    internal class League : INotifyPropertyChanged
    {
        private readonly SQLiteConnection _db = App.conn;
        private tblLeague _newLeague;

        public League(int leagueid)
        {
            var _qry = new TableQuery<tblLeague>(_db);


            _qry = from s in _db.Table<tblLeague>()
                where s.league_id == leagueid
                select s;

            if (_qry.Any())
            {
                // Assign existing record to internal variable
                _newLeague = _qry.ElementAt(0);
                _leagueid = leagueid;
            }
            else
            {
                // Build a new record
                AddToDb();
            }
        }

        public League()
        {
            // Build a new record
            AddToDb();
        }

        ~League()
        {
            // make sure changes are applied to database
            UpdateToDb();
        }

        private int _leagueid { get; set; }

        private bool AddToDb()
        {
            var helper = new Helper<tblLeague>();


            // Create new game record
            _newLeague = new tblLeague();

            _leagueid = helper.AddToTable(_newLeague);


            return _leagueid > 0 ? true : false;
        }

        public bool RetrieveRecord(int leagueid)
        {
            var retVal = false;

            // Load from database

            return retVal;
        }

        public bool UpdateToDb()
        {
            var helper = new Helper<tblLeague>();

            return helper.UpdateToDb(_newLeague);
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