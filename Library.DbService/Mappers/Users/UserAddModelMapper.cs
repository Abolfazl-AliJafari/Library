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
    internal static class UserAddModelMapper
    {
        internal static ObservableCollection<UserAddModel> DataTableToModels(DataTable dataTable)
        {
            ObservableCollection<UserAddModel> users = new ObservableCollection<UserAddModel>();
            foreach (DataRow row in dataTable.Rows)
            {
                UserAddModel user = new UserAddModel(
                    row["FirstName"].ToString(),
                    row["LastName"].ToString(),
                    row["MobileNumber"].ToString(),
                    row["Email"].ToString(),
                    row["UserName"].ToString(),
                    row["PassWord"].ToString(),
                    (bool)(dataTable.Rows[0]["IsAdmin"] as bool?));
                users.Add(user);
            }
            return users;
        }

        internal static UserAddModel DataTableToModel(DataTable dataTable)
        {
            return new UserAddModel(
                dataTable.Rows[0]["FirstName"].ToString(),
                dataTable.Rows[0]["LastName"].ToString(),
                dataTable.Rows[0]["MobileNumber"].ToString(),
                dataTable.Rows[0]["Email"].ToString(),
                dataTable.Rows[0]["UserName"].ToString(),
                dataTable.Rows[0]["PassWord"].ToString(),
                (bool)(dataTable.Rows[0]["IsAdmin"] as bool?));

        }
    }
}
