using Npgsql;

namespace MeuProjetoMVC.Models;

public class LoginRequest
{
    public string user { get; set; } = string.Empty;
    public string password { get; set; } = string.Empty;

    public bool isValidUser;


    public void SelectUserAndPassword()
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
}