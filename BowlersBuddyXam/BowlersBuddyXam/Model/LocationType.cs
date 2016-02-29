using System.ComponentModel;
using System.Linq;
using SQLite;

namespace BowlersBuddyXam.Model
{
    internal class LocationType : INotifyPropertyChanged
    {
        private readonly SQLiteConnection _db = App.conn;
        private tblLocationType _newLocationType;

        public LocationType(int locationtypeid)
        {
            var _qry = new TableQuery<tblLocationType>(_db);


            _qry = from s in _db.Table<tblLocationType>()
                   where s.location_type_id == locationtypeid
                   select s;

            if (_qry.Any())
            {
                // Assign existing record to internal variable
                _newLocationType = _qry.ElementAt(0);
                _locationtypeid = locationtypeid;
            }
            else
            {
                // Build a new record
                AddToDb();
            }
        }

        public LocationType()
        {
            // Build a new record
            AddToDb();
        }

        ~LocationType()
        {
            // make sure changes are applied to database
            UpdateToDb();
        }

        private int _locationtypeid { get; set; }

        private bool AddToDb()
        {
            var helper = new Helper<tblLocationType>();


            // Create new game record
            _newLocationType = new tblLocationType();

            _locationtypeid = helper.AddToTable(_newLocationType);


            return _locationtypeid > 0 ? true : false;
        }

        public bool RetrieveRecord(int locationtypeid)
        {
            var retVal = false;

            // Load from database

            return retVal;
        }

        public bool UpdateToDb()
        {
            var helper = new Helper<tblLocationType>();

            return helper.UpdateToDb(_newLocationType);
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