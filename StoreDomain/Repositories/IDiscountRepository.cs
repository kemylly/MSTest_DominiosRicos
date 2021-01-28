using StoreDomain.Entities;

namespace StoreDomain.Repositories
{
    public interface IDiscountRepository
    {
        Discount Get(string code);
    }
}