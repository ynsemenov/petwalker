using PetWalker.DataAccess.DBContext;
using PetWalker.DataAccess.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using BusinessEntities = PetWalker.BusinessLogic.BusinessEntities;


namespace PetWalker.DataAccess.Providers
{
    public class DatabaseProvider : IDatabaseProvider
    {
        public IEnumerable<BusinessEntities.Customer> GetCustomers()
        {
            using (var dbContext = new PetWalkerContext())
            {
                return (from c in dbContext.Customers
                        join pets in (from p in dbContext.Pets
                                      join s in dbContext.Sizes on p.SizeId equals s.Id
                                      select new
                                      {
                                          Id = p.Id,
                                          CustomerId = p.CustomerId,
                                          Name = p.Name,
                                          Size = s.Name,
                                          IsAgressive = p.IsAgressive
                                      }) on c.Id equals pets.CustomerId into petGroup
                        select new BusinessEntities.Customer
                        {
                            Id = c.Id,
                            Name = c.Name,
                            Address = c.Address,
                            Pets = (from pg in petGroup
                                    select new BusinessEntities.Pet
                                    {
                                        Id = pg.Id,
                                        Name = pg.Name,
                                        Size = pg.Size,
                                        IsAgressive = pg.IsAgressive
                                    }).ToList()
                        }).ToList();
            }
        }

        public IEnumerable<BusinessEntities.PetPack> GetPetPacks()
        {
            using (var dbContext = new PetWalkerContext())
            {
                return (from pc in dbContext.Packs
                        join pets in (from p in dbContext.Pets
                                      join pp in dbContext.PacksOfPets on p.Id equals pp.PetId
                                      join s in dbContext.Sizes on p.SizeId equals s.Id
                                      select new
                                      {
                                          Id = p.Id,
                                          PackId = pp.PackId,
                                          Name = p.Name,
                                          Size = s.Name,
                                          IsAgressive = p.IsAgressive
                                      }) on pc.Id equals pets.PackId into petGroup
                        select new BusinessEntities.PetPack
                        {
                            Id = pc.Id,
                            Name = pc.Name,
                            Pets = (from pg in petGroup
                                    select new BusinessEntities.Pet
                                    {
                                        Id = pg.Id,
                                        Name = pg.Name,
                                        Size = pg.Size,
                                        IsAgressive = pg.IsAgressive
                                    }).ToList()
                        }
                    ).ToList();
            }
        }

        public IEnumerable<BusinessEntities.PetWalk> GetPetWalksByDate(DateTime startDate, DateTime endDate)
        {
            using (var dbContext = new PetWalkerContext())
            {
                return (from pw in dbContext.PetWalks
                        join petPack in dbContext.Packs on pw.PackId equals petPack.Id into pack
                        from ePack in pack.DefaultIfEmpty()
                        join pet in dbContext.Pets on pw.PetId equals pet.Id into pets
                        from ePet in pets.DefaultIfEmpty()
                        join ps in dbContext.Sizes on ePet.SizeId equals ps.Id into petSize
                        from ePetSize in petSize.DefaultIfEmpty()
                        where pw.WalkDate >= startDate && pw.WalkDate <= endDate
                        select new BusinessEntities.PetWalk
                        {
                            Id = pw.Id,
                            Name = pw.Name,
                            Pet = (ePetSize != null ? new BusinessEntities.Pet
                            {
                                Id = ePet.Id,
                                Name = ePet.Name,
                                IsAgressive = ePet.IsAgressive,
                                Size = ePetSize.Name
                            } : null),
                            PetPack = (ePack != null ? new BusinessEntities.PetPack
                            {
                                Id = ePack.Id,
                                Name = ePack.Name
                            } : null),
                            WalkDate = pw.WalkDate
                        }).ToList();
            }
        }

        public IEnumerable<BusinessEntities.Pet> GetPetsByPackId(long packId)
        {
            using (var dbContext = new PetWalkerContext())
            {
                return (from p in dbContext.Pets
                        join pp in dbContext.PacksOfPets on p.Id equals pp.PetId
                        join s in dbContext.Sizes on p.SizeId equals s.Id
                        where pp.PackId == packId
                        select new BusinessEntities.Pet
                        {
                            Id = p.Id,
                            Name = p.Name,
                            Size = s.Name,
                            IsAgressive = p.IsAgressive
                        }).ToList();

            }
        }

        public IEnumerable<BusinessEntities.Price> GetPrices()
        {
            using (var dbContext = new PetWalkerContext())
            {
                return (from p in dbContext.Prices
                        join s in dbContext.Sizes on p.SizeId equals s.Id
                        select new BusinessEntities.Price
                        {
                            Id = p.Id,
                            Size = s.Name,
                            IsAgressive = p.IsAgressive,
                            Amount = p.Amount
                        }).ToList();
            }
        }
    }
}
