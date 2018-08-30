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
using CapstoneSIMS.Usercontrols;
using MetroFramework;
using DataAccess;

namespace CapstoneSIMS
{
    public partial class SIMSLogin : UserControl
    {
        int _trial;

        public SIMSLogin()
        {
            InitializeComponent();
        }

        private void btn_login_Click(object sender, EventArgs e)
        {
            using (var unit = new UnitOfWork())
            {
               
                if (_trial >= 3)
                {
                    MessageBox.Show("Trial ends");
                    return;
                }

                bool isAuthentic = unit.Users.IsAuthentic(txt_username.Text, txt_password.Text);

                if (!isAuthentic)
                {
                    MessageBox.Show("Incorrect Username/Password");
                    _trial++;
                    return;
                }

                var obj = new SIMSMain
                {
                    Dock = DockStyle.Fill
                };
                this.Hide();
                this.Parent.Controls.Add(obj);
            }

           
         
        }

        private void LoginAttempstimeOut_Tick(object sender, EventArgs e)
        {
            LoginAttempstimeOut.Stop();
            txt_username.Enabled = true;
            txt_password.Enabled = true;
            btn_login.Enabled = true;
            _trial = 0;
        }
    }
}
