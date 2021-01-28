using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using StoreDomain.Entities;
using StoreDomain.Enums;

namespace StoreTests.Entities
{
    [TestClass]
    public class OrderTests
    {
        private readonly Customer _customer;
        private readonly Product _product;
        private readonly Discount _discount;
        private readonly Order _order;
        public OrderTests()
        {
            _customer = new Customer("Yona", "yona@gmail.com");
            _product = new Product("Produto1", 10, true);
            _discount = new Discount(10, DateTime.Now.AddDays(5));
            _order = new Order(_customer, 0, null);
        }

        [TestMethod]
        [TestCategory("Domain")]
        public void Dado_um_novo_pedido_valido_ele_deve_gerar_um_numero_com_8_caracteres()
        {
            Assert.AreEqual(8, _order.Number.Length);
        }

        [TestMethod]
        [TestCategory("Domain")]
        public void Dado_um_novo_pedidio_seu_status_deve_ser_aguardando_pagamento()
        {
            Assert.AreEqual(_order.Status, EOrderStatus.WaitingPayment);
        }

        [TestMethod]
        [TestCategory("Domain")]
        public void Dado_um_pagamento_do_pedido_seu_status_deve_ser_aguardando_entrega()
        {
            _order.AddItem(_product, 1);  //adicionar item
            _order.Pay(10);  //pagar
            Assert.AreEqual(_order.Status, EOrderStatus.WaitingDelivery);
        }

        [TestMethod]
        [TestCategory("Domain")]
        public void Dado_um_pedido_cancelado_seu_status_deve_ser_cancelado()
        {
            _order.Cancel();
            Assert.AreEqual(_order.Status, EOrderStatus.Canceled);
        }

        [TestMethod]
        [TestCategory("Domain")] 
        public void Dado_um_novo_item_sem_produto_o_mesmo_nao_deve_ser_adicionado()
        {
            _order.AddItem(null, 12);
            Assert.AreEqual(_order.Items.Count, 0);
        }

        [TestMethod]
        [TestCategory("Domain")] 
        public void Dado_um_novo_item_com_quantidade_zero_ou_menor_o_mesmo_nao_deve_ser_adicionado()
        {
            _order.AddItem(_product, 0);
            Assert.AreEqual(_order.Items.Count, 0);
        }

        [TestMethod]
        [TestCategory("Domain")] 
        public void Dado_um_novo_pedidio_valido_seu_total_deve_ser_50()
        {
            var order = new Order(_customer, 10, _discount);  //frete 10 - desconto de 10 == pedidio começa 0
            order.AddItem(_product, 5);  //10 * 5 == 50
            Assert.AreEqual(order.Total(), 50);  //comparar com 50
        }

        [TestMethod]
        [TestCategory("Domain")] 
        public void Dado_um_desconto_expirado_o_valor_do_pedido_deve_ser_60()
        {
            var expiredDiscount = new Discount(10, DateTime.Now.AddDays(-5));  //criar um upom expirado  => 0
            var order = new Order(_customer, 10, expiredDiscount);  //criei um pedido com cupom expirado => 10 + 0
            order.AddItem(_product, 5); //adicionei produtos nesse pedido  => 10*5 = 50  => 50 + 10 + 0
            Assert.AreEqual(order.Total(), 60);  //comprar se o total do peido etá igual a 60, pois não é para ter disconto
        }

        [TestMethod]
        [TestCategory("Domain")]
        public void Dado_um_desconto_invalido_o_valor_do_pedido_deve_ser_60()
        {
            var order = new Order(_customer, 10, null); //pasar um desconto nulo
            order.AddItem(_product, 5);
            Assert.AreEqual(order.Total(), 60);
        }

        [TestMethod]
        [TestCategory("Domain")]
        public void Dado_um_desconto_de_10_o_valor_do_pedido_deve_ser_50()
        {
            var order = new Order(_customer, 10, _discount);
            order.AddItem(_product, 5);
            Assert.AreEqual(order.Total(), 50);
        }

        [TestMethod]
        [TestCategory("Domain")]
        public void Dado_uma_taxa_de_entrega_de_10_o_valor_do_pedido_deve_ser_60()
        {
            var order = new Order(_customer, 10, _discount);  //posso passar sem desconto tambem, que tambem da o valor
            order.AddItem(_product, 6);  //calculando o produto
            Assert.AreEqual(order.Total(), 60);
        }

        [TestMethod]
        [TestCategory("Domain")]
        public void Dado_um_pedido_sem_cliente_o_mesmo_deve_ser_invalido()
        {
            var order = new Order(null, 10, _discount);  //passando um pedidio sem cliente
            order.AddItem(_product, 6);  //calculo normal
            Assert.AreEqual(order.Valid, false);  //comparando se o cliente esta invalido
        }
    }
}