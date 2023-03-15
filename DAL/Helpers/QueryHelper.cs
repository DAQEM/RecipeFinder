using MySql.Data.MySqlClient;

namespace DAL.Helpers;

public static class QueryHelper
{
    public static T? QuerySingle<T>(string query, MySqlParameter[]? parameters, Func<MySqlDataReader, T> mapper)
    {
        using (MySqlConnection connection = ConnectionHelper.GetConnection())
        {
            using (MySqlCommand command = new(query, connection))
            {
                if (parameters != null) command.Parameters.AddRange(parameters);
                try
                {
                    connection.Open();
                    using (MySqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            T result = mapper(reader);
                            return result;
                        }
                    }
                }
                catch (Exception ex) when(ex is MySqlException or InvalidOperationException)
                {
                    Console.WriteLine(ex.Message);
                }
                finally
                {
                    connection.Close();
                }
            }
        }
        return default;
    }
    
    public static List<T> QueryMultiple<T>(string query, MySqlParameter[]? parameters, Func<MySqlDataReader, T> mapper)
    {
        List<T> results = new();
        using (MySqlConnection connection = ConnectionHelper.GetConnection())
        {
            using (MySqlCommand command = new(query, connection))
            {
                if (parameters != null) command.Parameters.AddRange(parameters);
                try
                {
                    connection.Open();
                    using (MySqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            results.Add(mapper(reader));
                        }
                    }
                }
                catch (Exception ex) when (ex is MySqlException or InvalidOperationException)
                {
                    Console.WriteLine(ex.Message);
                }
                finally
                {
                    connection.Close();
                }
            }
        }
        return results;
    }
    
    public static void NonQuery(string query, MySqlParameter[]? parameters)
    {
        using (MySqlConnection connection = ConnectionHelper.GetConnection())
        {
            using (MySqlCommand command = new(query, connection))
            {
                if (parameters != null) command.Parameters.AddRange(parameters);

                connection.Open();
                command.ExecuteNonQuery();
                connection.Close();
            }
        }
    }
}