using Microsoft.EntityFrameworkCore;

namespace RabbitMqSamples.RPC.Server.Models
{
    public class CustomerRepository
    {
        private readonly CustomerDbContext _context;

        public CustomerRepository()
        {
            _context = new CustomerDbContext();
        }
        public Customer GetById(int id)
        {
            return _context.Customers.AsNoTracking().FirstOrDefault(w=>w.CustomerId==id);
        }
    }
}
