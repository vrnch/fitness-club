using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Windows.Forms;
using Npgsql;
using Fitness_Club.Helper_Classes;
using Fitness_Club.Helper_Classes.Tables;


namespace Fitness_Club.Model
{
    class PositionModel
    {
        private Connection connection;
        public PositionModel(Connection connection)
        {
            this.connection = connection;
        }
        public List<Position> GetPositionNames()
        {
            Position position;
            List<Position> positions = new List<Position>();
            try
            {
                string QueryString =
                    "select position_name from \"position\";";
                NpgsqlCommand Command =
                    new NpgsqlCommand(QueryString, connection.CreateConnection.npgsqlConnection); 
                NpgsqlDataReader dataReader = Command.ExecuteReader(); 
                foreach (DbDataRecord dbDataRecord in dataReader)
                {
                    position = new Position(
                        dbDataRecord["position_name"].ToString());
                    positions.Add(position);
                }
                dataReader.Close();
            }
            catch (PostgresException ex)
            {
                MessageBox.Show("DB error. \n" + Convert.ToString(ex));
            }
            return positions;
        }
    }
}
