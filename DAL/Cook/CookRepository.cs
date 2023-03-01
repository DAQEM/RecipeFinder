using System.Configuration;
using System.Data.SqlClient;
using BLL.Data.Cook;
using MySql.Data.MySqlClient;

namespace DAL.Cook;

public class CookRepository : ICookRepository
{
    public List<BLL.Entities.Cook> GetAll()
    {
        List<BLL.Entities.Cook> cooks = new();

        string connectionString = ConnectionHelper.GetConnectionString();
        string query = "SELECT * FROM Cook;";

        using MySqlConnection connection = new (connectionString);
        using MySqlCommand command = new (query, connection);

        try
        {
            connection.Open();
            using MySqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                BLL.Entities.Cook cook = new BLL.Entities.Cook.Builder()
                    .WithId(reader.GetGuid("id"))
                    .WithUserName(reader.GetString("username"))
                    .WithFullName(reader.GetString("fullname"))
                    .WithImageUri(reader.GetString("image_url"))
                    .WithCreatedAt(reader.GetDateTime("created_at"))
                    .Build();
                cooks.Add(cook);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }

        return cooks;
    }

    public BLL.Entities.Cook GetById(Guid id)
    {
        string connectionString = ConnectionHelper.GetConnectionString();
        string query = "SELECT * FROM Cook;";

        using MySqlConnection connection = new (connectionString);
        using MySqlCommand command = new (query, connection);

        try
        {
            connection.Open();
            using MySqlDataReader reader = command.ExecuteReader();

            if (reader.Read())
            {
                BLL.Entities.Cook cook = new BLL.Entities.Cook.Builder()
                    .WithId(reader.GetGuid("id"))
                    .WithUserName(reader.GetString("username"))
                    .WithFullName(reader.GetString("fullname"))
                    .WithImageUri(reader.GetString("image_url"))
                    .WithCreatedAt(reader.GetDateTime("created_at"))
                    .Build();
                return cook;
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }

        return null;
    }

    public void Add(BLL.Entities.Cook cook)
    {
        
    }

    public void Update(BLL.Entities.Cook cook)
    {
        
    }

    public void Delete(BLL.Entities.Cook cook)
    {
        
    }
}