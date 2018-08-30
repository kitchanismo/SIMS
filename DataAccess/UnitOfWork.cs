using System;

namespace DataAccess
{
    public class UnitOfWork : IDisposable
    {
        private  readonly AppDbContext _context;

        public UnitOfWork()
        {
            _context = new AppDbContext();
            Products = new ProductRepository(_context);
            Users    = new UserRepository(_context);
            Customers = new CustomerRepository(_context);
        } 

        public ProductRepository Products { get; set; }

        public UserRepository Users { get; set; }

        public CustomerRepository Customers { get; set; }

        public bool Complete()
        {
            return _context.SaveChanges() > 0;
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }

}
