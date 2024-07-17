using Library.Model.Model.Users;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.DbService.Mappers.Users
{
    internal static class UserLoginModelMapper
    {
        internal static ObservableCollection<UserLoginModel> DataTableToModels(DataTable dataTable)
        {
            ObservableCollection<UserLoginModel> users = new ObservableCollection<UserLoginModel>();
            foreach (DataRow row in dataTable.Rows)
            {
                string fullName = row["FirstName"].ToString() + row["LastName"].ToString();
                UserLoginModel user = new UserLoginModel(
                    fullName,
                    row["UserName"].ToString(),
                    row["PassWord"].ToString(),
                   (bool)(row["IsAdmin"] as bool?));
                users.Add(user);
            }
            return users;
        }

        internal static UserLoginModel DataTableToModel(DataTable dataTable)
        {
            string fullName = dataTable.Rows[0]["FirstName"].ToString() + dataTable.Rows[0]["LastName"].ToString();
            return new UserLoginModel(
                     fullName,
                      dataTable.Rows[0]["UserName"].ToString(),
                      dataTable.Rows[0]["PassWord"].ToString(),
                      (bool)(dataTable.Rows[0]["IsAdmin"] as bool?));
        }
    }
}
