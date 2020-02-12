using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Windows.Forms;
using Npgsql;
using Fitness_Club.Helper_Classes;
using Fitness_Club.Helper_Classes.Tables;

namespace Fitness_Club.Model
{
    class ContractModel
    {
        private Connection connection;

        public ContractModel(Connection connection)
        {
            this.connection = connection;
        }
        public void FireEmployee(string employeeId)
        {
            try
            {
                string query = $"update \"contract\" set expiration_date = current_date where employee_id = {employeeId};";
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
            catch (PostgresException ex)
            {
                MessageBox.Show("Check input parameters. \n" + Convert.ToString(ex));
            }
        }
    }
}
