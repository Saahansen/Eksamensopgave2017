using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eksamensopgave2017
{
    public class Transaction
    {
        static int NextId;
        public int Id;
        public User User { get; set; }
        public DateTime Date { get; set; }
        public virtual decimal Amount { get; set; }
        public override string ToString()
        {
            return $"Denne transaktion fandt sted: {DateTime.Now}. Brugeren var {User}, beløbet var {Amount} og ID er: {Id}";
        }
        public virtual void Execute() { }



        public Transaction(User user, decimal amount)
        {
            User = user;
            Id = _getId();
            Date = DateTime.Now;
            Amount = amount;
        }


        
        private int _getId()
        {
            NextId++;
            return NextId;
        } 
    }
}
