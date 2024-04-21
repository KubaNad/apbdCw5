using System.Data.SqlClient;
using System.Data;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;

namespace WebApplication1.Animals;

public class AnimalService : IAnimalService
{
    private readonly IConfiguration _configuration;
    private string _connectionString;

    public AnimalService(IConfiguration configuration)
    {
        _configuration = configuration;
        _connectionString = _configuration.GetConnectionString("DefaultConnection");
    }

    public IEnumerable<Animal> GetAnimals(string orderBy = "name")
    {
        List<Animal> animals = new List<Animal>();

        using (SqlConnection connection = new SqlConnection(_connectionString))
        {
            string sql = $"SELECT Id, Name, Description, Category, Area FROM Animals ORDER BY {orderBy};";
            SqlCommand command = new SqlCommand(sql, connection);

            connection.Open();
            using (SqlDataReader reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    Animal animal = new Animal()
                    {
                        Id = reader.GetInt32(0),
                        Name = reader.GetString(1),
                        Description = reader.GetString(2),
                        Category = reader.GetString(3),
                        Area = reader.GetString(4)
                    };
                    animals.Add(animal);
                }
            }
        }
        return animals;
    }

    public Animal GetAnimalById(int id)
    {
        using (SqlConnection connection = new SqlConnection(_connectionString))
        {
            string sql = "SELECT Id, Name, Description, Category, Area FROM Animals WHERE Id = @Id;";
            SqlCommand command = new SqlCommand(sql, connection);
            command.Parameters.AddWithValue("@Id", id);

            connection.Open();
            using (SqlDataReader reader = command.ExecuteReader())
            {
                if (reader.Read())
                {
                    return new Animal()
                    {
                        Id = reader.GetInt32(0),
                        Name = reader.GetString(1),
                        Description = reader.GetString(2),
                        Category = reader.GetString(3),
                        Area = reader.GetString(4)
                    };
                }
            }
        }
        return null;
    }

    public Animal AddAnimal(Animal animal)
    {
        using (SqlConnection connection = new SqlConnection(_connectionString))
        {
            string sql = "INSERT INTO Animals (Name, Description, Category, Area) VALUES (@Name, @Description, @Category, @Area); SELECT SCOPE_IDENTITY();";
            SqlCommand command = new SqlCommand(sql, connection);
            command.Parameters.AddWithValue("@Name", animal.Name);
            command.Parameters.AddWithValue("@Description", animal.Description);
            command.Parameters.AddWithValue("@Category", animal.Category);
            command.Parameters.AddWithValue("@Area", animal.Area);

            connection.Open();
            animal.Id = Convert.ToInt32(command.ExecuteScalar());
        }
        return animal;
    }

    public Animal UpdateAnimal(int id, Animal animal)
    {
        using (SqlConnection connection = new SqlConnection(_connectionString))
        {
            string sql = "UPDATE Animals SET Name = @Name, Description = @Description, Category = @Category, Area = @Area WHERE Id = @Id;";
            SqlCommand command = new SqlCommand(sql, connection);
            command.Parameters.AddWithValue("@Id", id);
            command.Parameters.AddWithValue("@Name", animal.Name);
            command.Parameters.AddWithValue("@Description", animal.Description);
            command.Parameters.AddWithValue("@Category", animal.Category);
            command.Parameters.AddWithValue("@Area", animal.Area);

            connection.Open();
            int result = command.ExecuteNonQuery();
            if (result > 0)
                return animal;
        }
        return null;
    }

    public bool DeleteAnimal(int id)
    {
        using (SqlConnection connection = new SqlConnection(_connectionString))
        {
            string sql = "DELETE FROM Animals WHERE Id = @Id;";
            SqlCommand command = new SqlCommand(sql, connection);
            command.Parameters.AddWithValue("@Id", id);

            connection.Open();
            int result = command.ExecuteNonQuery();
            return result > 0;
        }
    }
}
