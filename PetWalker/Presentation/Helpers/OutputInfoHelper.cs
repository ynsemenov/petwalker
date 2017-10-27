using PetWalker.BusinessLogic.BusinessEntities;
using PetWalker.Presentation.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PetWalker.Presentation.Helpers
{
    public class OutputInfoHelper : IOutputInfoHelper
    {
        public void OutputCustomerList(IEnumerable<Customer> customers)
        {
            if (customers == null || customers.Count() == 0)
            {
                Console.WriteLine("Customer list is empty");
                return;
            }

            foreach (var customer in customers)
            {
                Console.WriteLine("Customer {0}:", customer.Name);
                Console.WriteLine("\t Address - {0}", customer.Address);
                Console.WriteLine("\t Dogs: ");
                OutputPetList(customer.Pets);
            }
        }
        public void OutputPetPackList(IEnumerable<PetPack> petPacks)
        {
            if (petPacks == null || petPacks.Count() == 0)
            {
                Console.WriteLine("\t Dog pack list is empty");
                return;
            }

            foreach (var petPack in petPacks)
            {
                OutputPetPackInfo(petPack);
            }
        }

        public void OutputPetWalkList(IEnumerable<PetWalk> walks)
        {
            if (walks == null || walks.Count() == 0)
            {
                Console.WriteLine("Walks list is empty");
                return;
            }

            foreach (var walk in walks)
            {
                Console.WriteLine("Walk - {0}", walk.Name);
                Console.WriteLine("\t DayOfWeek - {0}", walk.WalkDate.DayOfWeek);
                Console.WriteLine("\t Time - {0}", walk.WalkDate.TimeOfDay);

                if (walk.Pet != null)
                {
                    Console.WriteLine("\t Dog:");
                    OutputPetInfo(walk.Pet);
                }

                if (walk.PetPack != null)
                {
                    Console.WriteLine("\t Pack - {0}", walk.PetPack.Name);
                }

                Console.WriteLine();
            }
        }

        public void OutputDayCost(DayOfWeek dayOfWeek, double cost)
        {
            Console.WriteLine("The cost of {0} is {1}", dayOfWeek, cost);
        }

        private void OutputPetPackInfo(PetPack petPack)
        {
            Console.WriteLine("Pack {0}:", petPack.Name);
            Console.WriteLine("\t Dogs: ");
            OutputPetList(petPack.Pets);
        }

        private void OutputPetList(IEnumerable<Pet> pets)
        {
            if (pets == null || pets.Count() == 0)
            {
                Console.WriteLine("\t\t Dog list is empty");
                return;
            }

            foreach (var pet in pets)
            {
                OutputPetInfo(pet);
            }

        }

        private void OutputPetInfo(Pet pet)
        {
            Console.WriteLine("\t\t Name - {0}", pet.Name);
            Console.WriteLine("\t\t Size - {0}", pet.Size);
            Console.WriteLine("\t\t Agressive - {0}", pet.IsAgressive ? "Yes" : "No");
            Console.WriteLine();
        }
    }
}
