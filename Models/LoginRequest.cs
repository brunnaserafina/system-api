using Npgsql;

namespace MeuProjetoMVC.Models;

public class LoginRequest
{
    public string user { get; set; } = string.Empty;
    public string password { get; set; } = string.Empty;

    public bool isValidUser;

    int userId;


    public void ValidateUserAndPassword()
    {
        var configuration = new ConfigurationBuilder()
            .AddJsonFile("appsettings.json")
            .Build();

        var connectionString = configuration.GetConnectionString("ConnectionDb");

        using (var connection = new NpgsqlConnection(connectionString))
        {
            connection.Open();

            using (var command = new NpgsqlCommand("SELECT * FROM users WHERE name = @valor1 AND password = @valor2;", connection))
            {
                command.Parameters.AddWithValue("valor1", this.user);
                command.Parameters.AddWithValue("valor2", this.password);

                using (var reader = command.ExecuteReader())
                {
                    if (reader.HasRows)
                    {   
                        reader.Read();
                        userId = reader.GetInt32(0);
                        this.isValidUser = true;
                    }
                    else
                    {
                        this.isValidUser = false;
                    }
                }
            }

            connection.Close();
        }
    }


    public void InsertTokenInSession(string token)
    {
        var configuration = new ConfigurationBuilder()
            .AddJsonFile("appsettings.json")
            .Build();

        var connectionString = configuration.GetConnectionString("ConnectionDb");

        using (var connection = new NpgsqlConnection(connectionString))
        {
            connection.Open();

            using (var command = new NpgsqlCommand("INSERT INTO sessions (user_id, token) VALUES (@valor1, @valor2)", connection))
            {
                command.Parameters.AddWithValue("valor1", userId);
                command.Parameters.AddWithValue("valor2", token);

                command.ExecuteNonQuery();
            }

            connection.Close();
        }
    }
}