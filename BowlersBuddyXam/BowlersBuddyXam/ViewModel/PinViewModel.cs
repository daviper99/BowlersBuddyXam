using System.ComponentModel;
using System.Runtime.CompilerServices;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using Xamarin.Forms;

namespace BowlersBuddyXam.ViewModel
{
    internal class PinViewModel : MyViewModelBase
    {
        public const string MakeSolidPropertyName = "MakeSolidPropertyName";
        public const string FillColorPropertyName = "FillColorPropertyName";
        public const string StrokeColorPropertyName = "StrokeColorPropertyName";

        /// <summary>
        ///     The <see cref="PinImage" /> property's name.
        /// </summary>
        public const string PinImagePropertyName = "PinImage";

        private Color _fillColor = Color.Red;

        private Image _myImage;
        private RelayCommand _pinTapped;
        private Color _strokeColor = Color.Lime;


        /// <summary>
        ///     Gets the PinTapped.
        /// </summary>
        public RelayCommand PinTapped
        {
            get
            {
                return _pinTapped
                       ?? (_pinTapped = new RelayCommand(
                           () =>
                           {
                               //                              Debug.WriteLine("Pin Tapped");
                               FillColor = FillColor == Color.Yellow ? Color.Red : Color.Yellow;
                           }));
            }
        }

        /// <summary>
        ///     Sets and gets the FillColor property.
        ///     Changes to that property's value raise the PropertyChanged event.
        ///     This property's value is broadcasted by the MessengerInstance when it changes.
        /// </summary>
        public Color FillColor
        {
            get { return _fillColor; }

            set
            {
                //               Debug.WriteLine("Setting FillColor.  _fillColor = {0}, value = {1}", _fillColor.ToString(), value.ToString());
                if (_fillColor == value)
                {
                    //                   Debug.WriteLine("Returning no change in value");
                    return;
                }

                var oldValue = _fillColor;
                _fillColor = value;
                //              Debug.WriteLine("Calling RaisePropertyChaned");
                RaisePropertyChanged(FillColorPropertyName, oldValue, value, true);
                OnPropertyChanged("FillColor");
            }
        }

        /// <summary>
        ///     Sets and gets the StrokeColor property.
        ///     Changes to that property's value raise the PropertyChanged event.
        ///     This property's value is broadcasted by the MessengerInstance when it changes.
        /// </summary>
        public Color StrokeColor
        {
            get { return _strokeColor; }

            set
            {
                if (_strokeColor == value)
                {
                    return;
                }

                var oldValue = _strokeColor;
                _strokeColor = value;
                RaisePropertyChanged(StrokeColorPropertyName, oldValue, value, true);
                OnPropertyChanged("StrokeColor");
            }
        }

        /// <summary>
        ///     Sets and gets the PinImage property.
        ///     Changes to that property's value raise the PropertyChanged event.
        ///     This property's value is broadcasted by the MessengerInstance when it changes.
        /// </summary>
        public Image PinImage
        {
            get { return _myImage; }

            set
            {
                if (_myImage == value)
                {
                    return;
                }

                var oldValue = _myImage;
                _myImage = value;
                RaisePropertyChanged(PinImagePropertyName, oldValue, value, true);
                OnPropertyChanged("PinImage");
            }
        }
    }
}