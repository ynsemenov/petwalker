using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PetWalker.BusinessLogic.BusinessEntities;
using PetWalker.BusinessLogic.Interfaces;
using PetWalker.DataAccess.Interfaces;

namespace PetWalker.BusinessLogic.Managers
{
    public class PetWalkManager : IPetWalkManager
    {
        private readonly IDatabaseProvider databaseProvider;

        public PetWalkManager(IDatabaseProvider databaseProvider)
        {
            this.databaseProvider = databaseProvider;
        }

        public IEnumerable<PetWalk> GetPetWalkListForDate(DateTime date)
        {
            var startDate = date.Date;
            var endDate = date.AddDays(1).Date;
            return databaseProvider.GetPetWalksByDate(startDate, endDate);
        }

        public IEnumerable<PetWalk> GetPetWalkListForDateRange(DateTime startDate, DateTime endDate)
        {
            return databaseProvider.GetPetWalksByDate(startDate, endDate);
        }
    }
}
