using PetWalker.BusinessLogic.BusinessEntities;
using PetWalker.BusinessLogic.Interfaces;
using PetWalker.DataAccess.Interfaces;
using System.Collections.Generic;

namespace PetWalker.BusinessLogic.Managers
{
    public class PetManager : IPetManager
    {
        private readonly IDatabaseProvider databaseProvider;

        public PetManager(IDatabaseProvider databaseProvider)
        {
            this.databaseProvider = databaseProvider;
        }

        public IEnumerable<Pet> GetPetsByPackId(long packId)
        {
            return databaseProvider.GetPetsByPackId(packId);
        }
    }
}
