using Xamarin.Forms;

namespace BowlersBuddyXam.Views
{
    public partial class Game : ContentPage
    {
        public Game()
        {
            InitializeComponent();
            BindingContext = "{Binding Source={StaticResource Locator}, Path=GameViewModel}";
        }
    }
}
