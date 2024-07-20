using GalaSoft.MvvmLight.Messaging;
using Library.Model.Model.Page;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace Library.ViewModel.ViewModel
{
    public class AdminHomePageViewModel : BaseViewModel
    {
        public AdminHomePageViewModel()
        {
            FillMenu();
            Messenger.Default.Register(this, "ShowView", (Page page) =>
            {
                CurrentPage = page;
            });
        }

        #region Prop
        private bool _usersSelected;
        public bool UsersSelected
        {
            get { return _usersSelected; }
            set
            {
                if (_usersSelected == value)
                    return;
                _usersSelected = value;
                RaisePropertyChanged("UsersSelected");
            }
        }

        private bool _booksSelected;
        public bool BooksSelected
        {
            get { return _booksSelected; }
            set
            {
                if (_booksSelected == value)
                    return;
                _booksSelected = value;
                RaisePropertyChanged("BooksSelected");
            }
        }

        private bool _bailmentSelected;
        public bool BailmentSelected
        {
            get { return _bailmentSelected; }
            set
            {
                if (_bailmentSelected == value)
                    return;
                _bailmentSelected = value;
                RaisePropertyChanged("BailmentSelected");
            }
        }

        private List<MenuModel> _Menu;
        public List<MenuModel> Menu
        {
            get { return _Menu; }
            set
            {
                if (_Menu == value)
                    return;
                _Menu = value;
                RaisePropertyChanged("Menu");
            }
        }

        private int _MenuIndex = -1;
        public int MenuIndex
        {
            get { return _MenuIndex; }
            set
            {
                if (_MenuIndex == value)
                    return;
                _MenuIndex = value;
                RaisePropertyChanged("MenuIndex");
            }
        }

        private MenuModel _CurrentMenu;
        public MenuModel CurrentMenu
        {
            get { return _CurrentMenu; }
            set
            {
                if (_CurrentMenu == value)
                    return;
                _CurrentMenu = value;
                RaisePropertyChanged("CurrentMenu");
                if (value != null)
                {
                    OpenMenu(value);
                }
            }
        }

        private Page _CurrentPage;
        public Page CurrentPage
        {
            get { return _CurrentPage; }
            set
            {
                if (_CurrentPage == value)
                    return;
                _CurrentPage = value;
                RaisePropertyChanged("CurrentPage");
            }
        }
        #endregion

        #region Method
        private void FillMenu()
        {
            var menu = new List<MenuModel>()
            {
                new MenuModel()
                {
                    Title = "کاربران",
                    Icon = "AccountGroup",
                    ViewPath = "AdminUsersPage",
                    ViewModelPath = "AdminUserViewModel"
                },
                new MenuModel()
                {
                    Title = "کتاب ها",
                    Icon = "Book",
                    ViewPath = "AdminUsersPage",
                    ViewModelPath = "AdminBooksPage"
                },
                new MenuModel()
                {
                    Title = "امانت داری",
                    Icon = "BeakerOutline",
                    ViewPath = "AdminUsersPage",
                    ViewModelPath = "AdminUserViewModel"
                },
            };

            Menu = new List<MenuModel>(menu);
        }

        private void OpenMenu(MenuModel menu)
        {
            Messenger.Default.Send<MenuModel>(menu, "OpenView");
        }
        #endregion

    }
}
