using System.ComponentModel;
using System.Linq;
using SQLite;

namespace BowlersBuddyXam.Model
{
    internal class LeagueBowler : INotifyPropertyChanged
    {
        private readonly SQLiteConnection _db = App.conn;
        private tblLeagueBowler _newLeagueBowler;

        public LeagueBowler(int leaguebowlerid)
        {
            var _qry = new TableQuery<tblLeagueBowler>(_db);


            _qry = from s in _db.Table<tblLeagueBowler>()
                   where s.league_id == leaguebowlerid
                   select s;

            if (_qry.Any())
            {
                // Assign existing record to internal variable
                _newLeagueBowler = _qry.ElementAt(0);
                _leaguebowlerid = leaguebowlerid;
            }
            else
            {
                // Build a new record
                AddToDb();
            }
        }

        public LeagueBowler()
        {
            // Build a new record
            AddToDb();
        }

        ~LeagueBowler()
        {
            // make sure changes are applied to database
            UpdateToDb();
        }

        private int _leaguebowlerid { get; set; }

        private bool AddToDb()
        {
            var helper = new Helper<tblLeagueBowler>();


            // Create new game record
            _newLeagueBowler = new tblLeagueBowler();

            _leaguebowlerid = helper.AddToTable(_newLeagueBowler);


            return _leaguebowlerid > 0 ? true : false;
        }

        public bool RetrieveRecord(int leaguebowlerid)
        {
            var retVal = false;

            // Load from database

            return retVal;
        }

        public bool UpdateToDb()
        {
            var helper = new Helper<tblLeagueBowler>();

            return helper.UpdateToDb(_newLeagueBowler);
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