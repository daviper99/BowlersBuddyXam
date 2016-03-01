using BowlersBuddyXam.ViewModel;
using BowlersBuddyXam.Views;
using BowlersBuddyXam.Interfaces;
using SQLite;
using Xamarin.Forms;

namespace BowlersBuddyXam
{
    public class App : Application
    {
        // Database connection
        private static SQLiteConnection _dbconn;

        // View Model Locator
        private static ViewModelLocator _locator;

        public App()
        {
            // Create database if necessary
            if (conn.TableMappings == null)
            {
                var db = new SQLiteDb(conn.DatabasePath);
                db.Create();
            }

            // The root page of the application
            MainPage = new NavigationPage(new MainPage());
        }

        // Get a database connection from device
        public static SQLiteConnection conn => _dbconn ?? (_dbconn = DependencyService.Get<ISQLite>().GetConnection());

        // Setup the View Modal Locator
        public static ViewModelLocator Locator => _locator ?? (_locator = new ViewModelLocator());

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}