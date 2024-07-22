using GalaSoft.MvvmLight.CommandWpf;
using GalaSoft.MvvmLight.Messaging;
using Library.DbService.Repositories;
using Library.Model.Interfaces.IRepositories;
using Library.Model.Model.Page;
using Library.Model.Model.Users;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Windows;

namespace Library.ViewModel.ViewModel
{
    public class AdminUserViewModel : BaseViewModel
    {
        private IUserRepository _userRepository;
        public AdminUserViewModel()
        {
            Messenger.Default.Register(this, "ShowPopup", (UserControl page) =>
            {
                CurrentPage = page;
                IsOpenPopup = true;
                //Messenger.Default.Send("OpenDialog");
            });
            _userRepository = new UserRepository();
            Users = GetAllUser();
        }

        #region Properties

        private ObservableCollection<UserShowModel> _users;
        public ObservableCollection<UserShowModel> Users
        {
            get { return _users; }
            set
            {
                if (_users == value)
                    return;
                _users = value;
                RaisePropertyChanged("Users");
            }
        }


        private UserControl _currentPage;
        public UserControl CurrentPage
        {
            get { return _currentPage; }
            set
            {
                if (_currentPage == value)
                    return;
                _currentPage = value;
                RaisePropertyChanged("CurrentPage");
            }
        }

        private bool _isOpenPopup;

        public bool IsOpenPopup
        {
            get { return _isOpenPopup; }
            set
            {
                if (_isOpenPopup == value)
                    return;
                _isOpenPopup = value;
                RaisePropertyChanged("IsOpenPopup");
            }
        }

        #endregion

        #region Commands
        public RelayCommand AddUserCommand => new RelayCommand(() =>
        {
            var popup = new PopupModel()
            {
                Title = "Add",
                ViewPath = "AddUserPage",
                ViewModelPath = "AddUserViewModel",
            };

            OpenPopup(popup);
        });
        public RelayCommand EditUserCommand => new RelayCommand(() =>
        {
            object model = new object();
            var popup = new PopupModel()
            {
                Title = "Add",
                ViewPath = "AddUserPage",
                ViewModelPath = "AddUserViewModel",
                Args = new[]
                {
                    model
                }
            };

            OpenPopup(popup);
        });

        #endregion
        #region Methods
        private ObservableCollection<UserShowModel> GetAllUser()
        {
            var result = _userRepository.GetAllUsers();
            if (result.IsSuccess)
            {
                return result.Data;
            }
            return new ObservableCollection<UserShowModel>();
        }


        #endregion
    }
}
