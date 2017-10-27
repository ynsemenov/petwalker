using PetWalker.BusinessLogic.BusinessEntities;
using System;
using System.Collections.Generic;

namespace PetWalker.Presentation.Interfaces
{
    public interface IOutputInfoHelper
    {
        void OutputCustomerList(IEnumerable<Customer> customers);
        void OutputPetPackList(IEnumerable<PetPack> dogPacks);
        void OutputPetWalkList(IEnumerable<PetWalk> walks);
        void OutputDayCost(DayOfWeek dayOfWeek, double cost);
    }
}
