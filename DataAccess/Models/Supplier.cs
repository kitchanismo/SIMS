using System.Collections.Generic;

namespace DataAccess
{
    public class Supplier
    {
        public int SupplierID { get; set; }

        public string Name { get; set; }

        public virtual List<Product> Products { get; set; }
    }
}
