using Library.Model.Model.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Model.Interfaces.IRepositories
{
    public interface IUserRepository
    {
        Task AddUser(UserAddModel user);
        Task<bool> RemoveUser(int  id);
        Task<IObservable<UserAddModel>> GetAllUsers();
        Task<bool> Login(string username, string password);
    }
}
