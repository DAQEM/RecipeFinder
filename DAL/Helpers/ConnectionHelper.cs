﻿using System.Configuration;
using MySql.Data.MySqlClient;

namespace DAL.Helpers;

public static class ConnectionHelper
{
    
    public static MySqlConnection GetConnection()
    {
        return new MySqlConnection(GetConnectionString());
    }

    private static string GetConnectionString()
    {
        try
        {
            return ConfigurationManager.ConnectionStrings["DatabaseConnection"].ConnectionString;
        }
        catch (Exception ex)
        {
            throw new Exception("Unable to get connection string. (Should be located in the app.config file)", ex);
        }
    }
}