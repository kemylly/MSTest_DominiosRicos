using System;
using StoreDomain.Entities;
using StoreDomain.Repositories;

namespace StoreTests.Repositories
{
    public class FakeDiscountRepository : IDiscountRepository
    {
        public Discount Get(string code)
        {
            if (code == "12345678")
                return new Discount(10, DateTime.Now.AddDays(5));

            if (code == "87654321")
                return new Discount(10, DateTime.Now.AddDays(-5));

            return null;
        }
    }
}