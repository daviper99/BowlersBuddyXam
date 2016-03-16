using BowlersBuddyXam.Controls;
using BowlersBuddyXam.ViewModel;
using Xamarin.Forms;

namespace BowlersBuddyXam.Views
{
    public partial class GameView
    {
        private readonly GameViewModel _gvm;

        public GameView()
        {
            InitializeComponent();
            BindingContext = App.Locator.GameBaseVm;
            _gvm = (GameViewModel) BindingContext;

            AddNewFrames();
        }

        public GameView(int gameId)
        {
            InitializeComponent();
            BindingContext = App.Locator.GameBaseVm;
            _gvm = (GameViewModel) BindingContext;
            _gvm.GetGame(gameId);
        }

        private void AddNewFrames()
        {
            FrameView fv;
            FrameViewModel fvm;

            for (var i = 1; i < 10; i++)
            {
                fv = new FrameView();

                fvm = (FrameViewModel) fv.BindingContext;
                fvm.FrameNumber = i.ToString();
                FrameStack.Children.Add(fv);

                _gvm.AddFrame(fvm, i);
            }

            // Add the tenth frame
            var tfv = new TenthFrameView();
            fvm = (FrameViewModel) tfv.BindingContext;
            fvm.FrameNumber = "10";
            fvm.IsTenth = true;
            fvm.FrameWidth = fvm.FrameWidth/2*3;
            FrameStack.Children.Add(tfv);

            _gvm.AddFrame(fvm, 10);
        }
    }
}