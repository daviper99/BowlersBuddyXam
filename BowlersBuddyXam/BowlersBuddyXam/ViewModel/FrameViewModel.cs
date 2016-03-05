using System;
using GalaSoft.MvvmLight;

namespace BowlersBuddyXam.ViewModel
{
    public class FrameViewModel : ViewModelBase
    {
        public const string ScorePropertyName = "Score";
        public const string BallOnePropertyName = "BallOne";
        public const string BallTwoPropertyName = "BallTwo";
        public const string BallThreePropertyName = "BallThree";
        public const string FrameNumberPropertyName = "FrameNumber";
        public const string IsTenthPropertyName = "IsTenth";
        public const string FrameWidthPropertyName = "FrameWidth";
        public const string FrameHeightPropertyName = "FrameHeight";
        public const string NumberBoxHeightPropertyName = "NumberBoxHeight";
        public const string FontSizePropertyName = "FontSize";
        public const string SplitVisiblePropertyName = "SplitVisible";
        public const string FrameIdPropertyName = "FrameId";
        public const string GameIdPropertyName = "GameId";

        private string _b1;
        private string _b2;
        private string _b3;
        private int _fontSize = 25;
        private int _frameHeight = 70;
        private int _frameId;
        private string _frameNbr;
        private int _frameWidth = 70;
        private int _gameId;
        private bool _isTenth;
        private int _nbrBoxHeight = 20;
        private string _score;
        private bool _splitVisible;

        /// <summary>
        ///     Sets and gets the GameId property.
        ///     Changes to that property's value raise the PropertyChanged event.
        ///     This property's value is broadcasted by the MessengerInstance when it changes.
        /// </summary>
        public int GameId
        {
            get { return _gameId; }

            set
            {
                if (_gameId == value)
                {
                    return;
                }

                var oldValue = _gameId;
                _gameId = value;
                RaisePropertyChanged(GameIdPropertyName, oldValue, value, true);
            }
        }

        /// <summary>
        ///     Sets and gets the FrameId property.
        ///     Changes to that property's value raise the PropertyChanged event.
        ///     This property's value is broadcasted by the MessengerInstance when it changes.
        /// </summary>
        public int FrameId
        {
            get { return _frameId; }

            set
            {
                if (_frameId == value)
                {
                    return;
                }

                var oldValue = _frameId;
                _frameId = value;
                RaisePropertyChanged(FrameIdPropertyName, oldValue, value, true);
            }
        }

        /// <summary>
        ///     Sets and gets the Score property.
        ///     Changes to that property's value raise the PropertyChanged event.
        ///     This property's value is broadcasted by the MessengerInstance when it changes.
        /// </summary>
        public string Score
        {
            get { return _score; }

            set
            {
                if (_score == value)
                {
                    return;
                }

                var oldValue = _score;
                _score = value;
                RaisePropertyChanged(ScorePropertyName, oldValue, value, true);
            }
        }

        /// <summary>
        ///     Sets and gets the BallOne property.
        ///     Changes to that property's value raise the PropertyChanged event.
        ///     This property's value is broadcasted by the MessengerInstance when it changes.
        /// </summary>
        public string BallOne
        {
            get { return _b1; }

            set
            {
                if (_b1 == value)
                {
                    return;
                }

                var oldValue = _b1;

                if (value == "10")
                {
                    _b1 = "";
                    BallTwo = "X";
                }
                else
                {
                    _b1 = value;
                }
                RaisePropertyChanged(BallOnePropertyName, oldValue, value, true);
            }
        }

        /// <summary>
        ///     Sets and gets the BallTwo property.
        ///     Changes to that property's value raise the PropertyChanged event.
        ///     This property's value is broadcasted by the MessengerInstance when it changes.
        /// </summary>
        public string BallTwo
        {
            get { return _b2; }

            set
            {
                if (_b2 == value)
                {
                    return;
                }

                var oldValue = _b2;

                if (value != "X")
                {
                    _b2 = Convert.ToInt16(_b1) + Convert.ToInt16(value) == 10 ? "/" : value;
                }
                else
                {
                    _b2 = value;
                }

                RaisePropertyChanged(BallTwoPropertyName, oldValue, value, true);
            }
        }

        /// <summary>
        ///     Sets and gets the BallThree property.
        ///     Changes to that property's value raise the PropertyChanged event.
        ///     This property's value is broadcasted by the MessengerInstance when it changes.
        /// </summary>
        public string BallThree
        {
            get { return _b3; }

            set
            {
                if (_b3 == value)
                {
                    return;
                }

                var oldValue = _b3;
                _b3 = value == "10" ? "X" : value;

                RaisePropertyChanged(BallThreePropertyName, oldValue, value, true);
            }
        }

        /// <summary>
        ///     Sets and gets the FrameNumber property.
        ///     Changes to that property's value raise the PropertyChanged event.
        ///     This property's value is broadcasted by the MessengerInstance when it changes.
        /// </summary>
        public string FrameNumber
        {
            get { return _frameNbr; }

            set
            {
                if (_frameNbr == value)
                {
                    return;
                }

                var oldValue = _frameNbr;
                _frameNbr = value;
                RaisePropertyChanged(FrameNumberPropertyName, oldValue, value, true);
            }
        }

        /// <summary>
        ///     Sets and gets the IsTenth property.
        ///     Changes to that property's value raise the PropertyChanged event.
        ///     This property's value is broadcasted by the MessengerInstance when it changes.
        /// </summary>
        public bool IsTenth
        {
            get { return _isTenth; }

            set
            {
                if (_isTenth == value)
                {
                    return;
                }

                var oldValue = _isTenth;
                _isTenth = value;
                RaisePropertyChanged(IsTenthPropertyName, oldValue, value, true);
            }
        }

        /// <summary>
        ///     Sets and gets the FrameWidth property.
        ///     Changes to that property's value raise the PropertyChanged event.
        ///     This property's value is broadcasted by the MessengerInstance when it changes.
        /// </summary>
        public int FrameWidth
        {
            get { return _frameWidth; }

            set
            {
                if (_frameWidth == value)
                {
                    return;
                }

                var oldValue = _frameWidth;
                _frameWidth = value;
                RaisePropertyChanged(FrameWidthPropertyName, oldValue, value, true);
            }
        }

        /// <summary>
        ///     Sets and gets the FrameHeight property.
        ///     Changes to that property's value raise the PropertyChanged event.
        ///     This property's value is broadcasted by the MessengerInstance when it changes.
        /// </summary>
        public int FrameHeight
        {
            get { return _frameHeight; }

            set
            {
                if (_frameHeight == value)
                {
                    return;
                }

                var oldValue = _frameHeight;
                _frameHeight = value;
                RaisePropertyChanged(FrameHeightPropertyName, oldValue, value, true);
            }
        }

        /// <summary>
        ///     Sets and gets the NumberBoxHeight property.
        ///     Changes to that property's value raise the PropertyChanged event.
        ///     This property's value is broadcasted by the MessengerInstance when it changes.
        /// </summary>
        public int NumberBoxHeight
        {
            get { return _nbrBoxHeight; }

            set
            {
                if (_nbrBoxHeight == value)
                {
                    return;
                }

                var oldValue = _nbrBoxHeight;
                _nbrBoxHeight = value;
                RaisePropertyChanged(NumberBoxHeightPropertyName, oldValue, value, true);
            }
        }

        /// <summary>
        ///     Sets and gets the FontSize property.
        ///     Changes to that property's value raise the PropertyChanged event.
        ///     This property's value is broadcasted by the MessengerInstance when it changes.
        /// </summary>
        public int FontSize
        {
            get { return _fontSize; }

            set
            {
                if (_fontSize == value)
                {
                    return;
                }

                var oldValue = _fontSize;
                _fontSize = value;
                RaisePropertyChanged(FontSizePropertyName, oldValue, value, true);
            }
        }

        /// <summary>
        ///     Sets and gets the SplitVisible property.
        ///     Changes to that property's value raise the PropertyChanged event.
        ///     This property's value is broadcasted by the MessengerInstance when it changes.
        /// </summary>
        public bool SplitVisible
        {
            get { return _splitVisible; }

            set
            {
                if (_splitVisible == value)
                {
                    return;
                }

                var oldValue = _splitVisible;
                _splitVisible = value;
                RaisePropertyChanged(SplitVisiblePropertyName, oldValue, value, true);
            }
        }
    }
}