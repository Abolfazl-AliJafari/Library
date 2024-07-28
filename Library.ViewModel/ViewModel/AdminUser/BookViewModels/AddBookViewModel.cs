using GalaSoft.MvvmLight.CommandWpf;
using Library.DbService.Repositories;
using Library.Model.Helper.Exceptions;
using Library.Model.Interfaces.IRepositories;
using Library.Model.Model.Books;
using System.Windows;

namespace Library.ViewModel.ViewModel.AdminUser.BookViewModels
{
    public class AddBookViewModel : BasePopupViewModel
    {
        private IBookRepository _bookRepository;
        public AddBookViewModel()
        {
            _bookRepository = new BookRepository();
            IsInsert = true;
            IsEdit = false;
        }

        public AddBookViewModel(BookUpdateModel book)
        {
            _bookRepository = new BookRepository();
            _id = book.Id;
            BookName = book.BookName;
            BookCode = book.BookCode;
            WriterName = book.WriterName;
            PrintYear = book.PrintYear;
            Inventory = book.Inventory;
            IsEdit = true;
            IsInsert = false;
        }

        #region Properties
        private int _id;
        private string _bookName;

        public string BookName
        {
            get { return _bookName; }
            set
            {
                if (_bookName == value)
                    return;
                _bookName = value;
                RaisePropertyChanged("BookName");
            }
        }


        private string _bookCode;

        public string BookCode
        {
            get { return _bookCode; }
            set
            {
                if (_bookCode == value)
                    return;
                _bookCode = value;
                RaisePropertyChanged("BookCode");
            }
        }


        private string _writerName;

        public string WriterName
        {
            get { return _writerName; }
            set
            {
                if (_writerName == value)
                    return;
                _writerName = value;
                RaisePropertyChanged("WriterName");
            }
        }


        private string _printYear;

        public string PrintYear
        {
            get { return _printYear; }
            set
            {
                if (_printYear == value)
                    return;
                _printYear = value;
                RaisePropertyChanged("PrintYear");
            }
        }


        private int _inventory;

        public int Inventory
        {
            get { return _inventory; }
            set
            {
                if (_inventory == value)
                    return;
                _inventory = value;
                RaisePropertyChanged("Inventory");
            }
        }
        private bool _isInsert;

        public bool IsInsert
        {
            get { return _isInsert; }
            set
            {
                if (_isInsert == value)
                    return;
                _isInsert = value;
                RaisePropertyChanged("IsInsert");
            }
        }

        private bool _isEdit;

        public bool IsEdit
        {
            get { return _isEdit; }
            set
            {
                if (_isEdit == value)
                    return;
                _isEdit = value;
                RaisePropertyChanged("IsEdit");
            }
        }

        #endregion
        #region Commands
        public RelayCommand AddBookCommand => new RelayCommand(() =>
        {
            AddBook(new BookAddModel(
                BookName,
                BookCode,
                WriterName,
                PrintYear,
                Inventory));
        }, () =>
        {
            return ValidateFeilds();
        });
        public RelayCommand EditBookCommand => new RelayCommand(() =>
        {
            UpdateBook(new BookUpdateModel(
                _id,
                BookCode,
                BookName,
                WriterName,
                PrintYear,
                Inventory));
        }, () =>
        {
            return ValidateFeilds();
        });
        #endregion


        #region Methods
        private void AddBook(BookAddModel book)
        {
            var result = _bookRepository.AddBook(book);
            if (!result.Result.IsSuccess)
            {
                MessageBox.Show(result.Result.Message);
            }
            else
            {
                MessageBox.Show(ExceptionMessages.InsertSuccess(" کتاب"));
            }
        }

        private void UpdateBook(BookUpdateModel book)
        {
            var result = _bookRepository.UpdateBook(book);
            if (!result.IsSuccess)
            {
                MessageBox.Show(result.Message);
            }
            else
            {
                MessageBox.Show(ExceptionMessages.UpdateSuccess("کتاب "));
            }
        }

        private bool ValidateFeilds()
        {
            if (string.IsNullOrEmpty(BookName))
                return false;
            if (string.IsNullOrEmpty(BookCode))
                return false;
            if (string.IsNullOrEmpty(WriterName))
                return false;
            if (string.IsNullOrEmpty(PrintYear))
                return false;
            if (string.IsNullOrEmpty(Inventory.ToString()))
                return false;
            return true;
        }
        #endregion
    }
}
