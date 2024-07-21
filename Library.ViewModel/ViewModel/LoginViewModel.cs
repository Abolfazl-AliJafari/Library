using GalaSoft.MvvmLight.CommandWpf;
using GalaSoft.MvvmLight.Messaging;
using Library.DbService.Repositories;
using Library.Model.Interfaces.IRepositories;
using Library.Model.Model.Page;
using Library.Model.Model.Users;
using Library.Model.StaticData;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls.Primitives;

namespace Library.ViewModel.ViewModel
{
    public class LoginViewModel : BaseViewModel
    {
        private IniHelper iniHelper;
        private readonly IUserRepository _userRepository;
        public LoginViewModel()
        {
            _userRepository = new UserRepository();
            iniHelper = new IniHelper(System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "config.ini"));

            var userName = iniHelper.Read(Environment.MachineName, "LastLogin");
            if (!string.IsNullOrEmpty(userName))
            {
                UserName = userName;
            }
        }

        #region Property
        private string _UserName;
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

        private string _Password;
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
            Login(UserName, Password);
        });

        //}, () =>
        //{
        //    return string.IsNullOrEmpty(UserName) || string.IsNullOrEmpty(Password) ? false : true;
        //});
        #endregion


        #region Method
        private void Login(string username, string password)
        {
            var result = _userRepository.Login(username, password);
            if (result.IsSuccess)
            {
                iniHelper.Write(Environment.MachineName, username, "LastLogin");

                Password = "";

                FillUserLoginData(username);
                if (UserLoginedData.UserData.IsAdmin)
                {
                    Messenger.Default.Send(UserLoginedData.UserData, "Login");
                }
                else
                {

                }
            }
            else
            {
                MessageBox.Show(result.Message);
            }
        }

        private void FillUserLoginData(string username)
        {
            var result = _userRepository.GetUserByUserName(username);
            if (!result.IsSuccess)
            {
                MessageBox.Show(result.Message);
            }
            UserLoginedData.UserData = result.Data;

        }




        #endregion
    }

    public class IniHelper
    {
        private readonly string Path;

        public IniHelper(string path)
        {
            Path = path;
        }

        [DllImport("kernel32", CharSet = CharSet.Unicode)]
        private static extern long WritePrivateProfileString(string Section, string Key, string Value, string FilePath);

        [DllImport("kernel32", CharSet = CharSet.Unicode)]
        private static extern int GetPrivateProfileString(string Section, string Key, string Default, StringBuilder RetVal, int Size, string FilePath);

        public string Read(string Key, string Section = null)
        {
            StringBuilder stringBuilder = new StringBuilder(255);
            GetPrivateProfileString(Section, Key, "", stringBuilder, 255, Path);
            return stringBuilder.ToString();
        }

        public void Write(string Key, string Value, string Section = null)
        {
            WritePrivateProfileString(Section, Key, Value, Path);
        }
    }

}
