using PetWalker.BusinessLogic.BusinessEntities;
using PetWalker.BusinessLogic.Interfaces;
using PetWalker.DataAccess.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace PetWalker.BusinessLogic.Managers
{
    public class PriceManager : IPriceManager
    {
        private IEnumerable<Price> prices;

        private readonly IDatabaseProvider databaseProvider;

        public PriceManager(IDatabaseProvider databaseProvider)
        {
            this.databaseProvider = databaseProvider;
        }

        public void LoadPrices()
        {
            prices = this.databaseProvider.GetPrices();
        }

        public double GetPriceBySizeAndAgression(string size, bool isAgressive)
        {
            var price = prices.FirstOrDefault(x => x.Size == size && x.IsAgressive == isAgressive);

            if (price != null)
                return price.Amount;

            return 0;
        }
    }
}
