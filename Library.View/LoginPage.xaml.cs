using Library.DbService.Repositories;
using Library.Model.Interfaces.IRepositories;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Library.View.View
{
    /// <summary>
    /// Interaction logic for LoginPage.xaml
    /// </summary>
    public partial class LoginPage : Window
    {
        private IUserRepository _userRepository;
        public LoginPage()
        {
            InitializeComponent();
            _userRepository = new UserRepository();
        }

        private async Task<bool> Login(string username , string password)
        {
            var result = await _userRepository.Login("admin", "123");
            return result.Data;

        }

        //out
        //ref
        //in
    }
}
