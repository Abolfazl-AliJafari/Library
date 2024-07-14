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
        Task<Result<ObservableCollection<UserAddModel>>> GetAllUsers();
        /// <summary>
        /// Get a user by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<Result<UserAddModel>> GetUserById(int id);
        /// <summary>
        /// login a user
        /// </summary>
        /// <param name="username"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        Task<Result<UserLoginModel>> Login(string username, string password);
    }
}
