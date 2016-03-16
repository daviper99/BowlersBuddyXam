using System.ComponentModel;
using System.Linq;
using SQLite;

namespace BowlersBuddyXam.Model
{
    internal class Frame : INotifyPropertyChanged
    {
        private readonly SQLiteConnection _db = App.conn;
        private int _frameId { get; set; }
        private tblFrame _newFrame = new tblFrame();
        public int FrameId { get; set; }
        private int _balls { get; set; }
        private int _gameid { get; set; }
        private int _frameNbr { get; set; }

        public Frame NewFrame(int nbrBalls, int frameNbr, int gameId)
        {
            _balls = nbrBalls;
            _frameNbr = frameNbr;
            _gameid = gameId;
            var _qry = new TableQuery<tblFrame>(_db);


            _qry = from s in _db.Table<tblFrame>()
                where s.game_id == _gameid && s.frame_nbr == _frameNbr
                select s;

            if (_qry.Any())
            {
                // Assign existing record to internal variable
                _newFrame = _qry.ElementAt(0);
            }
            else
            {
                // Build a new record
                AddToDb();
            }
            _frameId = _newFrame.frame_nbr;

            return this;
        }

        ~Frame()
        {
            // make sure changes are applied to database
            UpdateToDb();
        }

        private bool AddToDb()
        {
            var helper = new Helper<tblFrame>();

            // Assign values to new frame record
            _newFrame.frame_nbr = _frameNbr;
            _newFrame.game_id = _gameid;
            _newFrame.is_tenth = _balls == 3 ? true : false;
            _frameId = helper.AddToTable(_newFrame);

            return _frameId > 0 ? true : false;
        }

        public bool UpdateToDb()
        {
            var helper = new Helper<tblFrame>();

            return helper.UpdateToDb(_newFrame);
        }

        #region INPC

        public void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }

        public event PropertyChangedEventHandler PropertyChanged;

        #endregion
    }
}