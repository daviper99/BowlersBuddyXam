using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;

namespace BowlersBuddyXam.Model
{
    internal class Helper<TRecord>
    {
        private readonly SQLiteConnection _db = App.conn;

        public Helper()
        {
            
        }

        public bool UpdateToDb(TRecord tbl)
        {
            var retVal = false;

            _db.BeginTransaction();

            try
            {
                _db.Update(tbl);
                _db.Commit();
                retVal = true;
            }
            catch (Exception)
            {
                _db.Rollback();
            }


            return retVal;
        }

        public int AddToTable(TRecord tbl)
        {
            var retVal = 0;
            List<int> list = new List<int>();

            _db.BeginTransaction();

            try
            {
                _db.Insert(tbl);
                _db.Commit();

                list = _db.Query<int>("SELECT last_insert_rowid();", null);
                retVal = list[0];
            }
            catch (Exception)
            {
                _db.Rollback();
            }

            return retVal;
        }

    }
}
