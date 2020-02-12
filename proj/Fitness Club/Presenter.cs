using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Fitness_Club.Model;
using Fitness_Club.Helper_Classes;
using System.Windows.Forms;

namespace Fitness_Club
{
    class Presenter
    {
        public void ShowClient(Factory factory, DataGridView dgv)
        {
            foreach (var i in factory.clientModel.GetClients())
                dgv.Rows.Add(i.clientId, i.name, i.phoneNumber, i.email, i.subscriptionId, i.type, i.price,
                             i.dateOfIssue, i.expirationDate);
        }
        public void ShowEmployee(Factory factory, DataGridView dgv)
        {
            foreach (var i in factory.employeeModel.GetEmployees())
                dgv.Rows.Add(i.employeeId, i.name, i.phoneNumber, i.passport, i.email, i.positionName, i.serviceName,
                             i.dateOfIssue, i.expirationDate);
        }
        public void ShowSchedule(Factory factory, DataGridView dgv)
        {
            foreach (var i in factory.scheduleModel.GetSchedules())
                dgv.Rows.Add(i.scheduleId, i.serviceName, i.employeeId, i.clientId, i.roomType, i.day, i.startTime,
                             i.endTime);
        }
        public void ShowSubscriptionType(Factory factory, DataGridView dgv)
        {
            foreach (var i in factory.subscriptionTypeModel.GetSubscriptionTypes())
                dgv.Rows.Add(i.subscriptionTypeId, i.type, i.price);
        }
        public void ShowService(Factory factory,DataGridView dgv)
        {
            foreach (var i in factory.serviceModel.GetServices())
                dgv.Rows.Add(i.serviceId, i.employeeId, i.serviceName);
        }
        public void RegisterClient(Factory factory, string firstName, string lastName, string patronymic,
                                   string phoneNumber, string email)
        {
            factory.clientModel.CreateClient(firstName, lastName, patronymic, phoneNumber, email);
        }
        public void RegisterEmployee(Factory factory, string passport, string firstName, string lastName,
                                     string patronymic, string phoneNumber, string email, string positionName,
                                     string dateOfIssue, string expirationDate)
        {
            factory.employeeModel.CreateEmployee(passport, firstName, lastName, patronymic, phoneNumber, email,
                                                 positionName, dateOfIssue, expirationDate);
        }
        public void AddService(Factory factory, string employeeId, string serviceName)
        {
            factory.serviceModel.CreateService(employeeId, serviceName);
        }
        public void CreateSchedule(Factory factory, string serviceId, string clientId, string roomName, string day, string startTime,
                        string endTime)
        {
            factory.scheduleModel.CreateSchedule(serviceId, clientId, roomName, day, startTime, endTime);
        }
        public void SubscribeClient(Factory factory, string clientId, string subscriptionTypeId, string dateOfIssue, string expirationDate)
        {
            factory.subscriptionModel.AddSubscription(clientId, subscriptionTypeId, dateOfIssue, expirationDate);
        }
        public void FireEmployee(Factory factory, string employeeId)
        {
            factory.contractModel.FireEmployee(employeeId);
        }
        public void RenewSubscription(Factory factory, string subscriptionId, string dateOfIssue)
        {
            factory.subscriptionModel.RenewSubscription(subscriptionId, dateOfIssue);
        }
        public void DeleteSchedule (Factory factory, string scheduleId)
        {
            factory.scheduleModel.DeleteSchedule(scheduleId);
        }
        #region ComboBoxFill
        public void FillPositions(Factory factory, ComboBox comboBox)
        {
            foreach (var i in factory.positionModel.GetPositionNames())
                comboBox.Items.Add(i.Name);
        }

        public void FillServices(Factory factory,ComboBox comboBox)
        {
            foreach (var i in factory.serviceModel.GetServices())
                comboBox.Items.Add(i.serviceName);
        }

        public void FillRooms(Factory factory, ComboBox comboBox)
        {
            foreach (var i in factory.roomModel.GetRooms())
              comboBox.Items.Add(i.type);
        }
        public void FillSubscriptionType(Factory factory, ComboBox comboBox)
        {
            foreach (var i in factory.subscriptionTypeModel.GetSubscriptionTypes())
                comboBox.Items.Add(i.type);
        }
        #endregion
    }
}
