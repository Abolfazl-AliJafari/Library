using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Model.Model.Page
{
    public class PageModel : BaseModel
    {
        public PageModel() { }
        #region Properties
        private string _title;

        public string Title
        {
            get { return _title; }
            set
            {
                if (_title == value)
                    return;
                _title = value;
                RaisePropertyChanged("Title");
            }
        }

        private string _viewPath;
        public string ViewPath
        {
            get { return _viewPath; }
            set
            {
                if (_viewPath == value)
                    return;
                _viewPath = value;
                RaisePropertyChanged("ViewPath");
            }
        }


        private string _viewModelPath;
        public string ViewModelPath
        {
            get { return _viewModelPath; }
            set
            {
                if (_viewModelPath == value)
                    return;
                _viewModelPath = value;
                RaisePropertyChanged("ViewModelPath");
            }
        }
        #endregion
    }

}
