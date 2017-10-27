using PetWalker.Presentation.Interfaces;
using System;

namespace PetWalker.Presentation.Helpers
{
    public class MenuHelper : IMenuHelper
    {
        public MenuHelper()
        { }

        public string DrawMainMenu()
        {
            Console.WriteLine("Main menu:");
            Console.WriteLine("\t 1. Manage customers");
            Console.WriteLine("\t 2. Manage packs");
            Console.WriteLine("\t 3. Manage schedule");
            Console.WriteLine();
            Console.WriteLine("\t 0. Exit");

            var res = Console.ReadLine();
            while (!res.Equals("0") && !res.Equals("1") && !res.Equals("2") && !res.Equals("3"))
            {
                res = DrawIncorrectInputMessage();
            }
            return res;
        }

        public string DrawCustomerSubMenu()
        {
            Console.WriteLine("Customer management options:");
            Console.WriteLine("\t 1. Get list of customers");
            Console.WriteLine("\t 2. Edit customer");
            Console.WriteLine();
            Console.WriteLine("\t 0. Exit");

            var res = Console.ReadLine();
            while (!res.Equals("0") && !res.Equals("1") && !res.Equals("2"))
            {
                res = DrawIncorrectInputMessage();
            }

            return res;
        }

        public string DrawPacksSubMenu()
        {
            Console.WriteLine("Packs management options:");
            Console.WriteLine("\t 1. Get list of packs");
            Console.WriteLine("\t 2. Edit pack");
            Console.WriteLine();
            Console.WriteLine("\t 0. Exit");

            var res = Console.ReadLine();
            while (!res.Equals("0") && !res.Equals("1") && !res.Equals("2"))
            {
                res = DrawIncorrectInputMessage();
            }

            return res;
        }

        public string DrawScheduleSubMenu()
        {
            Console.WriteLine("Schedule management options:");
            Console.WriteLine("\t 1. Get schedule for current week");
            Console.WriteLine("\t 2. Get day cost");
            Console.WriteLine();
            Console.WriteLine("\t 0. Exit");

            var res = Console.ReadLine();
            while (!res.Equals("0") && !res.Equals("1") && !res.Equals("2"))
            {
                res = DrawIncorrectInputMessage();
            }

            return res;
        }

        private string DrawIncorrectInputMessage()
        {
            Console.WriteLine("Incorrect input! \n Please try again");
            return Console.ReadLine();
        }

    }
}
