using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Windows.Forms;
using Npgsql;
using Fitness_Club.Helper_Classes;
using Fitness_Club.Helper_Classes.Tables;

namespace Fitness_Club.Model
{
    class ServiceModel
    {
        private Connection connection;
        public ServiceModel(Connection connection)
        {
            this.connection = connection;
        }
        public List<Service> GetServices()
        {
            Service service;
            List<Service> services = new List<Service>();
            try
            {
                string query = "select * from \"service\" order by service_name;";
                NpgsqlCommand Command =
                   new NpgsqlCommand(query, connection.CreateConnection.npgsqlConnection);
                NpgsqlDataReader dataReader = Command.ExecuteReader();
                foreach (DbDataRecord dbDataRecord in dataReader)
                {
                    service = new Service(dbDataRecord["service_id"].ToString(),
                                            dbDataRecord["employee_id"].ToString(),
                                            dbDataRecord["service_name"].ToString());
                    services.Add(service);
                }
                dataReader.Close();
            }
            catch(PostgresException ex)
            {
                MessageBox.Show("DB error. \n" + Convert.ToString(ex));
            }
            return services;
        }
        public void CreateService(string employeeId, string serviceName)
        {
            try
            {
                string query = $"select create_service('{employeeId}', '{serviceName}');";
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
