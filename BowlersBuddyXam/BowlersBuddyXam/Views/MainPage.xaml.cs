using Xamarin.Forms;

namespace BowlersBuddyXam.Views
{
    public partial class MainPage:ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            BindingContext = App.Locator.MainBaseVm;
        }
    }
}