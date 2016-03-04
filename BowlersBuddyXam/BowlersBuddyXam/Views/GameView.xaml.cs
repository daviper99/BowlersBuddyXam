using Xamarin.Forms;

namespace BowlersBuddyXam.Views
{
    public partial class GameView : ContentPage
    {
        public GameView()
        {
            InitializeComponent();
            BindingContext = App.Locator.GameBaseVm;
        }
    }
}
