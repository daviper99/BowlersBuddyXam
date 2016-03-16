﻿using System.ComponentModel;
using System.Runtime.CompilerServices;
using GalaSoft.MvvmLight;

namespace BowlersBuddyXam.ViewModel
{
    public class MyViewModelBase : ViewModelBase, INotifyPropertyChanged
    {
        #region INotifyPropertyChanged implementation

        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        #endregion
    }
}