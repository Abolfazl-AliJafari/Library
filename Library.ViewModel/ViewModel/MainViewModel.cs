using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.CommandWpf;
using GalaSoft.MvvmLight.Messaging;
using Library.Model.Model.Page;
using Library.Model.Model.Users;
using System;

namespace Library.ViewModel.ViewModel
{
    public class MainViewModel : ViewModelBase
    {
        public MainViewModel()
        {
            Messenger.Default.Register(this, "Login", (UserLoginModel userLoginModel) =>
            {
                TransitionSelectedIndex = 1;
            });
            Messenger.Default.Register(this, "Logout", (string message) =>
            {
                TransitionSelectedIndex = 0;
            });

        }

        private int _TransitionSelectedIndex = 0;
        public int TransitionSelectedIndex
        {
            get { return _TransitionSelectedIndex; }
            set
            {
                if (_TransitionSelectedIndex == value)
                    return;
                _TransitionSelectedIndex = value;
                RaisePropertyChanged("TransitionSelectedIndex");
            }
        }


        public RelayCommand LogoutCommand => new RelayCommand(() =>
        {
            Messenger.Default.Send("logout " + DateTime.Now, "Logout");
        });
    }
}