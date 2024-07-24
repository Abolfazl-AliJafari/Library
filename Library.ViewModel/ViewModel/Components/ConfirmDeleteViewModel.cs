using GalaSoft.MvvmLight.Command;
using Library.DbService.Repositories;
using Library.Model.Enumerations;
using Library.Model.Helper;
using Library.Model.Model.Page;
using System.Windows;

namespace Library.ViewModel.ViewModel.Components
{
    public class ConfirmDeleteViewModel : BasePopupViewModel
    {
        #region Fields
        private readonly ModelType _type;
        private readonly int _id;
        private readonly object _repository;
        #endregion

        #region Constructor
        public ConfirmDeleteViewModel(DeleteModel model)
        {
            _type = model.Type;
            _id = model.Id;
            switch (_type)
            {
                case ModelType.User:
                    _repository = new UserRepository();
                    //Header = "آیا از حذف کاربر مطمعن هستید؟";
                    break;
                case ModelType.Book:
                    //Header = "آیا از حذف کتاب مطمعن هستید؟";
                    break;
                case ModelType.Bailment:
                    //Header = "آیا از حذف این مورد امانت مطمعن هستید؟";
                    break;
                default:
                    break;
            }
        }

        #endregion
        #region Properties
        //private string _header;
        //public string Header
        //{
        //    get { return _header; }
        //    set
        //    {
        //        if (_header == value)
        //            return;
        //        _header = value;
        //        RaisePropertyChanged("Header");
        //    }
        //}

        #endregion
        #region Commands
        public RelayCommand ConfirmCommand => new RelayCommand(() =>{
            Delete(_id);
        });
        #endregion

        #region Methods
        private void Delete(int id)
        {
            Result result = Result.Failure();
            switch (_type)
            {
                case ModelType.User:
                    result = (_repository as UserRepository).RemoveUser(id);
                    break;
                case ModelType.Book:
                    break;
                case ModelType.Bailment:
                    break;
                default:
                    break;
            }

            if (!result.IsSuccess)
            {
                MessageBox.Show(result.Message);
            }
        }
	    #endregion

    }
}
