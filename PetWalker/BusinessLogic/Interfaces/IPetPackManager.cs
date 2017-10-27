using PetWalker.BusinessLogic.BusinessEntities;
using System.Collections.Generic;

namespace PetWalker.BusinessLogic.Interfaces
{
    public interface IPetPackManager
    {
        IEnumerable<PetPack> GetPetPackList();        
    }
}
