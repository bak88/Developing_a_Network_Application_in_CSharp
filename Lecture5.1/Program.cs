using Npgsql;

namespace Lecture5._1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string connectionString = "Host=localhost;Username=postgres;Password=example;Database=Test";

            using (NpgsqlConnection connection = new NpgsqlConnection(connectionString))
            {
                connection.Open();

                string query = "SELECT Users.id, Users.name, Messages.message " +
                                "FROM Users " +
                                "JOIN Messages ON Users.id = Messages.user_id";

                using (NpgsqlCommand command = new NpgsqlCommand(query, connection))
                {
                    using (NpgsqlDataReader reader = command.ExecuteReader())
                    {
                        while(reader.Read())
                        {
                            int userId = reader.GetInt32(0);
                            string userName =reader.GetString(1);
                            string message = reader.GetString(2);

                            Console.WriteLine($"User ID: {userId}, User Name: {userName}, Message: {message}");
                        }
                    }
                }
            }
        }
    }
}
