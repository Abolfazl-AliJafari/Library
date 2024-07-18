using Library.Model.Model.Users;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.ViewModel.ViewModel
{
    public class AdminUserViewModel : BaseViewModel
    {
        public AdminUserViewModel()
        {
            
        }
        private ObservableCollection<UserAddModel> _users;

        public ObservableCollection<UserAddModel> Users
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

    }
}
