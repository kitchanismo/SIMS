using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class Product
    {
        public int ProductID { get; set; }

        public string CodeItem { get; set; }

        public string Description { get; set; }

        public int Quantity { get; set; }

        public double Price { get; set; }

        public string Image { get; set; }

        public DateTime DatePurchased { get; set; }

        public int SupplierID { get; set; }

        public virtual Supplier Supplier { get; set; }
    }
}
