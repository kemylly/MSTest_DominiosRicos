using StoreDomain.Entities;

namespace StoreDomain.Repositories
{
    public interface IOrderRepository
    {
        void Save(Order order);
    }
}