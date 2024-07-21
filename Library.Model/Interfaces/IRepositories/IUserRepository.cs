using Library.Model.Helper;
using Library.Model.Model.Users;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Model.Interfaces.IRepositories
{
    public interface IUserRepository
    {

        /// <summary>
        /// add new user
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        Task<Result> AddUser(UserAddModel user);
        /// <summary>
        /// remove a user
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<Result> RemoveUser(int  id);
        /// <summary>
        /// get collection of all user
        /// </summary>
        /// <returns></returns>
        Result<ObservableCollection<UserShowModel>> GetAllUsers();
        /// <summary>
        /// Get a user by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Result<UserAddModel> GetUserById(int id);
        /// <summary>
        /// login a user
        /// </summary>
        /// <param name="username"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        Result<bool> Login(string username, string password);

        /// <summary>
        /// get user data by username
        /// </summary>
        /// <param name="userName"></param>
        /// <returns></returns>
        Result<UserLoginModel> GetUserByUserName(string userName);
    }
}
