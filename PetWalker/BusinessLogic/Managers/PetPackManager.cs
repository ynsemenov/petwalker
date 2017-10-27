using PetWalker.BusinessLogic.BusinessEntities;
using PetWalker.BusinessLogic.Interfaces;
using PetWalker.DataAccess.Interfaces;
using System.Collections.Generic;

namespace PetWalker.BusinessLogic.Managers
{
    public class PetPackManager : IPetPackManager
    {
        private readonly IDatabaseProvider databaseProvider;

        public PetPackManager(IDatabaseProvider databaseProvider)
        {
            this.databaseProvider = databaseProvider;
        }

        public IEnumerable<PetPack> GetPetPackList()
        {
            return databaseProvider.GetPetPacks();
        }
    }
}
