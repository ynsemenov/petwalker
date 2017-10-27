using PetWalker.BusinessLogic.BusinessEntities;
using System;
using System.Collections.Generic;

namespace PetWalker.DataAccess.Interfaces
{
    public interface IDatabaseProvider
    {
        IEnumerable<Customer> GetCustomers();
        IEnumerable<PetPack> GetPetPacks();
        IEnumerable<PetWalk> GetPetWalksByDate(DateTime startDate, DateTime endDate);
        IEnumerable<Pet> GetPetsByPackId(long packId);
        IEnumerable<Price> GetPrices();
    }
}
