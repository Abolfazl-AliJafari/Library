
using GalaSoft.MvvmLight.CommandWpf;
using Library.DbService.Repositories;
using Library.Model.Interfaces.IRepositories;
using Library.Model.Model.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace Library.ViewModel.ViewModel.AdminUser.UserVeiwModels
{
    public class AddUserViewModel : BasePopupViewModel
    {
        private IUserRepository _userRepository;
        public AddUserViewModel()
        {
            _userRepository = new UserRepository();
        }

        #region Properties
        private string _firstName;

        public string FirstName
        {
            get { return _firstName; }
            set
            {
                if (_firstName == value)
                    return;
                _firstName = value;
                RaisePropertyChanged("FirstName");
            }
        }


        private string _lastName;

        public string LastName
        {
            get { return _lastName; }
            set
            {
                if (_lastName == value)
                    return;
                _lastName = value;
                RaisePropertyChanged("LastName");
            }
        }


        private string _mobileNumber;

        public string MobileNumber
        {
            get { return _mobileNumber; }
            set
            {
                if (_mobileNumber == value)
                    return;
                _mobileNumber = value;
                RaisePropertyChanged("MobileNumber");
            }
        }


        private string _email;

        public string Email
        {
            get { return _email; }
            set
            {
                if (_email == value)
                    return;
                _email = value;
                RaisePropertyChanged("Email");
            }
        }


        private string _userName;

        public string UserName
        {
            get { return _userName; }
            set
            {
                if (_userName == value)
                    return;
                _userName = value;
                RaisePropertyChanged("UserName");
            }
        }


        private string _password;

        public string Password
        {
            get { return _password; }
            set
            {
                if (_password == value)
                    return;
                _password = value;
                RaisePropertyChanged("Password");
            }
        }


        private bool _isAdmin;

        public bool IsAdmin
        {
            get { return _isAdmin; }
            set
            {
                if (_isAdmin == value)
                    return;
                _isAdmin = value;
                RaisePropertyChanged("IsAdmin");
            }
        }

        #endregion

        #region Commands
        public RelayCommand AddUserCommand => new RelayCommand(() =>
        {
            AddUser(new UserAddModel(
                FirstName,
                LastName,
                MobileNumber,
                Email,
                UserName,
                Password,
                IsAdmin));
        },() =>
        {
            return ValidateFeilds();
        });
        public RelayCommand<UserControl> CloseCommand => new RelayCommand<UserControl>(userControl =>
        {
            if (userControl != null)
            {
                Window.GetWindow(userControl).Close();
            }
        });
        #endregion


        #region Methods
        private void AddUser(UserAddModel user)
        {
            var result = _userRepository.AddUser(user);
            if(!result.Result.IsSuccess)
            {
                MessageBox.Show(result.Result.Message);
            }
            else
            {
                CloseCommand.Execute(this);
            }
        }

        private bool ValidateFeilds ()
        {
            if(string.IsNullOrEmpty(FirstName))
                return false;
            if (string.IsNullOrEmpty(LastName))
                return false;
            if (string.IsNullOrEmpty(MobileNumber))
                return false;
            if (string.IsNullOrEmpty(UserName))
                return false;
            if (string.IsNullOrEmpty(Password))
                return false;
            return true;
        }
        #endregion
    }
}
