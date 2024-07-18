using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Model.Model.Page
{
    public class MenuModel : BaseModel
    {
        private string _Title;
        public string Title
        {
            get { return _Title; }
            set
            {
                if (_Title == value)
                    return;
                _Title = value;
                RaisePropertyChanged("Title");
            }
        }

        private string _Icon;
        public string Icon
        {
            get { return _Icon; }
            set
            {
                if (_Icon == value)
                    return;
                _Icon = value;
                RaisePropertyChanged("Icon");
            }
        }

        private string _ViewPath;
        public string ViewPath
        {
            get { return _ViewPath; }
            set
            {
                if (_ViewPath == value)
                    return;
                _ViewPath = value;
                RaisePropertyChanged("ViewPath");
            }
        }

        private string _ViewModelPath;
        public string ViewModelPath
        {
            get { return _ViewModelPath; }
            set
            {
                if (_ViewModelPath == value)
                    return;
                _ViewModelPath = value;
                RaisePropertyChanged("ViewModelPath");
            }
        }
    }
}
