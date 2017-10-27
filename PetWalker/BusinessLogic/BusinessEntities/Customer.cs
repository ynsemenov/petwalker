using System.Collections.Generic;

namespace PetWalker.BusinessLogic.BusinessEntities
{
    public class Customer
    {
        public long Id { get; set;}
        public string Name { get; set; }
        public string Address { get; set; }
        public IEnumerable<Pet> Pets { get; set; }
    }
}
