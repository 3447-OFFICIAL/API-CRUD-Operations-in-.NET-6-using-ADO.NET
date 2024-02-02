using Assignment_1.Models;
using Microsoft.Data.SqlClient;

namespace Assignment_1.Data
{
    public class SqlDataAccess
    {
        public List<BookModel> LoadData(string sqlQuery, string connectionString)
        {
            List<BookModel> books = new List<BookModel>();
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(sqlQuery, conn);
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    BookModel book = new BookModel();
                    book.Id = Convert.ToInt32(reader["id"]);
                    book.Title = Convert.ToString(reader["title"]);
                    book.Author = Convert.ToString(reader["author"]);
                    book.Description = Convert.ToString(reader["description"]);

                    books.Add(book);
                }
                reader.Close();

                return books;
            }
        }

        public List<BookModel> LoadDataById(int id, string sqlQuery, string connectionString)
        {
            List<BookModel> books = new List<BookModel>();
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(sqlQuery, conn);
                cmd.Parameters.AddWithValue("@id", id);
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    BookModel book = new BookModel();
                    book.Id = Convert.ToInt32(reader["id"]);
                    book.Title = Convert.ToString(reader["title"]);
                    book.Author = Convert.ToString(reader["author"]);
                    book.Description = Convert.ToString(reader["description"]);

                    books.Add(book);
                }
                reader.Close();

                return books;
            }
        }

        public List<BookModel> PostNewBook(BookModel newBook, string sqlQuery, string connectionString)
        {
            List<BookModel> books = new List<BookModel>();

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(sqlQuery, conn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@title", newBook.Title);
                cmd.Parameters.AddWithValue("@author", newBook.Author);
                cmd.Parameters.AddWithValue("@description", newBook.Description);
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    BookModel book = new BookModel();
                    book.Id = Convert.ToInt32(reader["id"]);
                    book.Title = Convert.ToString(reader["title"]);
                    book.Author = Convert.ToString(reader["author"]);
                    book.Description = Convert.ToString(reader["description"]);

                    books.Add(book);
                }
                reader.Close();

                return books;
            }
        }
    }


}
