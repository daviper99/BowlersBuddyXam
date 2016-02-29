using System.ComponentModel;
using System.Linq;
using SQLite;

namespace BowlersBuddyXam.Model
{
    internal class Throw : INotifyPropertyChanged
    {
        private readonly SQLiteConnection _db = App.conn;
        private tblThrow _newThrow;

        public Throw(int throwid)
        {
            var _qry = new TableQuery<tblThrow>(_db);


            _qry = from s in _db.Table<tblThrow>()
                   where s.throw_id == throwid
                   select s;

            if (_qry.Any())
            {
                // Assign existing record to internal variable
                _newThrow = _qry.ElementAt(0);
                _throwid = throwid;
            }
            else
            {
                // Build a new record
                AddToDb();
            }
        }

        public Throw()
        {
            // Build a new record
            AddToDb();
        }

        ~Throw()
        {
            // make sure changes are applied to database
            UpdateToDb();
        }

        private int _throwid { get; set; }

        private bool AddToDb()
        {
            var helper = new Helper<tblThrow>();


            // Create new game record
            _newThrow = new tblThrow();

            _throwid = helper.AddToTable(_newThrow);


            return _throwid > 0 ? true : false;
        }

        public bool RetrieveRecord(int throwid)
        {
            var retVal = false;

            // Load from database

            return retVal;
        }

        public bool UpdateToDb()
        {
            var helper = new Helper<tblThrow>();

            return helper.UpdateToDb(_newThrow);
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