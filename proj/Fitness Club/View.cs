using System;
using Npgsql;
using System.Windows.Forms;
using Fitness_Club.Helper_Classes;

namespace Fitness_Club
{
    public partial class View : Form
    {
        Factory factory;
        Presenter presenter = new Presenter();
        public View()
        {
            InitializeComponent();
            GetLoginTab();
        }

        public void Login(string login, string password)
        {
            factory = new Factory("127.0.0.1", "5433", login, password, "fitness_club");
        }
        private void btnShowClient_Click(object sender, EventArgs e)
        {
            dgvShowClient.Columns.Clear();
            dgvShowClient.Columns.Add("clientId", "Client's ID");
            dgvShowClient.Columns.Add("name", "Name");
            dgvShowClient.Columns.Add("phoneNumber", "Phone Number");
            dgvShowClient.Columns.Add("email", "Email");
            dgvShowClient.Columns.Add("subscriptionId", "Sub ID");
            dgvShowClient.Columns.Add("type", "Type");
            dgvShowClient.Columns.Add("price", "Price");
            dgvShowClient.Columns.Add("dateOfIssue", "Date Of Issue");
            dgvShowClient.Columns.Add("expirationDate", "Expiration Date");

            presenter.ShowClient(factory, dgvShowClient);
        }

        private void btnRegisterClient_Click(object sender, EventArgs e)
        {
            presenter.RegisterClient(factory,
                                     textBoxClientFirstName.Text,
                                     textBoxClientLastName.Text,
                                     textBoxClientPatronymic.Text,
                                     textBoxClientPhoneNumber.Text,
                                     textBoxClientEmail.Text);
        }

        private void btnSignIn_Click_1(object sender, EventArgs e)
        {
            try
            {
                Login(TextBoxLogin.Text, TextBoxPassword.Text);
                switch (comboBoxRole.SelectedItem)
                {
                    case "trainer":
                        GetTrainerTab();
                        break;
                    case "admin":
                        GetAdminTab();
                        break;
                }
                tabControl1.TabPages.Remove(loginTab);
            }
            catch (PostgresException pgex)
            {
                MessageBox.Show("Incorrect login or password. \n" + Convert.ToString(pgex));
            }

        }

        #region GetTabs
        private void GetAdminTab()
        {
            tabControl1.TabPages.Add(adminTab);
            presenter.FillPositions(factory, comboBoxRegisterEmployeePosition);
        }
        private void GetTrainerTab()
        {
            tabControl1.TabPages.Add(trainerTab);
            tabControl1.TabPages.Add(clientTab);

            comboBoxCreateScheduleDay.Items.Add("monday");
            comboBoxCreateScheduleDay.Items.Add("tuesday");
            comboBoxCreateScheduleDay.Items.Add("wednesday");
            comboBoxCreateScheduleDay.Items.Add("thursday");
            comboBoxCreateScheduleDay.Items.Add("friday");
            comboBoxCreateScheduleDay.Items.Add("sunday");
            comboBoxCreateScheduleDay.Items.Add("saturday");

            presenter.FillRooms(factory, comboBoxCreateScheduleRoom);
            presenter.FillSubscriptionType(factory, comboBoxSubscribeClientSubscriptionType);
        }
        private void GetLoginTab()
        {
            // Filling of combobox with roles
            comboBoxRole.Items.Add("admin");
            comboBoxRole.Items.Add("trainer");

            // Leave only authentication tab
            tabControl1.TabPages.Remove(adminTab);
            tabControl1.TabPages.Remove(trainerTab);
            tabControl1.TabPages.Remove(clientTab);
        }
        #endregion

        private void btnRegisterEmployee_Click(object sender, EventArgs e)
        {
            presenter.RegisterEmployee(factory,
                                       textBoxRegisterEmployeePassport.Text,
                                       textBoxRegisterEmployeeFirstName.Text,
                                       textBoxRegisterEmployeeLastName.Text,
                                       textBoxRegisterEmployeePatronymic.Text,
                                       textBoxRegisterEmployeePhoneNumber.Text,
                                       textBoxRegisterEmployeeEmail.Text,
                                       comboBoxRegisterEmployeePosition.SelectedItem.ToString(),
                                       dateTimePickerRegisterEmployeeDateOfIssue.Value.ToShortDateString(),
                                       dateTimePickerRegisterEmployeeExpirationDate.Value.ToShortDateString());
        }

        private void btnShowEmployee_Click(object sender, EventArgs e)
        {
            dgvShowEmployee.Columns.Clear();
            dgvShowEmployee.Columns.Add("employeeId", "Employee's ID");
            dgvShowEmployee.Columns.Add("name", "Name");
            dgvShowEmployee.Columns.Add("phoneNumber", "Phone Number");
            dgvShowEmployee.Columns.Add("passport", "Passport");
            dgvShowEmployee.Columns.Add("email", "Email");
            dgvShowEmployee.Columns.Add("positionName", "Position");
            dgvShowEmployee.Columns.Add("serviceName", "Service");
            dgvShowEmployee.Columns.Add("dateOfIssue", "Date Of Issue");
            dgvShowEmployee.Columns.Add("expirationDate", "Expiration Date");


            presenter.ShowEmployee(factory, dgvShowEmployee);
        }

        private void btnAddService_Click(object sender, EventArgs e)
        {
            presenter.AddService(factory, textBoxAddServiceEmployeeId.Text, textBoxAddServiceServiceName.Text);
        }

        private void btnFireEmployee_Click(object sender, EventArgs e)
        {
            presenter.FireEmployee(factory, textBoxFireEmployeeID.Text);
        }

        private void btnShowSchedule_Click(object sender, EventArgs e)
        {
            dataGridViewShowShedule.Columns.Clear();
            dataGridViewShowShedule.Columns.Add("scheduleId", "Schedule's ID");
            dataGridViewShowShedule.Columns.Add("serviceName", "Service Name");
            dataGridViewShowShedule.Columns.Add("employeeId", "Employee's ID");
            dataGridViewShowShedule.Columns.Add("clientId", "Client's ID");
            dataGridViewShowShedule.Columns.Add("roomType", "Room Type");
            dataGridViewShowShedule.Columns.Add("day", "Day");
            dataGridViewShowShedule.Columns.Add("startTime", "Start Time");
            dataGridViewShowShedule.Columns.Add("endTime", "End Time");

            presenter.ShowSchedule(factory, dataGridViewShowShedule);
        }

        private void btnCreateSchedule_Click(object sender, EventArgs e)
        {
            presenter.CreateSchedule(factory,
                                     textBoxCreateScheduleService.Text,
                                     textBoxCreateScheduleClientID.Text,
                                     comboBoxCreateScheduleRoom.SelectedItem.ToString(),
                                     comboBoxCreateScheduleDay.SelectedItem.ToString(),
                                     dateTimePickerCreateScheduleStartTime.Value.ToShortTimeString(),
                                     dateTimePickerCreateScheduleEndTime.Value.ToShortTimeString());
        }

        private void btnSubscribeClient_Click(object sender, EventArgs e)
        {
            presenter.SubscribeClient(factory, textBoxSubscribeClientClientID.Text,
                                      comboBoxSubscribeClientSubscriptionType.SelectedItem.ToString(),
                                      dateTimePickerSubscribeClientDateOfIssue.Value.ToShortDateString(),
                                      dateTimePickerSubscribeClientExpirationDate.Value.ToShortDateString());
        }

        private void btnRenewSubscription_Click(object sender, EventArgs e)
        {
            presenter.RenewSubscription(factory, textBoxRenewSubscriptionSubscriptionID.Text,
                                        dateTimePickerRenewSubscriptionExpirationDate.Value.ToShortDateString());
        }

        private void btnShowSubscriptionType_Click(object sender, EventArgs e)
        {
            dataGridViewSubType.Columns.Clear();
            dataGridViewSubType.Columns.Add("subscriptionTypeId", "ID");
            dataGridViewSubType.Columns.Add("type", "Type");
            dataGridViewSubType.Columns.Add("price", "Price");

            presenter.ShowSubscriptionType(factory, dataGridViewSubType);
        }

        private void btnShowService_Click(object sender, EventArgs e)
        {
            dataGridViewShowService.Columns.Clear();
            dataGridViewShowService.Columns.Add("serviceId", "ID");
            dataGridViewShowService.Columns.Add("employeeId", "Employee's ID");
            dataGridViewShowService.Columns.Add("serviceName", "Service Name");

            presenter.ShowService(factory, dataGridViewShowService);
        }

        private void btnDeleteSchedule_Click(object sender, EventArgs e)
        {
            presenter.DeleteSchedule(factory, textBoxDeleteScheduleScheduleID.Text);
        }
    }
}
