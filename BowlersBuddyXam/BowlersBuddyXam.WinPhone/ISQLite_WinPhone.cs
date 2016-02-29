using System.IO;
using Windows.Storage;
using BowlersBuddyXam.Interfaces;
using BowlersBuddyXam.WinPhone;
using SQLite.Net;
using Xamarin.Forms;

[assembly: Dependency(typeof (SQLite_WinPhone))]

namespace BowlersBuddyXam.WinPhone
{
    public class SQLite_WinPhone : ISQLite
    {
        public SQLiteConnection GetConnection()
        {
            var sqliteFilename = "BowlersBuddy.db3";
            var path = Path.Combine(ApplicationData.Current.LocalFolder.Path, sqliteFilename);

            // Create the connection
            var conn = new SQLiteConnection(path);

            // Return the database connection
            return conn;
        }
    }
}