using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Windows.Forms;
using Npgsql;
using Fitness_Club.Helper_Classes;
using Fitness_Club.Helper_Classes.Tables;

namespace Fitness_Club.Model
{
    class EmployeeModel
    {
        private Connection connection;
        public EmployeeModel(Connection connection)
        {
            this.connection = connection;
        }

        public List<Employee> GetEmployees()
        {
            Employee employee;
            List<Employee> employees = new List<Employee>();
            try
            {
                string query = "select * from employee_info order by employee_id;";
                NpgsqlCommand command =
                    new NpgsqlCommand(query, connection.CreateConnection.npgsqlConnection);
                NpgsqlDataReader dataReader = command.ExecuteReader();

                foreach(DbDataRecord dbDataRecord in dataReader)
                {
                    employee = new Employee(
                        dbDataRecord["employee_id"].ToString(),
                        dbDataRecord["name"].ToString(),
                        dbDataRecord["phone_number"].ToString(),
                        dbDataRecord["passport_number_and_series"].ToString(),
                        dbDataRecord["email"].ToString(),
                        dbDataRecord["position_name"].ToString(),
                        dbDataRecord["service_name"].ToString(),
                        dbDataRecord["date_of_issue"].ToString(),
                        dbDataRecord["expiration_date"].ToString());
                    employees.Add(employee);
                }
                dataReader.Close();
            }
            catch(PostgresException ex)
            {
                MessageBox.Show("DB error. \n" + Convert.ToString(ex));
            }
            return employees;
        }
        public void CreateEmployee (string passport, string firstName, string lastName, string patronymic,
                                    string phoneNumber, string email, string positionName, string dateOfIssue,
                                    string expirationDate)
        {
            try
            {
                string query = $"select create_employee('{passport}', '{firstName}', '{lastName}', '{patronymic}', " +
                                $"'{phoneNumber}','{email}', '{positionName}', '{dateOfIssue}', '{expirationDate}');";               
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
            catch(PostgresException ex)
            {
                MessageBox.Show("Check input parameters. \n" + Convert.ToString(ex));
            }            
        }
        
        public void CreateSchedule(string serviceID, string clientId, string roomId,string day, string startTime, string endTime)
        {
            try
            {
                string query = $"select create_schedule({serviceID}, {clientId}, {roomId}, {day}, '{startTime}', '{endTime}');";
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
