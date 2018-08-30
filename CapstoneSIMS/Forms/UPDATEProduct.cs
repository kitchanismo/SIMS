using CapstoneSIMS.Usercontrols;
using DataAccess;
using MetroFramework;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CapstoneSIMS
{
    public partial class UPDATEProduct : Form
    {
        
    
        private int _id;

        public UPDATEProduct(int id)
        {

            InitializeComponent();

            _id = id;

            DisplayProduct();
        }

        public void DisplayProduct()
        {
            using (var unit = new UnitOfWork())
            {
                var product = unit.Products.Get(p => p.ProductID == _id);

                if (product is null)
                    throw new Exception("Product not found");

               
                txt_id.Text               = product.ProductID.ToString();
                txt_code.Text             = product.CodeItem;
                txt_item.Text             = product.Description;
                txt_quantity.Text         = product.Quantity.ToString();
                txt_cost.Text             = product.Price.ToString();
                txt_date.Text             = product.DatePurchased.ToString();
                cbox_supplier.Text        = product.Supplier.Name;
                txt_path.Text             = product.Image;
                pictureBox1.ImageLocation = Helper.AppPath + product.Image;

                opnfd.FileName = Helper.AppPath + txt_path.Text;

            }
        }


        private void btn_update_Click(object sender, EventArgs e)
        {
            using (var unit = new UnitOfWork())
            {
                var updatedProduct = unit.Products.Get(p => p.ProductID == _id);

                updatedProduct.CodeItem      = txt_code.Text;
                updatedProduct.Description   = txt_item.Text;
                updatedProduct.Image         = txt_path.Text;
                updatedProduct.Price         = Convert.ToDouble(txt_cost.Text);
                updatedProduct.Quantity      = Convert.ToInt32(txt_quantity.Text);
                updatedProduct.DatePurchased = txt_date.Value;
                CheckSupplierIfExist(updatedProduct, unit);

                new Bitmap(Helper.AppPath + txt_path.Text).Save(opnfd.SafeFileName);

                unit.Products.Update(updatedProduct);

                if (unit.Complete())
                    MetroMessageBox.Show(this, "Updated", "System Message:", MessageBoxButtons.OK, MessageBoxIcon.Information);
                else
                    MetroMessageBox.Show(this, "Not Updated", "System Message:", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

            }
        }

        private void CheckSupplierIfExist(Product product, UnitOfWork unit)
        {
            var _product = unit.Products
                .Get(p => p.Supplier.Name.ToLower() == cbox_supplier.Text.ToLower());

            if (_product != null)
                product.Supplier = _product.Supplier;
            else
                product.Supplier = new Supplier { Name = cbox_supplier.Text };

        }

        OpenFileDialog opnfd = new OpenFileDialog();
        private void btn_upload_Click(object sender, EventArgs e)
        {
            opnfd.Filter = "Image Files (*.jpg;*.jpeg;.*.gif;*.png;)|*.jpg;*.jpeg;.*.png;*.gif";
            opnfd.Title = "Select Item";

            if (opnfd.ShowDialog() == DialogResult.OK)
            {
                txt_path.Text           = opnfd.SafeFileName;
                pictureBox1.SizeMode    = PictureBoxSizeMode.StretchImage;
                pictureBox1.ImageLocation = opnfd.FileName;
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
    }
}
