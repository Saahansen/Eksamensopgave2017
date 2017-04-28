using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eksamensopgave2017
{
    class Stregsystem : IStregsystem
    {
        public List<User> Userlist = new List<User>();
        public List<Product> ProductList = new List<Product>();
        public List<Transaction> TransactionList = new List<Transaction>();

        public IEnumerable<Product> ActiveProducts
        {
            get
            {
                return ProductList.FindAll(Products => Products.Active);
            }
        }
        

        //laver en instanse af InsertCashTransaction og udfører funktionerne dertil. 
        // Derefter laves en instans af Transaction med data omkring transaktionen som gemmes i transactionlist. 
        public InsertCashTransaction AddCreditsToAccount(User user, int amount)
        {
            InsertCashTransaction Deposit = new InsertCashTransaction(user, amount);
            Deposit.Execute();
            Deposit.ToString();

            Transaction Transaction = new Transaction(user, amount);
            TransactionList.Add(Transaction);
            return Deposit;
        }

        // Samme som ovenfor bare med BuyTransaction. 
        public BuyTransaction BuyProduct(User user, Product product)
        {

            BuyTransaction Purchase = new BuyTransaction(user, product);
            Purchase.Execute();
            Purchase.ToString();

            Transaction Transaction = new Transaction(user, product.Price);
            TransactionList.Add(Transaction);

            return Purchase;
        }

                
        public Product GetProductByID(int productID)
        {
            return ProductList.Find(Product => Product.Id == productID);
        }

        // løkken kører så længe antallet af transaktioner ønsket ikke er opfyldt eller når listen er tom. 
        // Herefter itereres der bagfra for at finde de nyeste transaktioner. 
        // Hvis en transaktions user er den samme som den ønskede så tilføjes transaktionen til den nye liste.  
        // Hvis listen rammer 0 uden at have fundet det ønskede antal bryder while løkken og den nuværende liste returneres. 
        public IEnumerable<Transaction> GetTransactions(User user, int count)
        {
            List<Transaction> FindTransaction = new List<Transaction>();

            while(FindTransaction.Count<count)
            {
                for (int i = TransactionList.Count; i >= 0; i--)
                {
                    if (TransactionList[i].User == user)
                    {
                        FindTransaction.Add(TransactionList[i]);
                    }
                    if (i == 0)
                    {
                        count = 0;
                    }
                }
            }
            return FindTransaction;
        }


        //User GetUser(Func<User, bool> predicate)
        //{
            
        //}
        
        //User GetUserByUsername(string username)
        //{
        //    try
        //    {
        //        return Userlist.Find(User => User.Username == username);
        //    }
        //    catch (NullReferenceException) { /*jeg ved ikke hvordan man gør her*/ }

        //}

        //event UserBalanceNotification UserBalanceWarning;
        


    }
}
