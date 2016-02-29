using System.ComponentModel;
using System.Linq;
using SQLite;

namespace BowlersBuddyXam.Model
{
    internal class SeriesGames : INotifyPropertyChanged
    {
        private readonly SQLiteConnection _db = App.conn;
        private tblSeriesGames _newSeriesGames;

        public SeriesGames(int seriesgamesid)
        {
            var _qry = new TableQuery<tblSeriesGames>(_db);


            _qry = from s in _db.Table<tblSeriesGames>()
                   where s.series_id == seriesgamesid
                   select s;

            if (_qry.Any())
            {
                // Assign existing record to internal variable
                _newSeriesGames = _qry.ElementAt(0);
                _seriesgamesid = seriesgamesid;
            }
            else
            {
                // Build a new record
                AddToDb();
            }
        }

        public SeriesGames()
        {
            // Build a new record
            AddToDb();
        }

        ~SeriesGames()
        {
            // make sure changes are applied to database
            UpdateToDb();
        }

        private int _seriesgamesid { get; set; }

        private bool AddToDb()
        {
            var helper = new Helper<tblSeriesGames>();


            // Create new game record
            _newSeriesGames = new tblSeriesGames();

            _seriesgamesid = helper.AddToTable(_newSeriesGames);


            return _seriesgamesid > 0 ? true : false;
        }

        public bool RetrieveRecord(int seriesgamesid)
        {
            var retVal = false;

            // Load from database

            return retVal;
        }

        public bool UpdateToDb()
        {
            var helper = new Helper<tblSeriesGames>();

            return helper.UpdateToDb(_newSeriesGames);
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