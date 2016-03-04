using Android.Graphics;
using BowlersBuddyXam.Controls;
using BowlersBuddyXam.Droid.Renderers;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: ExportRenderer(typeof (RoundedBoxView), typeof (RoundedBoxViewRenderer))]

namespace BowlersBuddyXam.Droid.Renderers
{
    internal class RoundedBoxViewRenderer : ViewRenderer
    {
        public RoundedBoxViewRenderer()
        {
            SetWillNotDraw(false);
        }

        public override void Draw(Canvas canvas)
        {
            var circ = (RoundedBoxView) Element;

            if (circ.IsVisible)
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

                canvas.DrawRoundRect(new RectF(interior), (float) circ.CornerRadius, (float) circ.CornerRadius, p);

                p.Color = circ.StrokeColor.ToAndroid();
                p.StrokeWidth = (float) circ.StrokeThickness;
                p.SetStyle(Paint.Style.Stroke);

                canvas.DrawRoundRect(new RectF(rc), (float)circ.CornerRadius, (float)circ.CornerRadius, p);
            }
        }
    }
}