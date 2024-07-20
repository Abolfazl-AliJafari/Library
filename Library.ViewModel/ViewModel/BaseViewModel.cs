using GalaSoft.MvvmLight.Messaging;
using Library.Model.Model.Page;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.ViewModel.ViewModel
{
    public class BaseViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public void RaisePropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        protected void OpenPopup(PopupModel popup)
        {
            Messenger.Default.Send<PopupModel>(popup, "OpenPopup");
        }

    }
}


