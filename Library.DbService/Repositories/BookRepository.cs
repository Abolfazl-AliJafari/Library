using Library.DbService.Mappers.Books;
using Library.Model.Helper;
using Library.Model.Helper.Exceptions;
using Library.Model.Interfaces.IRepositories;
using Library.Model.Model.Books;
using System;
using System.Collections.ObjectModel;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace Library.DbService.Repositories
{
    public class BookRepository : IBookRepository
    {
        public Task<Result> AddBook(BookAddModel book)
        {
            try
            {
                using (SqlConnection sqlConnection = new SqlConnection(Properties.Settings.Default.SqlServerConnectionString))
                using (SqlCommand sqlCommand = new SqlCommand("AddBook", sqlConnection))
                {
                    sqlConnection.Open();

                    sqlCommand.CommandType = CommandType.StoredProcedure;

                    var BookCode = sqlCommand.Parameters.Add(new SqlParameter("@BookCode", book.BookCode));
                    BookCode.Size = 12;

                    var BookName = sqlCommand.Parameters.Add(new SqlParameter("@BookName", book.BookName));
                    BookName.Size = 100;


                    var WriterName = sqlCommand.Parameters.Add(new SqlParameter("@WriterName", book.WriterName));
                    WriterName.Size = 150;

                    var PrintYear = sqlCommand.Parameters.Add(new SqlParameter("@PrintYear", book.PrintYear));
                    PrintYear.Size = 4;

                    var Inventory = sqlCommand.Parameters.Add(new SqlParameter("@Inventory", book.Inventory));

                    sqlCommand.ExecuteNonQuery();
                }

                return Task.FromResult(Result.Success());
            }
            catch (Exception ex)
            {
                //ToDo : Implement Log Errors
                return Task.FromResult(Result.Failure(ExceptionMessages.SomethingWentWrong));
            }
        }

        public Result<ObservableCollection<BookShowModel>> GetAllBooks()
        {
            DataTable dataTable = new DataTable();
            try
            {
                using (SqlConnection sqlConnection = new SqlConnection(Properties.Settings.Default.SqlServerConnectionString))
                using (SqlCommand sqlCommand = new SqlCommand("GetAllBook", sqlConnection))
                {
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlConnection.Open();
                    dataTable.Load(sqlCommand.ExecuteReader());
                    return Result<ObservableCollection<BookShowModel>>.Success(BookShowModelMapper.DataTableToModels(dataTable));
                }
            }
            catch (Exception ex)
            {
                //ToDo : Implement Log Errors
                return Result<ObservableCollection<BookShowModel>>.Failure(ExceptionMessages.SomethingWentWrong, null);
            }
        }

        public Result<BookShowModel> GetBookByCode(string code)
        {
            DataTable dataTable = new DataTable();
            try
            {
                using (SqlConnection sqlConnection = new SqlConnection(Properties.Settings.Default.SqlServerConnectionString))
                using (SqlCommand sqlCommand = new SqlCommand("GetBookbyCode", sqlConnection))
                {
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    var BookCode = sqlCommand.Parameters.Add(new SqlParameter("@BookCode", code));

                    sqlConnection.Open();
                    dataTable.Load(sqlCommand.ExecuteReader());
                    return Result<BookShowModel>.Success(BookShowModelMapper.DataTableToModel(dataTable));
                }
            }
            catch (Exception ex)
            {
                //ToDo : Implement Log Errors
                return Result<BookShowModel>.Failure(ExceptionMessages.SomethingWentWrong, null);
            }
        }

        public Result<BookShowModel> GetBookById(int id)
        {
            DataTable dataTable = new DataTable();
            try
            {
                using (SqlConnection sqlConnection = new SqlConnection(Properties.Settings.Default.SqlServerConnectionString))
                using (SqlCommand sqlCommand = new SqlCommand("GetBookById", sqlConnection))
                {
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    var Id = sqlCommand.Parameters.Add(new SqlParameter("@VarId", id));

                    sqlConnection.Open();
                    dataTable.Load(sqlCommand.ExecuteReader());
                    return Result<BookShowModel>.Success(BookShowModelMapper.DataTableToModel(dataTable));
                }
            }
            catch (Exception ex)
            {
                //ToDo : Implement Log Errors
                return Result<BookShowModel>.Failure(ExceptionMessages.SomethingWentWrong, null);
            }
        }

        public Result RemoveBook(int id)
        {
            try
            {
                using (SqlConnection sqlConnection = new SqlConnection(Properties.Settings.Default.SqlServerConnectionString))
                using (SqlCommand sqlCommand = new SqlCommand("DeleteBook", sqlConnection))
                {
                    sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;
                    var Id = sqlCommand.Parameters.Add(new SqlParameter("@Id", id));
                    sqlConnection.Open();
                    sqlCommand.ExecuteReader();
                    return Result.Success();
                }
            }
            catch (Exception ex)
            {
                //ToDo : Implement Log Errors
                return Result.Failure(ExceptionMessages.SomethingWentWrong);
            }
        }

        public Result UpdateBook(BookUpdateModel book)
        {
            try
            {
                using (SqlConnection sqlConnection = new SqlConnection(Properties.Settings.Default.SqlServerConnectionString))
                using (SqlCommand sqlCommand = new SqlCommand("UpdateBook", sqlConnection))
                {
                    sqlConnection.Open();

                    sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;

                    var Id = sqlCommand.Parameters.Add(new SqlParameter("@Id", book.Id));

                    var BookCode = sqlCommand.Parameters.Add(new SqlParameter("@BookCode", book.BookCode));
                    BookCode.Size = 12;

                    var BookName = sqlCommand.Parameters.Add(new SqlParameter("@BookName", book.BookName));
                    BookName.Size = 100;
                    BookName.SqlDbType = SqlDbType.NVarChar;

                    var WriterName = sqlCommand.Parameters.Add(new SqlParameter("@WriterName", book.WriterName));
                    WriterName.Size = 150;

                    var PrintYear = sqlCommand.Parameters.Add(new SqlParameter("@PrintYear", book.PrintYear));
                    PrintYear.Size = 4;

                    var Inventory = sqlCommand.Parameters.Add(new SqlParameter("@Inventory", book.Inventory));

                    sqlCommand.ExecuteNonQuery();
                }

                return Result.Success();
            }
            catch (Exception ex)
            {
                //ToDo : Implement Log Errors
                return Result.Failure(ExceptionMessages.SomethingWentWrong);
            }
        }
    }
}
