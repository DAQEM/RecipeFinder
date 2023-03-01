using System.Configuration;

namespace DAL;

public static class ConnectionHelper
{
    public static string GetConnectionString()
    {
        try
        {
            return ConfigurationManager.ConnectionStrings["DatabaseConnection"].ConnectionString;
        } catch (Exception ex)
        {
            throw new Exception("Unable to get connection string. (Should be located in the app.config file)", ex);
        }
    }
}