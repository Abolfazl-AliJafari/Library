using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Model.Model.Users
{
    public class UserUpdateModel : BaseModel
    {
        #region Contstructor

        #endregion
        public UserUpdateModel()
        {
                
        }

        public UserUpdateModel(
            int id,
            string firstname,
            string lastname,
            string mobilenumber,
            string email,
            string username,
            string password,
            bool isadmin)
        {
            Id = id;
            FirstName = firstname;
            LastName = lastname;
            MobileNumber = mobilenumber;
            Email = email;
            UserName = username;
            Password = password;
            IsAdmin = isadmin;
        }
        #region Properties
        private int _id;

        public int Id
        {
            get { return _id; }
            set
            {
                if (_id == value)
                    return;
                _id = value;
                RaisePropertyChanged("Id");
            }
        }


        private string _firstName;

        public string FirstName
        {
            get { return _firstName;}
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
    }
}
