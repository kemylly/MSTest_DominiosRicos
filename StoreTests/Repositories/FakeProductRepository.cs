using System;
using System.Collections.Generic;
using StoreDomain.Entities;
using StoreDomain.Repositories;

namespace StoreTests.Repositories
{
    public class FakeProductRepository : IProductRepository
    {
        public object Get(object p)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Product> GetProducts(IEnumerable<Guid> ids)
        {
            IList<Product> products = new List<Product> ();
            products.Add(new Product("Produto1", 10, true));
            products.Add(new Product("Produto2", 10, true));
            products.Add(new Product("Produto3", 10, true));
            products.Add(new Product("Produto4", 10, false));
            products.Add(new Product("Produto5", 10, false));

            return products;
        }
    }
}