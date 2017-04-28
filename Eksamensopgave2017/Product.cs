using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eksamensopgave2017
{
    public class Product
    {
        private int _id;
        public int Id
        {
            get { return _id; }
            set
            {
                if (value < 1)
                    { throw new Exception(); }
                else
                    { _id = value; }
                 
            }
        }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public bool Active { get; set; }
        public bool CanBeBoughtOnCredit { get; set; }

        public override string ToString()
        {
            return $"Id: {Id} Name: {Name} Price: {Price}";
        }

        public Product()
        {
               
        }
    }
}
