using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel.Channels;
using System.Text;
using System.Threading.Tasks;
using GalaSoft.MvvmLight;

namespace BowlersBuddyXam.ViewModel
{
    class RackViewModel : MyViewModelBase
    {
        public RackViewModel()
        {
        }

        public const string PinBoxSizePropertyName = "PinBoxSize";

        private int _pinBoxSize = 20;

        /// <summary>
        /// Sets and gets the PinBoxSize property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// This property's value is broadcasted by the MessengerInstance when it changes.
        /// </summary>
        public int PinBoxSize
        {
            get
            {
                return _pinBoxSize;
            }

            set
            {
                if (_pinBoxSize == value)
                {
                    return;
                }

                var oldValue = _pinBoxSize;
                _pinBoxSize = value;
                RaisePropertyChanged(PinBoxSizePropertyName, oldValue, value, true);
                OnPropertyChanged("PinBoxSize");

            }
        }
    }
}
