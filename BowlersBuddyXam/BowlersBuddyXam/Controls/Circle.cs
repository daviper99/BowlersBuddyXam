using Xamarin.Forms;

namespace BowlersBuddyXam.Controls
{
    public class Circle : View
    {
        public static readonly BindableProperty FillColorProperty =
            BindableProperty.Create<Circle, Color>(p => p.FillColor, Color.Accent);

        public static readonly BindableProperty StrokeColorProperty =
            BindableProperty.Create<Circle, Color>(p => p.StrokeColor, Color.Accent);

        public static readonly BindableProperty StrokeThicknessProperty =
            BindableProperty.Create<Circle, double>(p => p.StrokeThickness, default(double));

        public static readonly BindableProperty VisibleProperty =
            BindableProperty.Create<Circle, bool>(p => p.IsVisible, false);

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
            get { return (bool) GetValue(IsVisibleProperty); }
            set { SetValue(IsVisibleProperty, value); }
        }
    }
}