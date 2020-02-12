using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Windows.Forms;
using Npgsql;
using Fitness_Club.Helper_Classes;
using Fitness_Club.Helper_Classes.Tables;

namespace Fitness_Club.Model
{
    class SubscriptionTypeModel
    {
        private Connection connection;

        public SubscriptionTypeModel(Connection connection)
        {
            this.connection = connection;
        }
        public List<SubscriptionType> GetSubscriptionTypes()
        {

            SubscriptionType subscriptionType;
            List<SubscriptionType> subscriptionTypes = new List<SubscriptionType>();
            try
            {
                string query = "select * from \"subscription_type\";";
                NpgsqlCommand Command =
                   new NpgsqlCommand(query, connection.CreateConnection.npgsqlConnection);
                NpgsqlDataReader dataReader = Command.ExecuteReader();
                foreach (DbDataRecord dbDataRecord in dataReader)
                {
                    subscriptionType = new SubscriptionType(dbDataRecord["subscription_type_id"].ToString(),
                        dbDataRecord["type"].ToString(), dbDataRecord["price"].ToString());
                    subscriptionTypes.Add(subscriptionType);
                }
                dataReader.Close();
            }
            catch (PostgresException ex)
            {
                MessageBox.Show("DB error. \n" + Convert.ToString(ex));
            }
            return subscriptionTypes;
        }
    }
}
