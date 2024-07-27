using GalaSoft.MvvmLight.CommandWpf;
using GalaSoft.MvvmLight.Messaging;
using Library.DbService.Repositories;
using Library.Model.Enumerations;
using Library.Model.Interfaces.IRepositories;
using Library.Model.Model.Page;
using Library.Model.Model.Users;
using Library.ViewModel.Helpers;
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

        private object _selectedValue;

        public object SelectedValue
        {
            get { return _selectedValue; }
            set
            {
                if (_selectedValue == value)
                    return;
                _selectedValue = value;
                RaisePropertyChanged("SelectedValue");
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
            UserShowModel castedValue = SelectedValue as UserShowModel;
            UserUpdateModel model = new UserUpdateModel(
                castedValue.Id,
                castedValue.FirstName,
                castedValue.LastName,
                castedValue.MobileNumber,
                castedValue.Email,
                castedValue.UserName,
                castedValue.PassWord,
                castedValue.IsAdmin);
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
        public RelayCommand DeleteUserCommand => new RelayCommand(() =>
        {
            UserShowModel castedValue = SelectedValue as UserShowModel;
            DeleteModel model = new DeleteModel(ModelType.User, castedValue.Id);
            var popup = new PopupModel()
            {
                Title = "Delete",
                ViewPath = "ConfirmDeletePage",
                ViewModelPath = "ConfirmDeleteViewModel",
                Height = 250,
                Width = 450,
                Args = new[]
                {
                    model
                }
            };

            OpenPopup(popup);
        });


        public RelayCommand RefreshCommand => new RelayCommand(() =>
        {
            Users = GetAllUser();
        });


        public RelayCommand GetReportCommand => new RelayCommand(() =>
        {
            GetReport();
        });
        #endregion
        #region Methods
        private ObservableCollection<UserShowModel> GetAllUser()
        {
            var result = _userRepository.GetAllUsers();
            if (!result.IsSuccess)
            {
                MessageBox.Show(result.Message);
                return new ObservableCollection<UserShowModel>();

            }
            return result.Data;
        }

        private void GetReport()
        {
            var users = GetAllUser();
            var rpt = StimulsoftHelper.GetReport("Report.mrt");
            rpt.RegData("User_Tbl", users.Select(p => new
            {
                p.FirstName,
                p.LastName,
                p.MobileNumber,
                p.UserName,
                p.IsAdmin
            }));
            rpt.Show();

        }
        #endregion
    }
}
