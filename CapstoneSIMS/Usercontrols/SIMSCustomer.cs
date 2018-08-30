using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using CapstoneSIMS.Forms;
using DataAccess;

namespace CapstoneSIMS
{
    public partial class SIMSCustomer : UserControl
    {

        public SIMSCustomer()
        {
            InitializeComponent();
            DisplayCustomers();
        }
        
        public void DisplayCustomers()
        {
            using (var unit = new UnitOfWork())
            {
                var customers = unit.Customers.GetAll();

                CustomerData.Rows.Clear();

                foreach (var customer in customers)
                {
                    var row = new DataGridViewRow();

                    row.CreateCells(CustomerData);

                    row.Cells[0].Value = customer.CustomerID;
                    row.Cells[1].Value = customer.LastName + ", " + customer.FirstName;
                    row.Cells[2].Value = (int)(DateTime.Now.Day - customer.BirthDate.Day) / 365;
                    row.Cells[3].Value = customer.Gender;
                    row.Cells[4].Value = customer.Contact;
                    row.Cells[5].Value = customer.Email;

                    CustomerData.Rows.Add(row);
                }

            }
        }
            
        private void CustomerData_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
         
            
        }
        private void btn_add_Click(object sender, EventArgs e)
        {
            var obj = new MaintenancePerson(Action.Add);

            obj.DefineControlVisible(new Customer());

            obj.ShowDialog();

            DisplayCustomers();
        }

        private void btn_edit_Click(object sender, EventArgs e)
        {
            var selectedId =(int)CustomerData.SelectedRows[0].Cells[0].Value;

            var customer = GetCustomer(selectedId);

            var obj = new MaintenancePerson(Action.Edit, customer);

            obj.DefineControlVisible(new Customer());

            obj.ShowDialog();

            DisplayCustomers();
        }

        Customer GetCustomer(int id)
        {
            using (var unit = new UnitOfWork())
            {
                return unit.Customers.Get(c => c.CustomerID == id);
            }
        }

        private void btn_print_Click(object sender, EventArgs e)
        {
            var user = new PRINTUser();
            user.ShowDialog();
        }

        private void CustomerData_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
