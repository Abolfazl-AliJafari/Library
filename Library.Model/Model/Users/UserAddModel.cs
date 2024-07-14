using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Model.Model.Users
{
    public class UserAddModel : BaseModel
    {
        public UserAddModel(
            string firstName,
            string lastName,
            string mobileNumer,
            string email,
            string userName,
            string passWord,
            bool isAdmin)
        {
            FirstName = firstName;
            LastName = lastName;
            MobileNumber = mobileNumer;
            Email = email;
            UserName = userName;
            PassWord = passWord;
            IsAdmin = isAdmin;
        }
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


        /// <summary>
        /// for detect admin users
        /// </summary>
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
