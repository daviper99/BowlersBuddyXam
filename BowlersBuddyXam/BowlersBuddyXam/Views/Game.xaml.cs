using Xamarin.Forms;

namespace BowlersBuddyXam.Views
{
    public partial class Game : ContentPage
    {
        public Game()
        {
            InitializeComponent();
            BindingContext = App.Locator.GameVM;
        }
    }
}
