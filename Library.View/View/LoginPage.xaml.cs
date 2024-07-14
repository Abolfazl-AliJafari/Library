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
        public LoginPage()
        {
            InitializeComponent();
            Login();

            int x = 5;
            f(x);//call by value
            Debug.WriteLine(x);//5

            //person person = new person()
            //{
            //    name = "saeed"
            //};
            //setName(person);
            //Debug.WriteLine(person.name);//abc
        }

        async Task Login()
        {
            var res = await Library.DbService.Repositories.UserRepository.Login("admin", "123");

        }

        //out
        //ref
        //in

        void f(int x)//5
        {
            x++;//6
            Debug.WriteLine(x);//6
        }

        void setName(person _person)
        {
            _person.name = "abc";
        }
        public class person
        {
            public string name;
        }

    }
}
