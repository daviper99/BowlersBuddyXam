using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;

namespace BowlersBuddyXam.Interfaces
{
    public interface ISQLite
    {
        SQLite.SQLiteConnection GetConnection();
    }
}
