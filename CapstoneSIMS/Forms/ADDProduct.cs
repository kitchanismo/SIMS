using CapstoneSIMS.Usercontrols;
using DataAccess;
using MetroFramework;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CapstoneSIMS
{
    public partial class ADDProduct : Form
    {
      
        public ADDProduct()
        {
            InitializeComponent();
        }

        private void btn_add_Click(object sender, EventArgs e)
        {
            using (var unit = new UnitOfWork())
            {


                var product = new Product
                {
                     CodeItem      = txt_code.Text,
                     Description   = txt_Description.Text,
                     Price         = Convert.ToDouble(txt_cost.Text),
                     Quantity      = Convert.ToInt32(txt_quantity.Text),
                     Image         = opnfd.SafeFileName,
                     Supplier      = new Supplier { Name = cbox_supplier.Text },
                     DatePurchased = DateTime.Now
                };

                new Bitmap(opnfd.FileName).Save(Helper.AppPath + opnfd.SafeFileName);


                unit.Products.Add(product);

     
                if (unit.Complete())
                    MetroMessageBox.Show(this, "Saved", "System Message:", MessageBoxButtons.OK, MessageBoxIcon.Information);
                else
                    MetroMessageBox.Show(this, "Not Saved", "System Message:", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);


            }

        }

        private void btn_close_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void txt_code_KeyPress(object sender, KeyPressEventArgs e)
        {
            Helper.LetterOnly(e);

        }
        private void txt_item_KeyPress(object sender, KeyPressEventArgs e)
        {
            Helper.LetterOnly(e);
        }

        private void txt_quantity_KeyPress(object sender, KeyPressEventArgs e)
        {
            txt_quantity.MaxLength = 10;
            Helper.NumberOnly(e);
        }


        private void txt_cost_KeyPress(object sender, KeyPressEventArgs e)
        { 
            Helper.NumberOnly(e);
        }

        OpenFileDialog opnfd  = new OpenFileDialog();

        private void btn_upload_Click(object sender, EventArgs e)
        {
            opnfd.Filter = "Image Files (*.jpg;*.jpeg;.*.gif;*.png;)|*.jpg;*.jpeg;.*.png;*.gif";
            opnfd.Title = "Select Item";

            if (opnfd.ShowDialog() == DialogResult.OK)
            {
                var path = opnfd.FileName.ToString();
                txt_path.Text = path;
                pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
                pictureBox1.Image = Image.FromFile(opnfd.FileName);

            }
        }
    }   
}
