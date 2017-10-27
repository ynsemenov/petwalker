using System;

namespace PetWalker.BusinessLogic.BusinessEntities
{
    public class PetWalk
    {
        public long Id { get; set; }
        public string Name { get; set; }        
        public DateTime WalkDate { get; set; }
        public Pet Pet { get; set; }
        public PetPack PetPack { get; set; }
    }
}
