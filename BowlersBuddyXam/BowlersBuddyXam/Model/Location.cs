using System.ComponentModel;
using System.Linq;
using SQLite;

namespace BowlersBuddyXam.Model
{
    internal class Location : INotifyPropertyChanged
    {
        private readonly SQLiteConnection _db = App.conn;
        private tblLocation _newLocation;

        public Location(int locationid)
        {
            var _qry = new TableQuery<tblLocation>(_db);


            _qry = from s in _db.Table<tblLocation>()
                   where s.location_id == locationid
                   select s;

            if (_qry.Any())
            {
                // Assign existing record to internal variable
                _newLocation = _qry.ElementAt(0);
                _locationid = locationid;
            }
            else
            {
                // Build a new record
                AddToDb();
            }
        }

        public Location()
        {
            // Build a new record
            AddToDb();
        }

        ~Location()
        {
            // make sure changes are applied to database
            UpdateToDb();
        }

        private int _locationid { get; set; }

        private bool AddToDb()
        {
            var helper = new Helper<tblLocation>();


            // Create new game record
            _newLocation = new tblLocation();

            _locationid = helper.AddToTable(_newLocation);


            return _locationid > 0 ? true : false;
        }

        public bool RetrieveRecord(int locationid)
        {
            var retVal = false;

            // Load from database

            return retVal;
        }

        public bool UpdateToDb()
        {
            var helper = new Helper<tblLocation>();

            return helper.UpdateToDb(_newLocation);
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