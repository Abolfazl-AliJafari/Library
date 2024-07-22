using GalaSoft.MvvmLight.Messaging;
using Library.Model.Model.Page;
using Library.View.View.AdminUser;
using MahApps.Metro.Controls;
using MaterialDesignThemes.Wpf;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Automation.Peers;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Effects;

namespace Library.View
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public App()
        {
            GetAllViewModels(typeof(Library.ViewModel.ViewModel.MainViewModel).Assembly);

            Messenger.Default.Register(this, "OpenView", (MenuModel menuModel) =>
            {
                var viewModel = GetInstanceViewModel(menuModel.ViewModelPath);
                var view = GetInstanceView(menuModel.ViewPath);

                (view as Page).DataContext = viewModel;

                Messenger.Default.Send<Page>(view as Page, "ShowView");
            });

            Messenger.Default.Register(this, "OpenPopup", (PopupModel Popup) =>
            {
                var viewModel = GetInstanceViewModel(Popup.ViewModelPath);
                var view = GetInstanceView(Popup.ViewPath);

                (view as UserControl).DataContext = viewModel;

                MetroWindow window = new MetroWindow();
                window.Content = view;
                window.Topmost = true;
                window.Height = Popup.Height;
                window.Width = Popup.Width;
                window.SaveWindowPosition = true;
                window.HorizontalAlignment = HorizontalAlignment.Center;
                window.VerticalAlignment = VerticalAlignment.Center;
                window.WindowStartupLocation = WindowStartupLocation.CenterScreen;
                window.ResizeMode = ResizeMode.NoResize;
                window.ShowCloseButton = false;
                window.WindowStyle = WindowStyle.None;
                window.IsWindowDraggable = false;
                window.TitleBarHeight = 0;
                window.AllowsTransparency = true;

                window.ShowDialog();
            });

            Messenger.Default.Register(this, "OpenHome", (PageModel page) =>
            {
                var viewModel = GetInstanceViewModel(page.ViewModelPath);
                var view = GetInstanceView(page.ViewPath);

                (view as Window).DataContext = viewModel;
                (view as Window).ShowDialog();
            });
        }

        public Dictionary<string, Type> ViewModelDictionary { get; private set; }

        public object GetInstanceView(string viewName)
        {
            var t = Application.ResourceAssembly.GetTypes()?.FirstOrDefault(x => x.Name.StartsWith(viewName));
            return Activator.CreateInstance(t);
        }
        public object GetInstanceViewModel(string viewModel, params object[] args)
        {
            ViewModelDictionary.TryGetValue(viewModel, out Type t);
            return Activator.CreateInstance(t, args);
        }

        private void GetAllViewModels(object asm)
        {
            try
            {
                var assembly = asm as Assembly;
                ViewModelDictionary = new Dictionary<string, Type>();
                foreach (var type in assembly?.GetTypes()?.Where(x => x.IsClass && x.Name.EndsWith("ViewModel")).ToList())
                {
                    if (ViewModelDictionary.ContainsKey(type.Name))
                        continue;
                    ViewModelDictionary.Add(type.Name, type);
                }
            }
            catch (Exception ex)
            {
            }
        }


    }
}
