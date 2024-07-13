using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Library.ViewModel.ViewModel
{
    public class LoginViewModel :BaseViewModel
    { 
        public LoginViewModel()
        {

        }

        #region Property
        private string _UserName = "admin";
        public string UserName
        {
            get { return _UserName; }
            set
            {
                if (_UserName == value)
                    return;
                _UserName = value;
                RaisePropertyChanged("UserName");
            }
        }

        private string _Password = "123";
        public string Password
        {
            get { return _Password; }
            set
            {
                if (_Password == value)
                    return;
                _Password = value;
                RaisePropertyChanged("Password");
            }
        }
        #endregion

        private bool _ShowButton;

        public bool ShowButton
        {
            get { return _ShowButton; }
            set
            {
                if (_ShowButton == value)
                    return;
                _ShowButton = value;
                RaisePropertyChanged("ShowButton");
            }
        }



        #region Command
        public RelayCommand LoginCommand => new RelayCommand(() =>
        {
            MessageBox.Show("login shode");
        }, () =>
        {
            return string.IsNullOrEmpty(UserName) || string.IsNullOrEmpty(Password) ? false : true;
        });
        #endregion


        #region Method
        
        #endregion
    }
}
