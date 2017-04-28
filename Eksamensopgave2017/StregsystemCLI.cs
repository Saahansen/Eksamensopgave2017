using System;
using System.Collections.Generic;

namespace Eksamensopgave2017
{
    class StregsystemCLI : IStregsystemUI
    {
        public StregsystemCLI(IStregsystem stregsystem)
        {
            throw new NotImplementedException();
        }


        public void DisplayUserNotFound(string username)
        {
            Console.WriteLine($"Brugeren: {username} kunne ikke findes");
        }
        
        public void DisplayProductNotFound(string product)
        {
            Console.WriteLine($"Produktet {product} kunne ikke findes");
        }

        public void DisplayUserInfo(User user)
        {
            user.ToString();
        }
        
        public void DisplayTooManyArgumentsError(string command)
        {
            Console.WriteLine("Jeg ved slet ikke hvad der menes med den her fejl. og hvad helvede er command for en størrelse");
        }
        
        public void DisplayAdminCommandNotFoundMessage(string adminCommand)
        {
            Console.WriteLine($"Følgende er ikke en admin command: {adminCommand}");
        }

        public void DisplayUserBuysProduct(BuyTransaction transaction)
        {
            transaction.ToString();
        }

        public void DisplayUserBuysProduct(int count, BuyTransaction transaction)
        {
            //hvad skal den gøre?
        }

        public void Close() { }

        public void DisplayInsufficientCash(User user, Product product)
        {
            Console.WriteLine($"Der er ikke penge nok på {user.FullName}'s konto til at købe {product.Name}");
        }

        public void DisplayGeneralError(string errorString)
        {
            Console.WriteLine("Hov, der skete en fejl");
        }

        //event StregsystemEvent CommandEntered;
        public void Start()
        {
            
        }
    }
}