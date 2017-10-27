using PetWalker.BusinessLogic.BusinessEntities;
using PetWalker.BusinessLogic.Interfaces;
using PetWalker.DataAccess.Interfaces;
using System.Collections.Generic;

namespace PetWalker.BusinessLogic.Managers
{
    public class CustomerManager : ICustomerManager
    {
        private readonly IDatabaseProvider databaseProvider;

        public CustomerManager(IDatabaseProvider databaseProvider)
        {
            this.databaseProvider = databaseProvider;
        }

        public IEnumerable<Customer> GetCustomerList()
        {
            return databaseProvider.GetCustomers();
        }
    }
}
