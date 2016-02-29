using Xamarin.Forms;

namespace BowlersBuddyXam.Views
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            //BindingContext = "{Binding Source={StaticResource Locator}, Path=MainViewModel}";
            BindingContext = App.Locator.Main;
        }
    }
}