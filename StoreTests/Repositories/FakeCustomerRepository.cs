using StoreDomain.Entities;
using StoreDomain.Repositories;

namespace StoreTests.Repositories
{
    public class FakeCustomerRepository : ICustomerRepository
    {
        public Customer Get(string document)
        {
           if (document == "12345678912")
                return new Customer("Diana Prince", "diana@gmail.com");

            return null;
        }
    }
}