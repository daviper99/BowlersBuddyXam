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

        protected override void OnElementChanged(ElementChangedEventArgs<View> e)
        {
            base.OnElementChanged(e);
            Invalidate();
        }

        public override void Draw(Canvas canvas)
        {
            var rec = (RoundedBoxView) Element;

            if (rec.Visible)
            {
                var rc = new Rect();
                GetDrawingRect(rc);

                var interior = rc;
                interior.Inset((int) rec.StrokeThickness, (int) rec.StrokeThickness);

                var p = new Paint
                {
                    Color = rec.FillColor.ToAndroid(),
                    AntiAlias = true
                };

                canvas.DrawRoundRect(new RectF(interior), (float) rec.CornerRadius, (float) rec.CornerRadius, p);

                p.Color = rec.StrokeColor.ToAndroid();
                p.StrokeWidth = (float) rec.StrokeThickness;
                p.SetStyle(Paint.Style.Stroke);

                canvas.DrawRoundRect(new RectF(rc), (float)rec.CornerRadius, (float)rec.CornerRadius, p);
            }
        }
    }
}