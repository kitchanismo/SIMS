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
using MetroFramework;
using CapstoneSIMS.Forms;
using System.Collections;
using System.IO;
using System.Drawing.Imaging;
using DataAccess;
using DynamicCard;
using DynamicCard.Styles;

namespace CapstoneSIMS.Usercontrols
{
    public partial class SIMSProduct : UserControl
    {
        public SIMSProduct()
        {
            InitializeComponent();
            InitializeCardEvent();
        }


        private void InitializeCardEvent()
        {
            CardPOS.OnCount += HandlerCounted;
            CardPOS.OnInvalid += HandlerInvalid;
            CardProduct.OnClick += HandleClickOnProduct;
        }

        private void HandlerInvalid(object sender, CardArgs args)
        {
            MessageBox.Show("Not Enough Stock!");
        }

      
        private void HandlerCounted(object sender, CardArgs args)
        {
            DisplayCart();
            lblTotal.Text = Cart.Total.ToString("N");
            lblNoItems.Text = Cart.TotalQuantity.ToString();
        }

   
        private void DisplayCart()
        {
            ListProduct.Rows.Clear();
            foreach (var cart in Cart.List)
            {
                var row = new DataGridViewRow();

                row.CreateCells(ListProduct);

                row.Cells[0].Value = cart.Title;
                row.Cells[1].Value = cart.Price.ToString();
                row.Cells[2].Value = cart.Quantity.ToString();
                row.Cells[3].Value = (cart.Quantity * cart.Price).ToString();

                ListProduct.Rows.Add(row);
            }
        }

        int _id;
        void HandleClickOnProduct(object sender, CardArgs args)
        {
            _id = int.Parse(args.Key);
        }

        private async void SIMSProduct_Load(object sender, EventArgs e)
        {
            await CardPOS.AddRangeAsync<DummyCard>(Cards());

            await CardProduct.AddRangeAsync<DummyCard>(Cards());
        }

        private async void btn_adds_Click(object sender, EventArgs e)
        {
            new ADDProduct().ShowDialog();

            await CardPOS.AddRangeAsync<DummyCard>(Cards());

            await CardProduct.AddRangeAsync<DummyCard>(Cards());
        }

        private List<CardArgs> Cards()
        {
            var cards = new List<CardArgs>();

            using (var unit = new UnitOfWork())
            {
                var products = unit.Products.GetAll();

                foreach (var product in products)
                {
                    cards.Add(new CardArgs
                    {
                        Key       = product.ProductID.ToString(),
                        Title     = product.CodeItem,
                        Price     = product.Price,
                        Subtitle  = product.Price.ToString(),
                        Stock     = product.Quantity,
                        ImagePath = Helper.AppPath + product.Image,
                        Currency  = "Php"
                    });
                }
            }

            return cards;
  
        }


        private async void btn_update_Click(object sender, EventArgs e)
        {
            if (_id == 0)
            {
                MessageBox.Show ("Product Not Selected");
                return;
            }

            new UPDATEProduct(_id).ShowDialog();

            await CardPOS.AddRangeAsync<DummyCard>(Cards());

            await CardProduct.AddRangeAsync<DummyCard>(Cards());

            _id = 0;
        }
    }
}
