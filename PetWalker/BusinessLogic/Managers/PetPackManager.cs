using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PetWalker.BusinessLogic.Interfaces;
using PetWalker.BusinessLogic.BusinessEntities;
using PetWalker.DataAccess.Interfaces;

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
