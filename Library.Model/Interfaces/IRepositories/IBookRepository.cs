using Library.Model.Helper;
using Library.Model.Model.Books;
using Library.Model.Model.Users;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Model.Interfaces.IRepositories
{
    public interface IBookRepository
    {
        /// <summary>
        /// add new book
        /// </summary>
        /// <param name="book"></param>
        /// <returns></returns>
        Task<Result> AddBook(BookAddModel book);
        /// <summary>
        /// remove a book
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Result RemoveBook(int id);
        /// <summary>
        /// get collection of all book
        /// </summary>
        /// <returns></returns>
        Result<ObservableCollection<BookShowModel>> GetAllBooks();
        /// <summary>
        /// Get a book by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Result<BookShowModel> GetBookById(int id);

        /// <summary>
        /// get book data by code
        /// </summary>
        /// <param name="code"></param>
        /// <returns></returns>
        Result<BookShowModel> GetBookByCode(string code);

        /// <summary>
        /// update book data
        /// </summary>
        /// <param name="book"></param>
        /// <returns></returns>
        Result UpdateBook(BookUpdateModel book);
    }
}
