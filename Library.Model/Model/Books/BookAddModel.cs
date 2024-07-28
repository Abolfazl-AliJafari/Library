namespace Library.Model.Model.Books
{
    public class BookAddModel : BaseModel
    {
        public BookAddModel(
           string bookCode,
           string bookName,
           string writerName,
           string printYear,
           int inventory)
        {
            BookCode = bookCode;
            BookName = bookName;
            WriterName = writerName;
            PrintYear = printYear;
            Inventory = inventory;
        }
        #region Properties

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


        #endregion


    }
}
