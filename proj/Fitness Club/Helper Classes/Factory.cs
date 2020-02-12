using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Npgsql;
using Fitness_Club.Model;

namespace Fitness_Club.Helper_Classes
{
    class Factory : IDisposable
    {
        public NpgsqlConnection npgsqlConnection;
        public Connection connection;

        public ClientModel clientModel { get; }
        public EmployeeModel employeeModel { get; }
        public PositionModel positionModel { get; }
        public ServiceModel serviceModel { get; }
        public ContractModel contractModel { get; }
        public RoomModel roomModel { get; }
        public ScheduleModel scheduleModel { get; }
        public SubscriptionModel subscriptionModel { get; }
        public SubscriptionTypeModel subscriptionTypeModel { get; }

        public Factory(string server, string port, string user, string pass, string dbname)
        {
            string ConnectionString = $"Server={server}; Port={port}; User Id={user}; Password={pass}; Database={dbname};";
            npgsqlConnection = new NpgsqlConnection(ConnectionString);
            connection = new Connection(npgsqlConnection);
            OpenConnection();
            clientModel = new ClientModel(connection);
            employeeModel = new EmployeeModel(connection);
            positionModel = new PositionModel(connection);
            serviceModel = new ServiceModel(connection);
            contractModel = new ContractModel(connection);
            roomModel = new RoomModel(connection);
            scheduleModel = new ScheduleModel(connection);
            subscriptionModel = new SubscriptionModel(connection);
            subscriptionTypeModel = new SubscriptionTypeModel(connection);
        }

        private bool Disposed = false;

        public void OpenConnection()
        {
            connection.npgsqlConnection.Open();
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        public void Dispose(bool disposing)
        {
            if (!Disposed)
            {
                if (disposing)
                {
                    connection.npgsqlConnection.Close();
                }
                Disposed = true;
            }
        }
        ~Factory()
        {
            Dispose(false);
        }
    }
}
