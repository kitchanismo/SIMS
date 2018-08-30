using System.Data.Entity;

namespace DataAccess
{
    public class CustomerRepository : Repository<Customer>
    {
        public CustomerRepository(DbContext context)
            : base(context)
        {

        }
       

        private AppDbContext AppDbContext
        {
            get { return Context as AppDbContext; }
        }


    }
}
