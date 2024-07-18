using GalaSoft.MvvmLight.Messaging;
using Library.Model.Model.Page;
using MaterialDesignThemes.Wpf;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

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

        }

        public Dictionary<string, Type> ViewModelDictionary { get; private set; }

        public object GetInstanceView(string viewName)
        {
            var t = Application.ResourceAssembly.GetTypes()?.FirstOrDefault(x => x.Name.StartsWith(viewName));
            return Activator.CreateInstance(t);
        }
        public object GetInstanceViewModel(string viewModel)
        {
            ViewModelDictionary.TryGetValue(viewModel, out Type t);
            return Activator.CreateInstance(t);
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
