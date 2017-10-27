using System.Collections.Generic;

namespace PetWalker.BusinessLogic.BusinessEntities
{
    public class PetPack
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public IEnumerable<Pet> Pets { get; set; }
    }
}
