using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using System.Threading;

namespace CapstoneSIMS.Usercontrols
{
    public partial class SIMSMain : UserControl
    {
        public SIMSMain()
        {

            
            InitializeComponent();
           
            btn_dashboard.FlatStyle = FlatStyle.Flat;
            btn_dashboard.FlatAppearance.BorderSize = 0;
            btn_products.FlatStyle = FlatStyle.Flat;
            btn_products.FlatAppearance.BorderSize = 0;
            btn_customer.FlatStyle = FlatStyle.Flat;
            btn_customer.FlatAppearance.BorderSize = 0;
            btn_sales.FlatStyle = FlatStyle.Flat;
            btn_sales.FlatAppearance.BorderSize = 0;
            btn_inventory.FlatStyle = FlatStyle.Flat;
            btn_inventory.FlatAppearance.BorderSize = 0;
            btn_settings.FlatStyle = FlatStyle.Flat;
            btn_settings.FlatAppearance.BorderSize = 0;

        }
    
        private void btn_dashboard_Click(object sender, EventArgs e)
        {
            panel3.Controls.Clear();
            btn_dashboard.BackColor = Color.FromArgb(7, 87, 91);
            btn_products.BackColor = Color.FromArgb(62, 62, 62);
            btn_customer.BackColor = Color.FromArgb(62, 62, 62);
            btn_sales.BackColor = Color.FromArgb(62, 62, 62);
            btn_inventory.BackColor = Color.FromArgb(62, 62, 62);
            btn_settings.BackColor = Color.FromArgb(62, 62, 62);
        }
        private void btn_products_Click(object sender, EventArgs e)
        {
            var obj = new SIMSProduct();
            obj.Dock = DockStyle.Fill;
            panel3.Controls.Clear();
            panel3.Controls.Add(obj);

           
           
            btn_products.BackColor = Color.FromArgb(7, 87, 91);
            btn_dashboard.BackColor = Color.FromArgb(62, 62, 62);
            btn_customer.BackColor = Color.FromArgb(62, 62, 62);
            btn_sales.BackColor = Color.FromArgb(62, 62, 62);
            btn_inventory.BackColor = Color.FromArgb(62, 62, 62);
            btn_settings.BackColor = Color.FromArgb(62, 62, 62);
        }

        private void btn_customer_Click(object sender, EventArgs e)
        {
            var obj = new SIMSCustomer();
            obj.Dock = DockStyle.Fill;
            panel3.Controls.Clear();
            panel3.Controls.Add(obj);
      
            btn_customer.BackColor = Color.FromArgb(7, 87, 91);
            btn_products.BackColor = Color.FromArgb(62, 62, 62);
            btn_dashboard.BackColor = Color.FromArgb(62, 62, 62);
            btn_sales.BackColor = Color.FromArgb(62, 62, 62);
            btn_inventory.BackColor = Color.FromArgb(62, 62, 62);
            btn_settings.BackColor = Color.FromArgb(62, 62, 62);
        }

        private void btn_sales_Click(object sender, EventArgs e)
        {
            var obj = new SIMSReport();
            obj.Dock = DockStyle.Fill;
            panel3.Controls.Clear();
            panel3.Controls.Add(obj);

            btn_sales.BackColor = Color.FromArgb(7, 87, 91);
            btn_dashboard.BackColor = Color.FromArgb(62, 62, 62);
            btn_products.BackColor = Color.FromArgb(62, 62, 62);
            btn_customer.BackColor = Color.FromArgb(62, 62, 62);
            btn_inventory.BackColor = Color.FromArgb(62,62,62);
            btn_settings.BackColor = Color.FromArgb(62, 62, 62);
        }

        private void btn_inventory_Click(object sender, EventArgs e)
        {
            btn_inventory.BackColor = Color.FromArgb(7, 87, 91);
            btn_dashboard.BackColor = Color.FromArgb(62, 62, 62);
            btn_products.BackColor = Color.FromArgb(62, 62, 62);
            btn_customer.BackColor = Color.FromArgb(62, 62, 62);
            btn_sales.BackColor = Color.FromArgb(62, 62, 62);
            btn_settings.BackColor = Color.FromArgb(62,62,62);
        }

        private void btn_settings_Click(object sender, EventArgs e)
        {
            btn_settings.BackColor = Color.FromArgb(7, 87, 91);
            btn_dashboard.BackColor = Color.FromArgb(62, 62, 62);
            btn_products.BackColor = Color.FromArgb(62, 62, 62);
            btn_customer.BackColor = Color.FromArgb(62, 62, 62);
            btn_sales.BackColor = Color.FromArgb(62, 62, 62);
            btn_inventory.BackColor = Color.FromArgb(62, 62, 62);
        }

        private void btnUser_Click(object sender, EventArgs e)
        {

            var obj = new SIMSUser();
            obj.Dock = DockStyle.Fill;
            panel3.Controls.Clear();
            panel3.Controls.Add(obj);

            btn_customer.BackColor = Color.FromArgb(7, 87, 91);
            btn_products.BackColor = Color.FromArgb(62, 62, 62);
            btn_dashboard.BackColor = Color.FromArgb(62, 62, 62);
            btn_sales.BackColor = Color.FromArgb(62, 62, 62);
            btn_inventory.BackColor = Color.FromArgb(62, 62, 62);
            btn_settings.BackColor = Color.FromArgb(62, 62, 62);
        }
    }
    }

