using System;
using System.ComponentModel;
using System.Linq;

namespace BowlersBuddyXam.Model
{
    public class GameScore:INotifyPropertyChanged
    {
        private int _itsCurrentFrame;
        private bool _firstThrowInFrame = true;
        private readonly Scorer _itsScorer = new Scorer();
        private bool _isSplit;

        #region INPC
        public void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }

        public event PropertyChangedEventHandler PropertyChanged;

        #endregion

        public int Score()
        {
            return ScoreForFrame(_itsCurrentFrame);
        }

        public void Add(int pins)
        {
            _itsScorer.AddThrow(pins);
            AdjustCurrentFrame(pins);
        }

        private void AdjustCurrentFrame(int pins)
        {
            if (_firstThrowInFrame)
            {
                if (AdjustFrameForStrike(pins) == false)
                    _firstThrowInFrame = false;
            }
            else
            {
                _firstThrowInFrame = true;
                AdvanceFrame();
            }
        }

        private bool AdjustFrameForStrike(int pins)
        {
            if (pins == 10)
            {
                AdvanceFrame();
                return true;
            }
            return false;
        }

        private void AdvanceFrame()
        {
            _itsCurrentFrame = Math.Min(10, _itsCurrentFrame + 1);
        }

        public int ScoreForFrame(int theFrame)
        {
            return _itsScorer.ScoreForFrame(theFrame);
        }

        /// <summary>
        /// This function returns a boolean indicating whether the remaining pins after the first ball form a recognized split.  This
        /// algorithm works by starting at the rear of the rack and removing all adjacent pins to the reference pin.  If there is only 
        /// one pin left after removing adjacent pins then a split is identified.  By working from the back of the rack and decrementing 
        /// the pin count for each pin checked all split possibilities are identified
        /// </summary>
        /// <param name="i"></param>
        /// <returns>bool</returns>
        public bool IsSplit(int[] i)
        {
            _isSplit = false;

            if (i == null)
            {
                _isSplit = false;
            }
            else if (i.Length == 1)
            {
                // Cannot have a split if nine pins removed
                _isSplit = false;
            }
            else if (i.Contains(1))
            {
                // Cannot have split if head pin present.  
                _isSplit = false;
            }
            else
            {
                int pinCount = i.Length;

                // Check 10 pin
                if (pinCount > 1 && i.Contains(10))
                {
                    // Check for 6 pin
                    if (i.Contains(6) != true)
                    {
                        _isSplit = (pinCount > 1);
                    }
                    else
                    {
                        pinCount--;                  
                    }
                }
                // Check 9 pin
                if (pinCount > 1 && i.Contains(9))
                {
                    // check for 3, 5, or 6 pin.  10 pin was already checked
                    if ((i.Contains(3) || i.Contains(5) || i.Contains(6)) != true)
                    {
                        _isSplit = (pinCount > 1);
                    }
                    else
                    {
                        pinCount--;
                    }
                }
                // Check 8 pin
                if (pinCount > 1 && i.Contains(8))
                {
                    // check for 2, 4, or 5 pin.  
                    if ((i.Contains(2) || i.Contains(4) || i.Contains(5)) != true)
                    {
                        _isSplit = (pinCount > 1);
                    }
                    else
                    {
                        pinCount--;
                    }

                }
                // Check 7 pin
                if (pinCount > 1 && i.Contains(7))
                {
                    // check for 4 pin.  
                    if (i.Contains(4)  != true)
                    {
                        _isSplit = (pinCount > 1);
                    }
                    else
                    {
                        pinCount--;
                    }

                }

                // Check 6 pin
                if (pinCount > 1 && i.Contains(6))
                {
                    // check for 3 pin.  
                    if (i.Contains(3) != true)
                    {
                        _isSplit = (pinCount > 1);
                    }
                    else
                    {
                        pinCount--;
                    }

                }
                // Check 5 pin
                if (pinCount > 1 && i.Contains(5))
                {
                    // check for 2, or 3 pin.  
                    if ((i.Contains(2) || i.Contains(3)) != true)
                    {
                        _isSplit = (pinCount > 1);
                    }
                    else
                    {
                        pinCount--;
                    }

                }
                // Check 4 pin
                if (pinCount > 1 && i.Contains(4))
                {
                    // check for 2 pin. 
                    if (i.Contains(2) != true)
                    {
                        _isSplit = (pinCount > 1);
                    }
                    else
                    {
                        pinCount--;
                    }

                }
                // check 3 pin
                if (pinCount > 1 && i.Contains(3))
                {
                        _isSplit = (pinCount > 1);
                }
            }

            return _isSplit;
        }
    }

    public class Scorer
    {
        private int _ball;
        private readonly int[] _itsThrows = new int[21];
        private int _itsCurrentThrow;

        public void AddThrow(int pins)
        {
            _itsThrows[_itsCurrentThrow++] = pins;
        }

        public int ScoreForFrame(int theFrame)
        {
            _ball = 0;
            var score = 0;
            for (var currentFrame = 0;
                currentFrame < theFrame;
                currentFrame++)
            {
                if (Strike())
                    score += 10 + NextTwoBalls();
                else if (Spare())
                    score += 10 + NextBall();
                else
                    score += TwoBallsInFrame();
            }

            return score;
        }

        private bool Strike()
        {
            if (_itsThrows[_ball] == 10)
            {
                _ball++;
                return true;
            }
            return false;
        }

        private bool Spare()
        {
            if (_itsThrows[_ball] + _itsThrows[_ball + 1] == 10)
            {
                _ball += 2;
                return true;
            }
            return false;
        }

        private int NextTwoBalls()
        {
            return _itsThrows[_ball] + _itsThrows[_ball + 1];
        }

        private int NextBall()
        {
            return _itsThrows[_ball];
        }

        private int TwoBallsInFrame()
        {
            return _itsThrows[_ball++] + _itsThrows[_ball++];
        }
     }
}


