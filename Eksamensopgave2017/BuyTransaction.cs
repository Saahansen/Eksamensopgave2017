using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Eksamensopgave2017
{
    public class BuyTransaction : Transaction
    {
        public Product Product { get; set; }
        //amount bruges ikke til noget
        public BuyTransaction(User user, Product product, [Optional] decimal amount) : base (user, amount)
        {
            User = user;
            Product = product;
        }

        public override string ToString()
        {
            return $"Dette er et køb af {Product.Name} som koster {Amount} kr. Beløbet bliver trukket fra {User.FullName}'s konto. Købet skete den. {DateTime.Now} og har transaktionsid: {Id}";
        }


        public override void Execute()
        {
            if (!Product.CanBeBoughtOnCredit)
            {
                if (Amount > User.Balance)
                { throw new Exception(); /*insufficientCreditsException(/*her skal den så køre displayinsuficientcash*/}
            }
            User.Balance = User.Balance - Amount;
        }


        public override decimal Amount
        {
            get
            {
                return Product.Price;
            }
        }
    }
}
