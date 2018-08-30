using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CapstoneSIMS.Usercontrols;
using System.Data.SqlClient;
using MetroFramework;
using DataAccess;

namespace CapstoneSIMS
{
    public enum Action
    {
        Edit,
        Add
    }

    public partial class MaintenancePerson : Form
    {
        private User _user;

        private Customer _customer;

        private Person _person;

        private Action _action;

        public MaintenancePerson(Action action, Person person = null) 
        {

            _action = action;

            InitializeComponent();

            DefinePerson(person);

            DefineControlText(action);
        }

        public void DefineControlVisible(Person person)
        {

            if (person is User)
                IsVisibleUserControl(true);
            else if (person is Customer)
                IsVisibleUserControl(false);
        }

        private void DefineControlText(Action action)
        {
            if (action == Action.Add)
            {
                btn_action.Text = "Add";
                label1.Text = "Add Information";
            }
            else
            {
                btn_action.Text = "Edit";
                label1.Text = "Edit Information";
            }
        }

        private void DefinePerson(Person person)
        {
            if (person is null)
                return;

            _person = person;

            if (person is User)
            {
                _user = (User)person;

                DisplayUser();

                IsVisibleUserControl(true);
            }
            else
            {
                _customer = (Customer)person;

                DisplayCustomer();

                IsVisibleUserControl(false); ;
            }
        }

        private void IsVisibleUserControl(bool x)
        {
            txt_username.Visible = x;
            txt_password.Visible = x;
            label8.Visible = x;
            label9.Visible = x;

        }

        public void DisplayUser()
        {
            using (var unit = new UnitOfWork())
            {
                var user = GetUser(unit);

                txt_username.Text     = user.UserName;
                txt_password.Text     = user.Password;
                txt_firstname.Text    = user.FirstName;
                txt_lastname.Text     = user.LastName;
                dateTimePicker1.Value = user.BirthDate;
                rbMale.Checked        = (user.Gender.ToLower() == "male") ? true : false;
                rbFemale.Checked      = (user.Gender.ToLower() == "female") ? true : false;
                txt_contact.Text      = user.Contact.ToString();
                txt_email.Text        = user.Email;
                
            }
        }

        public void DisplayCustomer()
        {
            using (var unit = new UnitOfWork())
            {
                var customer = GetCustomer(unit);
                
                txt_firstname.Text    = customer.FirstName;
                txt_lastname.Text     = customer.LastName;
                dateTimePicker1.Value = customer.BirthDate;
                rbMale.Checked        = (customer.Gender.ToLower() == "male") ? true : false;
                rbFemale.Checked      = (customer.Gender.ToLower() == "female") ? true : false;
                txt_contact.Text      = customer.Contact.ToString();
                txt_email.Text        = customer.Email;

            }
        }

        private User GetUser(UnitOfWork unit)
        {
            return unit.Users.Get(u => u.UserID == _user.UserID);
        }

        private Customer GetCustomer(UnitOfWork unit)
        {
            return unit.Customers.Get(c => c.CustomerID == _customer.CustomerID);
        }

        private void btn_close_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btn_update_Click(object sender, EventArgs e)
        {
            using (var unit = new UnitOfWork())
            {
                if (_person is User)
                {
                    if (_action == Action.Add)
                        AddUser(unit);
                    else
                        EditUser(unit);
                }
                else
                {
                    if (_action == Action.Add)
                        AddCustomer(unit);
                    else
                        EditCustomer(unit);
                }

                if (unit.Complete())
                    MetroMessageBox.Show(this, "Saved", "System Message:", MessageBoxButtons.OK, MessageBoxIcon.Information);
                else
                    MetroMessageBox.Show(this, "Not Saved", "System Message:", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

            }

        }

        void AddUser(UnitOfWork unit)
        {
            var newUser = new User
            {
                UserName = txt_username.Text,
                Password = txt_password.Text,
                IsAdmin = false,
                FirstName = txt_firstname.Text,
                LastName = txt_lastname.Text,
                BirthDate = dateTimePicker1.Value,
                Contact = Convert.ToInt32(txt_contact.Text),
                Email = txt_email.Text,
                Gender = (rbMale.Checked) ? "Male" : "Female"
            };

            unit.Users.Add(newUser);

        }

        void AddCustomer(UnitOfWork unit)
        {
            var newCustomer = new Customer
            {
                FirstName = txt_firstname.Text,
                LastName = txt_lastname.Text,
                BirthDate = dateTimePicker1.Value,
                Contact = Convert.ToInt32(txt_contact.Text),
                Email = txt_email.Text,
                Gender = (rbMale.Checked) ? "Male" : "Female"
            };

            unit.Customers.Add(newCustomer);

        }


        void EditUser(UnitOfWork unit)
        {
            var user = GetUser(unit);

            user.UserName = txt_username.Text;
            user.Password = txt_password.Text;

            UpdatePerson(user);

            unit.Users.Update(user);
        }

        int EditCustomer(UnitOfWork unit)
        {
            var customer = GetCustomer(unit);

            UpdatePerson(customer);

            unit.Customers.Update(customer);
            return 0;
        }

        private void UpdatePerson(Person person)
        {
            person.FirstName = txt_firstname.Text;
            person.LastName = txt_lastname.Text;
            person.BirthDate = dateTimePicker1.Value;
            person.Contact = Convert.ToInt32(txt_contact.Text);
            person.Email = txt_email.Text;
            person.Gender = (rbMale.Checked) ? "Male" : "Female";
        }
    }
}
