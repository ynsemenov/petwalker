using PetWalker.BusinessLogic.BusinessEntities;
using System.Collections.Generic;

namespace PetWalker.BusinessLogic.Interfaces
{
    public interface IPetManager
    {
        IEnumerable<Pet> GetPetsByPackId(long packId);
    }
}
