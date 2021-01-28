namespace StoreDomain.Repositories
{
    public interface IDeliveryFeeRepository
    {
         decimal Get(string document);
    }
}