namespace BowlersBuddy.WinPhone81.Common
{
    public class OrientationStateMessage
    {
        public PageOrientations Orientation
        {
            get;
            private set;
        }

        public OrientationStateMessage(PageOrientations orientation)
        {
            Orientation = orientation;
        }
    }
}