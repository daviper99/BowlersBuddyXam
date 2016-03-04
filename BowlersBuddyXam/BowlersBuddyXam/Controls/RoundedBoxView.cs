using Xamarin.Forms;

namespace BowlersBuddyXam.Controls
{
    public class RoundedBoxView : BoxView
    {
        public static readonly BindableProperty FillColorProperty =
            BindableProperty.Create<RoundedBoxView, Color>(p => p.FillColor, Color.Accent);

        public static readonly BindableProperty StrokeColorProperty =
            BindableProperty.Create<RoundedBoxView, Color>(p => p.StrokeColor, Color.Accent);

        public static readonly BindableProperty StrokeThicknessProperty =
            BindableProperty.Create<RoundedBoxView, double>(p => p.StrokeThickness, default(double));

        public static readonly BindableProperty VisibleProperty =
            BindableProperty.Create<RoundedBoxView, bool>(p => p.Visible, true);

        public static readonly BindableProperty CornerRadiusProperty =
            BindableProperty.Create<RoundedBoxView, double>(p => p.CornerRadius, default(double));

        public Color FillColor
        {
            get { return (Color) GetValue(FillColorProperty); }
            set { SetValue(FillColorProperty, value); }
        }

        public Color StrokeColor
        {
            get { return (Color) GetValue(StrokeColorProperty); }
            set { SetValue(StrokeColorProperty, value); }
        }

        public double StrokeThickness
        {
            get { return (double) GetValue(StrokeThicknessProperty); }
            set { SetValue(StrokeThicknessProperty, value); }
        }

        public bool Visible
        {
            get { return (bool) GetValue(VisibleProperty); }
            set { SetValue(VisibleProperty, value); }
        }

        public double CornerRadius
        {
            get { return (double)GetValue(CornerRadiusProperty); }
            set { SetValue(CornerRadiusProperty, value); }
        }

    }
}