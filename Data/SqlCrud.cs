using assignment_1.Models;

namespace assignment_1.Data
{
    public class SqlCrud
    {
        private readonly string _connectionString;
        SqlDataAccess sqlDataAccess = new SqlDataAccess();

        public SqlCrud(string connectionString)
        {
            _connectionString = connectionString;
        }

        public List<BookModel> GetAllBooks()
        {
            string sqlString = "select Id, Title, Author, Description from dbo.Books order by Id";

            return sqlDataAccess.LoadData(sqlString, _connectionString);
        }

        public List<BookModel> GetBookById(int id)
        {
            string sqlString = "select Id, Title, Author, Description from dbo.Books where id = @id";

            return sqlDataAccess.LoadDataById(id, sqlString, _connectionString);
        }

        public async Task<List<BookModel>> PostNewBook(BookModel newBook)
        {
            string sqlProcedure = "InsertNewBook";

            return await Task.FromResult(sqlDataAccess.PostNewBook(newBook, sqlProcedure, _connectionString));
        }
    }

}
