using System.Collections.ObjectModel;
using BowlersBuddyXam.Controls;

namespace BowlersBuddyXam.ViewModel
{
    public class GameViewModel : BaseViewModel
    {
        public ObservableCollection<Frame> GameFrames;

        public GameViewModel()
        {
            GameFrames = new ObservableCollection<Frame>();
            LoadFrames();
        }

        private void LoadFrames()
        {
            GameFrames.Clear();

            GameFrames.Add(new Frame());

            OnPropertyChanged("GameFrames");


        }
    }
}