using Library.Model.Helper;
using Library.Model.Interfaces.IRepositories;
using Library.Model.Model.Users;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.DbService.Repositories
{
    public class UserRepository : IUserRepository
    {
        public Task<Result> AddUser(UserAddModel user)
        {
            throw new NotImplementedException();
        }

        public Task<Result<ObservableCollection<UserAddModel>>> GetAllUsers()
        {
            throw new NotImplementedException();
        }

        public async Task<Result<UserLoginModel>> Login(string username, string password)
        {
                DataTable dataTable = new DataTable();
            try
            {
                using (SqlConnection sqlConnection = new SqlConnection(Properties.Settings.Default.SqlServerConnectionString))
                using (SqlCommand sqlCommand = new SqlCommand("Login", sqlConnection))
                {
                    sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@UserName", username));
                    sqlCommand.Parameters.Add(new SqlParameter("@UserName", password));
                    sqlConnection.Open();
                    dataTable.Load(sqlCommand.ExecuteReader());
                    
                }
                if(dataTable.Rows.Count == 1)
                {
                    UserLoginModel user = new UserLoginModel()
                    {
                        //Todo : map value to dto
                    };
                    return Result<UserLoginModel>.Success(user); 
                }
                return Result<UserLoginModel>.Failure(null);
            }
            catch (Exception)
            {
                return Result<UserLoginModel>.Failure("مشکلی پیش آمده لطفا با پشتیبانی تماس بگیرید",null);
            }
        }

        public Task<Result> RemoveUser(int id)
        {
            throw new NotImplementedException();
        }
    }
}
