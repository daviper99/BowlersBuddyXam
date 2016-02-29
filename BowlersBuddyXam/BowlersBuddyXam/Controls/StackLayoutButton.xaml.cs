using System;
using Xamarin.Forms;

namespace BowlersBuddyXam.Controls
{
    public partial class StackLayoutButton : StackLayout
    {
        public StackLayoutButton()
        {
            InitializeComponent();

            var tgr = new TapGestureRecognizer();
            tgr.SetBinding(TapGestureRecognizer.CommandProperty, "TapCommand");
            //tgr.Tapped += (s, e) =>
            //{
            //    // Handle the tap
            //    if (Tapped != null) this.Tapped(s, e);
            //};

            this.ctrlIcon.GestureRecognizers.Add(tgr);
            this.ctrlText.GestureRecognizers.Add(tgr);
        }

        public Color TextColor
        {
            get { return this.ctrlText.TextColor; }
            set { this.ctrlText.TextColor = value; }
        }

        public Label TextControl
        {
            get { return this.ctrlText; }
            set { this.ctrlText = value; }
        }

        //protected void OnButtonTapped(object sender, EventArgs e)
        //{
        //    var container = sender as View;
        //    if (container == null) return;

        //    var activity = container.BindingContext as Activity;
        //    if (activity == null) return;

        //    ContentPage page = activity.GetContentPage();
        //    Navigation.PushAsync(page);
        //}
    }
}