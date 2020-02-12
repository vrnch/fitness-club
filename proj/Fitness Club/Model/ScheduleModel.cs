using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Windows.Forms;
using Npgsql;
using Fitness_Club.Helper_Classes;
using Fitness_Club.Helper_Classes.Tables;
namespace Fitness_Club.Model
{
    class ScheduleModel
    {
        private Connection connection;

        public ScheduleModel(Connection connection)
        {
            this.connection = connection;
        }
        public List<Schedule> GetSchedules()
        {
            Schedule schedule;
            List<Schedule> schedules = new List<Schedule>();
            try
            {
                string query = "select * from schedule_info order by schedule_id;";
                NpgsqlCommand command =
                    new NpgsqlCommand(query, connection.CreateConnection.npgsqlConnection);
                NpgsqlDataReader dataReader = command.ExecuteReader();

                foreach (DbDataRecord dbDataRecord in dataReader)
                {
                    schedule = new Schedule(
                        dbDataRecord["schedule_id"].ToString(),
                        dbDataRecord["service_name"].ToString(),
                        dbDataRecord["employee_id"].ToString(),
                        dbDataRecord["client_id"].ToString(),
                        dbDataRecord["room_type"].ToString(),
                        dbDataRecord["day"].ToString(),
                        dbDataRecord["start_time"].ToString(),
                        dbDataRecord["end_time"].ToString());
                    schedules.Add(schedule);
                }
                dataReader.Close();
            }
            catch (PostgresException ex)
            {
                MessageBox.Show("DB error. \n" + Convert.ToString(ex));
            }
            return schedules;
        }
        public void CreateSchedule(string serviceId, string clientId, string roomName, string day, string startTime,
                        string endTime)
        {
            try
            {
                string query = $"select create_schedule('{serviceId}', '{clientId}', '{roomName}', '{day}', " +
                                $"'{startTime}','{endTime}');";
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
        public void DeleteSchedule(string scheduleId)
        {
            try
            {
                string query = $"select delete_schedule({scheduleId});";
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
