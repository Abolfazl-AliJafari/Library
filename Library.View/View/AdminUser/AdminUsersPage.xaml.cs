﻿using GalaSoft.MvvmLight.Messaging;
using MaterialDesignThemes.Wpf;
using System;
using System.Collections.Generic;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Library.View.View.AdminUser
{
    /// <summary>
    /// Interaction logic for AdminUsersPage.xaml
    /// </summary>
    public partial class AdminUsersPage : Page
    {
        public AdminUsersPage()
        {
            InitializeComponent();
            //Messenger.Default.Register(this, "OpenDialog", (UserControl page) =>
            //{
            //    DialogHost.ShowDialog(page);
            //});
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
