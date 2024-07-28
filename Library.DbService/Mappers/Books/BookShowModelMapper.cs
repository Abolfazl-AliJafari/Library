using Library.Model.Model.Books;
using Library.Model.Model.Users;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.DbService.Mappers.Books
{
    internal class BookShowModelMapper
    {
        internal static ObservableCollection<BookShowModel> DataTableToModels(DataTable dataTable)
        {
            ObservableCollection<BookShowModel> books = new ObservableCollection<BookShowModel>();
            foreach (DataRow row in dataTable.Rows)
            {
                BookShowModel book = new BookShowModel(
                    int.Parse(row["Id"].ToString()),
                    row["BookCode"].ToString(),
                    row["BookName"].ToString(),
                    row["WriterName"].ToString(),
                    row["PrintYear"].ToString(),
                    int.Parse(row["Inventory"].ToString()));
                books.Add(book);
            }
            return books;
        }

        internal static BookShowModel DataTableToModel(DataTable dataTable)
        {
            return new BookShowModel(
                int.Parse(dataTable.Rows[0]["Id"].ToString()),
                dataTable.Rows[0]["BookCode"].ToString(),
                dataTable.Rows[0]["BookName"].ToString(),
                dataTable.Rows[0]["WriterName"].ToString(),
                dataTable.Rows[0]["PrintYear"].ToString(),
                int.Parse(dataTable.Rows[0]["Inventory"].ToString()));

        }
    }
}
