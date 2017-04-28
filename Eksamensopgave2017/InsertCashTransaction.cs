using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eksamensopgave2017
{
    public class InsertCashTransaction : Transaction
    {
        public InsertCashTransaction(User user, decimal amount) : base (user, amount) 
        {
            User = user;
            Amount = amount;
        }
        
        public override string ToString()
        {
            return $"Dette er en indbetaling på {User.FullName}'s konto. Beløbet er på {Amount} og den nye saldo er: {User.Balance}. Transaktionens ID: {Id}.";
        }
        public override void Execute()
        {
            User.Balance += Amount;
        }
       
    }
}
