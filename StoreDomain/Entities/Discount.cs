using System;

namespace StoreDomain.Entities
{
    public class Discount : Entity
    {
        public Discount(decimal amount, DateTime expireDate)
        {
            Amount = amount;
            ExpireDate = expireDate;
        }

        public decimal Amount { get; private set; }
        public DateTime ExpireDate { get; private set; }

        public bool IsValid()  //verificar se o cupom está valido ou não, se a fat esta valido
        {
            return DateTime.Compare(DateTime.Now, ExpireDate) < 0;
        }

        public decimal Value()  //verificando o cupom
        {
            if(IsValid())
                return Amount;
            else
                return 0;
        }
    }
}