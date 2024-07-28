using Library.DbService.Mappers.Users;
using Library.Model.Helper;
using Library.Model.Helper.Exceptions;
using Library.Model.Interfaces.IRepositories;
using Library.Model.Model.Users;
using System;
using System.Collections.ObjectModel;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace Library.DbService.Repositories
{
    public class UserRepository : IUserRepository
    {
        public UserRepository() { }
        public Task<Result> AddUser(UserAddModel user)
        {
            try
            {
                using (SqlConnection sqlConnection = new SqlConnection(Properties.Settings.Default.SqlServerConnectionString))
                using (SqlCommand sqlCommand = new SqlCommand("AddUser", sqlConnection))
                {
                    sqlConnection.Open();

                    sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;

                    var FirstName = sqlCommand.Parameters.Add(new SqlParameter("@FirstName", user.FirstName));
                    FirstName.Size = 40;

                    var LastName = sqlCommand.Parameters.Add(new SqlParameter("@LastName", user.LastName));
                    LastName.Size = 70;


                    var MobileNumber = sqlCommand.Parameters.Add(new SqlParameter("@MobileNumber", user.MobileNumber));
                    MobileNumber.Size = 11;

                    var EmailAddress = sqlCommand.Parameters.Add(new SqlParameter("@EmailAddress", user.Email));
                    EmailAddress.Size = 150;

                    var UserName = sqlCommand.Parameters.Add(new SqlParameter("@UserName", user.UserName));
                    UserName.Size = 30;

                    var PassWord = sqlCommand.Parameters.Add(new SqlParameter("@PassWord", user.PassWord));
                    PassWord.Size = 16;
                    var IsAdmin = sqlCommand.Parameters.Add(new SqlParameter("@IsAdmin", user.IsAdmin));
                    IsAdmin.SqlDbType = SqlDbType.Bit;
                    sqlCommand.ExecuteNonQuery();
                }

                return Task.FromResult(Result.Success());
            }
            catch (Exception ex)
            {
                //ToDo : Implement Log Errors
                return Task.FromResult(Result.Failure(ExceptionMessages.SomethingWentWrong));
            }
        }

        public Result<ObservableCollection<UserShowModel>> GetAllUsers()
        {
            DataTable dataTable = new DataTable();
            try
            {
                using (SqlConnection sqlConnection = new SqlConnection(Properties.Settings.Default.SqlServerConnectionString))
                using (SqlCommand sqlCommand = new SqlCommand("GetAllUser", sqlConnection))
                {
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlConnection.Open();
                    dataTable.Load(sqlCommand.ExecuteReader());
                    return Result<ObservableCollection<UserShowModel>>.Success(UserShowModelMapper.DataTableToModels(dataTable));
                }
            }
            catch (Exception ex)
            {
                //ToDo : Implement Log Errors
                return Result<ObservableCollection<UserShowModel>>.Failure(ExceptionMessages.SomethingWentWrong, null);
            }
        }

        public Result<UserAddModel> GetUserById(int id)
        {
            DataTable dataTable = new DataTable();
            try
            {
                using (SqlConnection sqlConnection = new SqlConnection(Properties.Settings.Default.SqlServerConnectionString))
                using (SqlCommand sqlCommand = new SqlCommand("GetUserById", sqlConnection))
                {
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    var Id = sqlCommand.Parameters.Add(new SqlParameter("@VarId", id));

                    sqlConnection.Open();
                    dataTable.Load(sqlCommand.ExecuteReader());
                    return Result<UserAddModel>.Success(UserAddModelMapper.DataTableToModel(dataTable));
                }
            }
            catch (Exception ex)
            {
                //ToDo : Implement Log Errors
                return Result<UserAddModel>.Failure(ExceptionMessages.SomethingWentWrong, null);
            }
        }

        public Result<UserLoginModel> GetUserByUserName(string username)
        {
            DataTable dataTable = new DataTable();
            try
            {
                using (SqlConnection sqlConnection = new SqlConnection(Properties.Settings.Default.SqlServerConnectionString))
                using (SqlCommand sqlCommand = new SqlCommand("GetUserByUserName", sqlConnection))
                {
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    var UserName = sqlCommand.Parameters.Add(new SqlParameter("@VarUserName", username));

                    sqlConnection.Open();
                    dataTable.Load(sqlCommand.ExecuteReader());
                    return Result<UserLoginModel>.Success(UserLoginModelMapper.DataTableToModel(dataTable));
                }
            }
            catch (Exception ex)
            {
                //ToDo : Implement Log Errors
                return Result<UserLoginModel>.Failure(ExceptionMessages.SomethingWentWrong, null);
            }
        }

        public Result<bool> Login(string username, string password)
        {
            try
            {
                string errorMessage = "";
                var returnValue = "";
                using (SqlConnection sqlConnection = new SqlConnection(Properties.Settings.Default.SqlServerConnectionString))
                using (SqlCommand sqlCommand = new SqlCommand("Login", sqlConnection))
                {
                    sqlConnection.Open();

                    sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;

                    var UserName = sqlCommand.Parameters.Add(new SqlParameter("@VarUserName", username));
                    UserName.Size = 30;

                    var VarPassW = sqlCommand.Parameters.Add(new SqlParameter("@VarPassWord", password));
                    VarPassW.Size = 30;

                    var errorMesParam = sqlCommand.Parameters.Add(new SqlParameter("@ErrorMes", ""));
                    errorMesParam.SqlDbType = SqlDbType.NVarChar;
                    errorMesParam.Size = 1001;
                    errorMesParam.Direction = ParameterDirection.Output;

                    var returnParameter = sqlCommand.Parameters.Add("@ReturnVal", SqlDbType.Int);
                    returnParameter.Direction = ParameterDirection.ReturnValue;


                    sqlCommand.ExecuteNonQuery();

                    returnValue = sqlCommand.Parameters["@ReturnVal"].Value.ToString();
                    errorMessage = sqlCommand.Parameters["@ErrorMes"].Value.ToString();

                }


                if (returnValue == "1")
                {

                    return Result<bool>.Success(true);
                }
                return Result<bool>.Failure(false);
            }
            catch (Exception ex)
            {
                //ToDo : Implement Log Errors
                return Result<bool>.Failure(ExceptionMessages.SomethingWentWrong, false);
            }
        }

        public Result RemoveUser(int id)
        {
            try
            {
                using (SqlConnection sqlConnection = new SqlConnection(Properties.Settings.Default.SqlServerConnectionString))
                using (SqlCommand sqlCommand = new SqlCommand("DeleteUser", sqlConnection))
                {
                    sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;
                    var Id = sqlCommand.Parameters.Add(new SqlParameter("@VarUserId", id));
                    sqlConnection.Open();
                    sqlCommand.ExecuteReader();
                    return Result.Success();
                }
            }
            catch (Exception ex)
            {
                //ToDo : Implement Log Errors
                return Result.Failure(ExceptionMessages.SomethingWentWrong);
            }
        }

        public Result UpdateUser(UserUpdateModel user)
        {
            try
            {
                using (SqlConnection sqlConnection = new SqlConnection(Properties.Settings.Default.SqlServerConnectionString))
                using (SqlCommand sqlCommand = new SqlCommand("UpdateUser", sqlConnection))
                {
                    sqlConnection.Open();

                    sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;

                    var Id = sqlCommand.Parameters.Add(new SqlParameter("@Id", user.Id));

                    var FirstName = sqlCommand.Parameters.Add(new SqlParameter("@FirstName", user.FirstName));
                    FirstName.Size = 40;

                    var LastName = sqlCommand.Parameters.Add(new SqlParameter("@LastName", user.LastName));
                    LastName.Size = 70;


                    var MobileNumber = sqlCommand.Parameters.Add(new SqlParameter("@MobileNumber", user.MobileNumber));
                    MobileNumber.Size = 11;

                    var EmailAddress = sqlCommand.Parameters.Add(new SqlParameter("@EmailAddress", user.Email));
                    EmailAddress.Size = 150;

                    var UserName = sqlCommand.Parameters.Add(new SqlParameter("@UserName", user.UserName));
                    UserName.Size = 30;

                    var PassWord = sqlCommand.Parameters.Add(new SqlParameter("@PassWord", user.Password));
                    PassWord.Size = 16;
                    var IsAdmin = sqlCommand.Parameters.Add(new SqlParameter("@IsAdmin", user.IsAdmin));
                    IsAdmin.SqlDbType = SqlDbType.Bit;
                    sqlCommand.ExecuteNonQuery();
                }

                return Result.Success();
            }
            catch (Exception ex)
            {
                //ToDo : Implement Log Errors
                return Result.Failure(ExceptionMessages.SomethingWentWrong);
            }
        }
    }
}
