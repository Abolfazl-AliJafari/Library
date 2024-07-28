using GalaSoft.MvvmLight.CommandWpf;
using Library.DbService.Repositories;
using Library.Model.Enumerations;
using Library.Model.Interfaces.IRepositories;
using Library.Model.Model.Books;
using Library.Model.Model.Page;
using Library.Model.Model.Users;
using System.Collections.ObjectModel;
using System.Windows;

namespace Library.ViewModel.ViewModel
{
    public class AdminBooksViewModel : BaseViewModel
    {
        private IBookRepository _bookRepository;
        public AdminBooksViewModel()
        {
            _bookRepository = new BookRepository();
            Books = GetAllBooks();
        }


        #region Properties
        private ObservableCollection<BookShowModel> _books;
        public ObservableCollection<BookShowModel> Books
        {
            get { return _books; }
            set
            {
                if (_books == value)
                    return;
                _books = value;
                RaisePropertyChanged("Books");
            }
        }

        private object _selectedValue;

        public object SelectedValue
        {
            get { return _selectedValue; }
            set
            {
                if (_selectedValue == value)
                    return;
                _selectedValue = value;
                RaisePropertyChanged("SelectedValue");
            }
        }
        #endregion


        #region Commands
        public RelayCommand AddBookCommand => new RelayCommand(() =>
        {
            var popup = new PopupModel()
            {
                Title = "Add",
                ViewPath = "AddBookPage",
                ViewModelPath = "AddBookViewModel",
            };

            OpenPopup(popup);
        });
        public RelayCommand DeleteBookCommand => new RelayCommand(() =>
        {
            BookShowModel castedValue = SelectedValue as BookShowModel;
            DeleteModel model = new DeleteModel(ModelType.Book, castedValue.Id);
            var popup = new PopupModel()
            {
                Title = "Delete",
                ViewPath = "ConfirmDeletePage",
                ViewModelPath = "ConfirmDeleteViewModel",
                Height = 250,
                Width = 450,
                Args = new[]
                {
                    model
                }
            };

            OpenPopup(popup);
        });
        public RelayCommand EditBookCommand => new RelayCommand(() =>
        {
            BookShowModel castedValue = SelectedValue as BookShowModel;
            BookUpdateModel model = new BookUpdateModel(
                castedValue.Id,
                castedValue.BookCode,
                castedValue.BookName,
                castedValue.WriterName,
                castedValue.PrintYear,
                castedValue.Inventory);
            var popup = new PopupModel()
            {
                Title = "Add",
                ViewPath = "AddBookPage",
                ViewModelPath = "AddBookViewModel",
                Args = new[]
                {
                    model
                }
            };

            OpenPopup(popup);
        });
        public RelayCommand RefreshCommand => new RelayCommand(() =>
        {
            Books = GetAllBooks();
        });
        public RelayCommand GetReportCommand => new RelayCommand(() =>
        {

        });
        #endregion

        #region Methods
        private ObservableCollection<BookShowModel> GetAllBooks()
        {
            var result = _bookRepository.GetAllBooks();
            if (!result.IsSuccess)
            {
                MessageBox.Show(result.Message);
            }
            return result.Data;
        }
        #endregion
    }
}
