using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Model.Model.Users
{
    public class UserLoginModel : BaseModel
    {
        public UserLoginModel(
            string userName,
            string passWord,
            bool isAdmin)
        {
            UserName = userName;
            PassWord = passWord;
            IsAdmin = isAdmin;
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
        private string _passWord;

        public string PassWord
        {
            get { return _passWord; }
            set
            {
                if (_passWord == value)
                    return;
                _passWord = value;
                RaisePropertyChanged("PassWord");
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

    }
}
