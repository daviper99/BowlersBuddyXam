using System.ServiceModel.Channels;
using BowlersBuddyXam.ViewModel;
using Xamarin.Forms;

namespace BowlersBuddyXam.Controls
{
    public partial class PinView
    {
        public PinView()
        {
            InitializeComponent();
            BindingContext = new PinViewModel();
        }

    }
}