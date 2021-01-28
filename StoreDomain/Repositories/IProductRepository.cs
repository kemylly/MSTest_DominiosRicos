using System;
using System.Collections.Generic;
using StoreDomain.Entities;

namespace StoreDomain.Repositories
{
    public interface IProductRepository
    {
        IEnumerable<Product> GetProducts(IEnumerable<Guid> ids) ;
        object Get(object p);
    }
}