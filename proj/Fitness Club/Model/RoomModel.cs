using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Windows.Forms;
using Npgsql;
using Fitness_Club.Helper_Classes;
using Fitness_Club.Helper_Classes.Tables;

namespace Fitness_Club.Model
{
    class RoomModel
    {
        private Connection connection;

        public RoomModel(Connection connection)
        {
            this.connection = connection;
        }
        public List<Room> GetRooms()
        {
            
            Room room;
            List<Room> rooms = new List<Room>();
            try
            {
                string query = "select * from room order by room_id;";
                NpgsqlCommand command =
                    new NpgsqlCommand(query, connection.CreateConnection.npgsqlConnection);
                NpgsqlDataReader dataReader = command.ExecuteReader();

                foreach (DbDataRecord dbDataRecord in dataReader)
                {
                    room = new Room(
                        dbDataRecord["room_id"].ToString(),
                        dbDataRecord["is_available"].ToString(),
                        dbDataRecord["type"].ToString(),
                        dbDataRecord["capacity"].ToString());
                    rooms.Add(room);
                }
                dataReader.Close();
            }
            catch (PostgresException ex)
            {
                MessageBox.Show("DB error. \n" + Convert.ToString(ex));
            }
            return rooms;
        }
    }
}
