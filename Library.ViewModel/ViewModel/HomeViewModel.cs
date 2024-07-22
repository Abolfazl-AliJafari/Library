using GalaSoft.MvvmLight.Messaging;
using Library.Model.Model.Users;
using Library.Model.StaticData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.ViewModel.ViewModel
{
    public class HomeViewModel : BaseViewModel
    {
        public HomeViewModel()
        {
            Messenger.Default.Register(this, "Logined", (bool isAdmin) =>
            {
                if (isAdmin)
                {
                    UserTypeSelectionindex = 0;
                }
                else
                {
                    UserTypeSelectionindex = 1;
                }
                Messenger.Default.Send(UserLoginedData.UserData, "LoginedUserData");
            });
        }

        #region Property
        private int _userTypeSelectionindex;

        public int UserTypeSelectionindex
        {
            get { return _userTypeSelectionindex; }
            set
            {
                if (_userTypeSelectionindex == value)
                    return;
                _userTypeSelectionindex = value;
                RaisePropertyChanged("UserTypeSelectionindex");
            }
        }

        #endregion
    }
}
