using BowlersBuddyXam.ViewModel;
using Xamarin.Forms.Internals;

namespace BowlersBuddyXam.Controls
{
    public partial class FrameView
    {
        public FrameView()
        {
            InitializeComponent();
            BindingContext = new FrameViewModel();
        }
    }
}