using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using StoreDomain.Entities;
using StoreDomain.Queries;
using StoreDomain.Repositories;

namespace StoreTests.Queries
{
    [TestClass]
    public class ProductQueriesTests
    {
        private IList<Product> _products;
        public ProductQueriesTests()
        {
            _products = new List<Product>();
            _products.Add(new Product("Produto1", 10, true));
            _products.Add(new Product("Produto2", 20, true));
            _products.Add(new Product("Produto3", 30, true));
            _products.Add(new Product("Produto4", 40, false));
            _products.Add(new Product("Produto5", 50, false));
        }

        [TestMethod]
        [TestCategory("Queries")]
        public void Dado_a_consulta_de_produtos_ativos_deve_retornar_3()
        {
            var result = _products.AsQueryable().Where(ProductQueries.GetActiveProducts());
            Assert.AreEqual(result.Count(), 3);
        }

        [TestMethod]
        [TestCategory("Queries")]
        public void Dado_a_consulta_de_produtos_inativos_deve_retornar_2()
        {
            var result = _products.AsQueryable().Where(ProductQueries.GetInactiveProducts());
            Assert.AreEqual(result.Count(), 2);
        }
    }
}