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
    internal class UserShowModelMapper
    {
        internal static ObservableCollection<UserShowModel> DataTableToModels(DataTable dataTable)
        {
            ObservableCollection<UserShowModel> users = new ObservableCollection<UserShowModel>();
            foreach (DataRow row in dataTable.Rows)
            {
                UserShowModel user = new UserShowModel(
                    int.Parse(row["Id"].ToString()),
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

        internal static UserShowModel DataTableToModel(DataTable dataTable)
        {
            return new UserShowModel(
                int.Parse(dataTable.Rows[0]["Id"].ToString()),
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
