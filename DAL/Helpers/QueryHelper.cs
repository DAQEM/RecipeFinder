using MySql.Data.MySqlClient;

namespace DAL.Helpers;

public static class QueryHelper
{
    public static T? QuerySingle<T>(string query, MySqlParameter[]? parameters, Func<MySqlDataReader, T> mapper)
    {
        using MySqlConnection connection = ConnectionHelper.GetConnection();
        using MySqlCommand command = new(query, connection);
        
        if (parameters != null)
        {
            foreach (MySqlParameter parameter in parameters)
            {
                command.Parameters.Add(parameter);
            }
        }
        
        try
        {
            connection.Open();
            using MySqlDataReader reader = command.ExecuteReader();

            if (reader.Read())
            {
                T result = mapper(reader);
                return result;
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }

        return default;
    }
    
    public static List<T> QueryMultiple<T>(string query, MySqlParameter[]? parameters, Func<MySqlDataReader, T> mapper)
    {
        List<T> results = new();
        using MySqlConnection connection = ConnectionHelper.GetConnection();
        using MySqlCommand command = new(query, connection);

        if (parameters != null)
        {
            foreach (MySqlParameter parameter in parameters)
            {
                command.Parameters.Add(parameter);
            }
        }

        try
        {
            connection.Open();
            using MySqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                results.Add(mapper(reader));
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
        finally
        {
            
        }

        return results;
    }
    
    public static void NonQuery(string query, MySqlParameter[]? parameters)
    {
        using MySqlConnection connection = ConnectionHelper.GetConnection();
        using MySqlCommand command = new(query, connection);
        if (parameters != null)
        {
            foreach (MySqlParameter parameter in parameters)
            {
                command.Parameters.Add(parameter);
            }
        }

        connection.Open();
        command.ExecuteNonQuery();
    }
}