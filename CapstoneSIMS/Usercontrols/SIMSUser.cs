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
    public partial class SIMSUser : UserControl
    {

        public SIMSUser()
        {
            InitializeComponent();
            DisplayUsers();
        }
        
        public void DisplayUsers()
        {
            using (var unit = new UnitOfWork())
            {
                var users = unit.Users.GetAll();

                UserData.Rows.Clear();

                foreach (var user in users)
                {
                    var row = new DataGridViewRow();

                    row.CreateCells(UserData);

                    row.Cells[0].Value = user.UserID;
                    row.Cells[1].Value = user.UserName;
                    row.Cells[2].Value = user.LastName + ", " + user.FirstName;
                    row.Cells[3].Value = (int) (DateTime.Now.Subtract(user.BirthDate).TotalDays) / 365;
                    row.Cells[4].Value = user.Gender;
                    row.Cells[5].Value = user.Contact;
                    row.Cells[6].Value = user.Email;

                    UserData.Rows.Add(row);
                }

            }
        }
            
        private void CustomerData_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
         
            
        }
        private void btn_add_Click(object sender, EventArgs e)
        {
            var obj = new MaintenancePerson(Action.Add);

            obj.DefineControlVisible(new User());

            obj.ShowDialog();

            DisplayUsers();
        }

        private void btn_edit_Click(object sender, EventArgs e)
        {
            var selectedId =(int)UserData.SelectedRows[0].Cells[0].Value;

            var user = GetUser(selectedId);

            var obj = new MaintenancePerson(Action.Edit, user);

            obj.DefineControlVisible(new User());

            obj.ShowDialog();

            DisplayUsers();
        }

        User GetUser(int id)
        {
            using (var unit = new UnitOfWork())
            {
                return unit.Users.Get(u => u.UserID == id);
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
