using PetWalker.BusinessLogic.BusinessEntities;
using PetWalker.BusinessLogic.Interfaces;
using PetWalker.DataAccess.Interfaces;
using PetWalker.DataAccess.Providers;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PetWalker.BusinessLogic.Managers
{
    public class BusinessLogicManager : IBusinessLogicManager
    {
        private ICustomerManager customerManager;
        private IPetPackManager petPackManager;
        private IPetWalkManager petWalkManager;
        private IPetManager petManager;
        private IPriceManager priceManager;        

        public BusinessLogicManager(ICustomerManager customerManager
            , IPetPackManager petPackManager
            , IPetWalkManager petWalkManager
            , IPetManager petManager
            , IPriceManager priceManager)
        {
            this.customerManager = customerManager;
            this.petPackManager = petPackManager;
            this.petWalkManager = petWalkManager;
            this.petManager = petManager;
            this.priceManager = priceManager;            
        }

        public BusinessLogicManager()
        {
            var databaseProvider = new DatabaseProvider();
            this.customerManager = new CustomerManager(databaseProvider);
            this.petPackManager = new PetPackManager(databaseProvider);
            this.petWalkManager = new PetWalkManager(databaseProvider);
            this.petManager = new PetManager(databaseProvider);
            this.priceManager = new PriceManager(databaseProvider);
        }

        public IEnumerable<Customer> GetCustomerList()
        {
            return customerManager.GetCustomerList();
        }

        public IEnumerable<PetPack> GetPetPackList()
        {
            return petPackManager.GetPetPackList();
        }

        public double GetDateCost(DateTime date)
        {
            double res = 0;
            var walks = petWalkManager.GetPetWalkListForDate(date);

            if (walks.Count() == 0)
                return 0;

            priceManager.LoadPrices();
            foreach (var walk in walks)
            {
                if (walk.Pet != null)
                    res += priceManager.GetPriceBySizeAndAgression(walk.Pet.Size, walk.Pet.IsAgressive);

                if (walk.PetPack != null)
                {
                    var pets = walk.PetPack.Pets;

                    if (pets == null)
                    {
                        pets = petManager.GetPetsByPackId(walk.PetPack.Id);
                    }

                    foreach (var pet in pets)
                    {
                        res += priceManager.GetPriceBySizeAndAgression(pet.Size, pet.IsAgressive);
                    }
                }
            }
            return res;
        }

        public IEnumerable<PetWalk> GetPetWalkList(DateTime startDate, DateTime endDate)
        {
            return petWalkManager.GetPetWalkListForDateRange(startDate, endDate);
        }
    }
}
