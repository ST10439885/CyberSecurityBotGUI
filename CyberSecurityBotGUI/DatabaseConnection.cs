using MySql.Data.MySqlClient;

namespace CyberSecurityBotGUI
{
    public class DatabaseConnection
    {

        private string connectionString =
        "root14;";


        public MySqlConnection GetConnection()
        {
            return new MySqlConnection(connectionString);
        }

    }
}