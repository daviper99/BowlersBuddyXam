﻿using BowlersBuddyXam.ViewModel;

namespace BowlersBuddyXam.Controls
{
    public partial class FrameView
    {
        public FrameView()
        {
            InitializeComponent();
            BindingContext = new FrameViewModel();
        }
    }
}