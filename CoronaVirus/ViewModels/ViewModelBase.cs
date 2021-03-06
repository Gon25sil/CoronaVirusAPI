﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace CoronaVirus.ViewModels
{
    public class ViewModelBase : INotifyPropertyChanged
    {
        #region INotifyPropertyChanged Members  
        
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
        #endregion  
    }
}
