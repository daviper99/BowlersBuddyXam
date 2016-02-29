using System.ComponentModel;
using System.Linq;
using SQLite;

namespace BowlersBuddyXam.Model
{
    internal class Series : INotifyPropertyChanged
    {
        private readonly SQLiteConnection _db = App.conn;
        private tblSeries _newSeries;

        public Series(int seriesid)
        {
            var _qry = new TableQuery<tblSeries>(_db);


            _qry = from s in _db.Table<tblSeries>()
                   where s.series_id == seriesid
                   select s;

            if (_qry.Any())
            {
                // Assign existing record to internal variable
                _newSeries = _qry.ElementAt(0);
                _seriesid = seriesid;
            }
            else
            {
                // Build a new record
                AddToDb();
            }
        }

        public Series()
        {
            // Build a new record
            AddToDb();
        }

        ~Series()
        {
            // make sure changes are applied to database
            UpdateToDb();
        }

        private int _seriesid { get; set; }

        private bool AddToDb()
        {
            var helper = new Helper<tblSeries>();


            // Create new game record
            _newSeries = new tblSeries();

            _seriesid = helper.AddToTable(_newSeries);


            return _seriesid > 0 ? true : false;
        }

        public bool RetrieveRecord(int seriesid)
        {
            var retVal = false;

            // Load from database

            return retVal;
        }

        public bool UpdateToDb()
        {
            var helper = new Helper<tblSeries>();

            return helper.UpdateToDb(_newSeries);
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