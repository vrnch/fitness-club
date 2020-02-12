using System;
using Npgsql;
using System.Windows.Forms;

namespace Fitness_Club.Helper_Classes
{
    class Connection
    {
        private static Connection newConnection = null;
        public NpgsqlConnection npgsqlConnection { get; }
        public Connection(NpgsqlConnection connection)
        {
            npgsqlConnection = connection;
        }

        public Connection CreateConnection => newConnection = new Connection(npgsqlConnection);

        public void OpenConnection()
        {
            try
            {
                npgsqlConnection.Open();
            }
            catch (Exception ex)
            {
                MessageBox.Show(Convert.ToString(ex));
            }
        }
        public void CloseConnection()
        {
            try
            {
                npgsqlConnection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(Convert.ToString(ex));
            }
        }
    }
}
