using BowlersBuddyXam.ViewModel;

namespace BowlersBuddyXam.Controls
{
    public partial class TenthFrameView
    {
        public TenthFrameView()
        {
            InitializeComponent();
            BindingContext = new FrameViewModel();
        }
    }
}