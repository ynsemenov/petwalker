using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PetWalker.BusinessLogic.BusinessEntities;

namespace PetWalker.BusinessLogic.Interfaces
{
    public interface IPetManager
    {
        IEnumerable<Pet> GetPetsByPackId(long packId);
    }
}
