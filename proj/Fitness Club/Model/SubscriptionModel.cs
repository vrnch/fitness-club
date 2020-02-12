using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Windows.Forms;
using Npgsql;
using Fitness_Club.Helper_Classes;
using Fitness_Club.Helper_Classes.Tables;
namespace Fitness_Club.Model
{
    class SubscriptionModel
    {
        private Connection connection;

        public SubscriptionModel(Connection connection)
        {
            this.connection = connection;
        }
        public void AddSubscription(string clientId, string subscriptionTypeId, string dateOfIssue, string expirationDate)
        {
            try
            {
                string query = $"select subscribe_client('{clientId}','{subscriptionTypeId}','{dateOfIssue}','{expirationDate}');";
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
        public void RenewSubscription(string subscriptionId, string dateOfIssue)
        {
            try
            {
                string query = $"select renew_subscription('{subscriptionId}','{dateOfIssue}');";
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
