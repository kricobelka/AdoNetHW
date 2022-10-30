using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;
using System.Data;

namespace AdoNetHW
{
    internal class AdoNetHwExample
    {
        readonly string connectionString = "Server=localhost;Database=AdoNetHW;Trusted_Connection=True;Encrypt=False";

        public async Task GetBooks()
        {
            using (var sqlConnection = new SqlConnection(connectionString))
            {
                await sqlConnection.OpenAsync();

                var getUsersSql = "select * from Books";

                //SqlCommand  класс инкапсулирует sql-выражение, которое должно быть выполнено.
                var sqlCommand = new SqlCommand(getUsersSql, sqlConnection);

                var dataReader = await sqlCommand.ExecuteReaderAsync();

                while (await dataReader.ReadAsync())
                {
                    var bookId = dataReader.GetFieldValue<int>("BookId");
                    var name = dataReader.GetFieldValue<string>("Name");
                    var publishDate = dataReader.GetFieldValue<DateTime>("PublishDate");
                    var author = dataReader.GetFieldValue<string>("Author");

                    Console.WriteLine($"Books from database AdoNetHw: " +
                        $"{bookId}: {name} {publishDate} {author}.");
                }
            }
        }

        //3. Создайте метод, который будет принимать информацию о книге
        //    (Name, PublishDate, Author) и добавлять её в виде записи в БД.
        public async Task AddBookInfo(string name, DateTime publishDate, string author)
        {
            //var connectionString = "Server=localhost;Database=AdoNetHW;Trusted_Connection=True;Encrypt=False";
            string expression = $"INSERT INTO Books (Name, PublishDate, Author) VALUES ('{name}', '{publishDate}', '{author}')";

            using (var sqlConnection = new SqlConnection(connectionString))
            {
                await sqlConnection.OpenAsync();
                if (name != null || publishDate != null || author != null)
                {
                    var sqlCommand = new SqlCommand(expression, sqlConnection);
                    await sqlCommand.ExecuteNonQueryAsync();
                }
            }
        }

        //4. Создайте метод, который будет удалять книгу из БД по BookId.

        public async Task DeleteBookInfo(int bookId)
        {
            string expression = $"Delete FROM Books WHERE BookId = {bookId}";

            using (var sqlConnection = new SqlConnection(connectionString))
            {
                await sqlConnection.OpenAsync();

                var sqlCommand = new SqlCommand(expression, sqlConnection);
                await sqlCommand.ExecuteNonQueryAsync();
            }
        }
    }
}
