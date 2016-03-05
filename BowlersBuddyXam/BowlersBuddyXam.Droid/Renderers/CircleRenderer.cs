using Android.Graphics;
using BowlersBuddyXam.Controls;
using BowlersBuddyXam.Droid.Renderers;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: ExportRenderer(typeof (Circle), typeof (CircleRenderer))]

namespace BowlersBuddyXam.Droid.Renderers
{
    internal class CircleRenderer : ViewRenderer
    {
        public CircleRenderer()
        {
            SetWillNotDraw(false);
        }

        public override void Draw(Canvas canvas)
        {
            var circ = (Circle) Element;

            if (circ.Visible)
            {
                var rc = new Rect();
                GetDrawingRect(rc);

                var interior = rc;
                interior.Inset((int) circ.StrokeThickness, (int) circ.StrokeThickness);

                var p = new Paint
                {
                    Color = circ.FillColor.ToAndroid(),
                    AntiAlias = true
                };

                canvas.DrawRoundRect(new RectF(interior), (float) interior.Height()/2, (float) interior.Width()/2, p);

                p.Color = circ.StrokeColor.ToAndroid();
                p.StrokeWidth = (float) circ.StrokeThickness;
                p.SetStyle(Paint.Style.Stroke);

                canvas.DrawRoundRect(new RectF(rc), (float) rc.Height()/2, (float) rc.Width()/2, p);
            }
        }
    }
}