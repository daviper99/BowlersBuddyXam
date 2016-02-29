using System;
using System.IO;
using BowlersBuddyXam.Droid;
using BowlersBuddyXam.Interfaces;
using SQLite;
using Xamarin.Forms;

[assembly: Dependency(typeof (SQLite_Android))]

namespace BowlersBuddyXam.Droid
{
    public class SQLite_Android : ISQLite
    {
        public SQLiteConnection GetConnection()
        {
            var sqliteFilename = "BowlersBuddy.db3";
            var documentsPath = Environment.GetFolderPath(Environment.SpecialFolder.Personal); // Documents folder
            var path = Path.Combine(documentsPath, sqliteFilename);

            // Create the connection
            var conn = new SQLiteConnection(path);

            // Return the database connection
            return conn;
        }
    }
}