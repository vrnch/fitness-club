using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Windows.Forms;
using Npgsql;
using Fitness_Club.Helper_Classes;
using Fitness_Club.Helper_Classes.Tables;

namespace Fitness_Club.Model
{
    class ClientModel
    {
        private Connection connection;
        public ClientModel(Connection connection)
        {
            this.connection = connection;
        }

        public List<Client> GetClients()
        {
            Client client;
            List<Client> clients = new List<Client>();
            try
            {
                string query = "select * from client_info order by client_id;";
                NpgsqlCommand command = // Create the command from the query and Connection
                    new NpgsqlCommand(query, connection.CreateConnection.npgsqlConnection);
                NpgsqlDataReader dataReader = command.ExecuteReader(); // Call the command, execute it at DB

                foreach(DbDataRecord dbDataRecord in dataReader)
                {
                    client = new Client(
                        dbDataRecord["client_id"].ToString(),
                        dbDataRecord["name"].ToString(),
                        dbDataRecord["phone_number"].ToString(),
                        dbDataRecord["email"].ToString(),
                        dbDataRecord["subscription_id"].ToString(),
                        dbDataRecord["type"].ToString(),
                        dbDataRecord["price"].ToString(),
                        dbDataRecord["date_of_issue"].ToString(),
                        dbDataRecord["expiration_date"].ToString());
                    clients.Add(client);
                }
                dataReader.Close();
            }
            catch (PostgresException ex)
            {
                MessageBox.Show("DB error. \n" + Convert.ToString(ex));
            }
            return clients;
        }

        public void CreateClient(string firstName, string lastName, string patronymic, string phoneNumber, string email)
        {
            try
            {
                string query = $"select create_client('{firstName}', '{lastName}', '{patronymic}', '{phoneNumber}', '{email}');";
                NpgsqlCommand command = new NpgsqlCommand(query, connection.CreateConnection.npgsqlConnection);
                try
                {
                    command.ExecuteNonQuery(); // NonQuery means we are not interested in returned value 
                }
                catch (PostgresException ex)
                {
                    MessageBox.Show("Check input values in pg.\n" + ex.Message);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Check input values.\n" + ex.Message);
            }
        }
        
    }
}
