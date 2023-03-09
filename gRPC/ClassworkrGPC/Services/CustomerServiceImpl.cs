using ClassworkrGPC.DataAccess;
using Grpc.Core;
using Microsoft.EntityFrameworkCore;

namespace ClassworkrGPC.Services
{
    public class CustomerServiceImpl : CustomerService.CustomerServiceBase
    {
        //inject NorthwindDbContext
        private readonly NorthwindContext _context;
        public CustomerServiceImpl(NorthwindContext context)
        {
            _context = context;
        }

        public override async Task<GetCustomersResponse> GetCustomers(GetCustomersRequest request, ServerCallContext context)
        {
            var customers = await _context.Customers.ToListAsync();

            var response = new GetCustomersResponse();

            response.Customers.AddRange(customers.Select(c => new Customer
            {
                ID = c.CustomerId,
                CompanyName = c.CompanyName ?? "",
                ContactName = c.ContactName ?? "",
                ContactTitle = c.ContactTitle ?? "",
                Address = c.Address ?? "",
                City = c.City ?? "",
                Region = c.Region ?? "",
                PostalCode = c.PostalCode ?? "",
                Country = c.Country ?? "",
                Phone = c.Phone ?? "",
                Fax = c.Fax ?? ""
            }));
            return response;
        }
    }
}
