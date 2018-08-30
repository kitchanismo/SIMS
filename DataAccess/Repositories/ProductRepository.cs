using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class ProductRepository : Repository<Product>
    {
        public ProductRepository(DbContext context)
            : base(context)
        {

        }

        public string[] GetCodeItem()
        {
            return AppDbContext.Products.Select(p => p.CodeItem).ToArray();
        }
 
        private AppDbContext AppDbContext
        {
            get { return Context as AppDbContext; }
        }


    }
}
