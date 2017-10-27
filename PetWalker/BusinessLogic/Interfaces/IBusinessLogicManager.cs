using PetWalker.BusinessLogic.BusinessEntities;
using System;
using System.Collections.Generic;

namespace PetWalker.BusinessLogic.Interfaces
{
    public interface IBusinessLogicManager
    {
        IEnumerable<Customer> GetCustomerList();
        IEnumerable<PetPack> GetPetPackList();
        IEnumerable<PetWalk> GetPetWalkList(DateTime startDate, DateTime dateTime);
        double GetDateCost(DateTime date);
    }
}
