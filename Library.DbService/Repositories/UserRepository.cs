using Library.Model.Helper;
using Library.Model.Helper.Exceptions;
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
        private ObservableCollection<UserAddModel> _users;
        public UserRepository() { _users = new ObservableCollection<UserAddModel>(); }
        public Task<Result> AddUser(UserAddModel user)
        {
            throw new NotImplementedException();
        }

        public Task<Result<ObservableCollection<UserAddModel>>> GetAllUsers()
        {

            DataTable dataTable = new DataTable();
            try
            {
                using (SqlConnection sqlConnection = new SqlConnection(Properties.Settings.Default.SqlServerConnectionString))
                using (SqlCommand sqlCommand = new SqlCommand("GetAllUser", sqlConnection))
                {
                    sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;
                    sqlConnection.Open();
                    dataTable.Load(sqlCommand.ExecuteReader());
                    return Task.FromResult(Result<ObservableCollection<UserAddModel>>.Success(DataTableToObservable(dataTable)));
                }
            }
            catch (Exception ex)
            {
                //ToDo : Implement Log Errors
                return Task.FromResult(Result<ObservableCollection<UserAddModel>>.Failure(ExceptionMessages.SomethingWentWrong, null));
            }
        }

        /// <summary>
        /// Map DataTable to observable collection
        /// </summary>
        /// <param name="dataTable"></param>
        /// <returns></returns>
        private ObservableCollection<UserAddModel> DataTableToObservable(DataTable dataTable)
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

        public Task<Result<UserAddModel>> GetUserById(int id)
        {
            throw new NotImplementedException();
        }

        public static Task<Result<UserLoginModel>> Login(string username, string password)
        {
            DataTable dataTable = new DataTable();
            try
            {
                string errorMes = "";

                using (SqlConnection sqlConnection = new SqlConnection(Properties.Settings.Default.SqlServerConnectionString))
                using (SqlCommand sqlCommand = new SqlCommand("Login", sqlConnection))
                {
                    sqlConnection.Open();

                    sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;

                    var UserName = sqlCommand.Parameters.Add(new SqlParameter("@VarUserName", username));
                    UserName.Size = 30;

                    var VarPassW = sqlCommand.Parameters.Add(new SqlParameter("@VarPassWord", password));
                    VarPassW.Size = 30;

                    var errorMesParam = sqlCommand.Parameters.Add(new SqlParameter("@errorMes", ""));
                    errorMesParam.SqlDbType = SqlDbType.NVarChar;
                    errorMesParam.Size = 1001;
                    errorMesParam.Direction = System.Data.ParameterDirection.Output;

                    var returnParameter = sqlCommand.Parameters.Add("@ReturnVal", SqlDbType.Int);
                    returnParameter.Direction = ParameterDirection.ReturnValue;


                    sqlCommand.ExecuteNonQuery();

                    var ret = sqlCommand.Parameters["@ReturnVal"].Value.ToString();
                    errorMes = sqlCommand.Parameters["@errorMes"].Value.ToString();

                }


                if (dataTable.Rows.Count == 1)
                {
                    UserLoginModel user = new UserLoginModel(
                       dataTable.Rows[0]["UserName"].ToString(),
                       dataTable.Rows[0]["PassWord"].ToString(),
                       (bool)(dataTable.Rows[0]["IsAdmin"] as bool?));
                    return Task.FromResult(Result<UserLoginModel>.Success(user));
                }
                return Task.FromResult(Result<UserLoginModel>.Failure(null));
            }
            catch (Exception ex)
            {
                //ToDo : Implement Log Errors
                return Task.FromResult(Result<UserLoginModel>.Failure(ExceptionMessages.SomethingWentWrong, null));
            }
        }

        public Task<Result> RemoveUser(int id)
        {
            throw new NotImplementedException();
        }
    }
}
