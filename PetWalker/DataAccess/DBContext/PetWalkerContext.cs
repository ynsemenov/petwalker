using PetWalker.DataAccess.DBEntities;
using System.Data.Entity;

namespace PetWalker.DataAccess.DBContext
{
    public class PetWalkerContext:DbContext
    {
        public PetWalkerContext() : base("PetWalker")
        {

        }

        public DbSet<Customer> Customers { get; set; }

        public DbSet<Pet> Pets { get; set; }

        public DbSet<Pack> Packs { get; set; }

        public DbSet<PetPack> PacksOfPets { get; set; }

        public DbSet<Price> Prices { get; set; }

        public DbSet<Size> Sizes { get; set; }

        public DbSet<PetWalk> PetWalks { get; set; }
    }
}
