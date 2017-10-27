using PetWalker.BusinessLogic.BusinessEntities;
using System;
using System.Collections.Generic;

namespace PetWalker.BusinessLogic.Interfaces
{
    public interface IPetWalkManager
    {
        IEnumerable<PetWalk> GetPetWalkListForDate(DateTime date);
        IEnumerable<PetWalk> GetPetWalkListForDateRange(DateTime startDate, DateTime endDate);
    }
}
