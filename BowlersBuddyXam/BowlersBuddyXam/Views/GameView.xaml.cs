using System.Collections.ObjectModel;
using BowlersBuddyXam.Controls;
using BowlersBuddyXam.ViewModel;
using Xamarin.Forms;

namespace BowlersBuddyXam.Views
{
    public partial class GameView : ContentPage
    {
        private ObservableCollection<FrameViewModel> _fvmcol = new ObservableCollection<FrameViewModel>();

        public GameView()
        {
            FrameView fv;
            FrameViewModel fvm;

            InitializeComponent();
            BindingContext = App.Locator.GameBaseVm;

            for (int i = 1; i < 10; i++)
            {
                fv = new FrameView();

                fvm = (FrameViewModel) fv.BindingContext;
                fvm.FrameNumber = i.ToString();
                FrameStack.Children.Add(fv);

                _fvmcol.Add(fvm);
            }
        }
    }
}
