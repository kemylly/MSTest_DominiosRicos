using System;
using Flunt.Notifications;
using Flunt.Validations;
using StoreDomain.Commands.Interfaces;
using System.Collections.Generic;

namespace StoreDomain.Commands
{
    public class CreateOrderCommand : Notifiable, ICommand
    {
        public CreateOrderCommand()
        {
            Items = new List<CreateOrderItemCommand>();
        }

        public CreateOrderCommand(string customer, string zipCode, string promoCode, IList<CreateOrderItemCommand> items)
        {
            Customer = customer;
            ZipCode = zipCode;
            PromoCode = promoCode;
            Items = items;
        }

        public string Customer { get; set; }
        public string ZipCode { get; set; }
        public string PromoCode { get; set; }
        public IList<CreateOrderItemCommand> Items { get; set; }

        public void Validate()
        {
            AddNotifications(new Contract()
                .Requires()
                .HasLen(Customer, 11, "Customer", "Cliente invalido")
                .HasLen(ZipCode, 8, "ZipCode", "CEP invalido")
            );
        }
    }
}