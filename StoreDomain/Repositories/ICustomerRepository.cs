using StoreDomain.Entities;

namespace StoreDomain.Repositories
{
    public interface ICustomerRepository
    {
        Customer Get(string document);
    }
}