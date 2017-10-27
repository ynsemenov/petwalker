using Microsoft.VisualStudio.TestTools.UnitTesting;
using PetWalker.BusinessLogic.BusinessEntities;
using PetWalker.BusinessLogic.Interfaces;
using PetWalker.BusinessLogic.Managers;
using Rhino.Mocks;
using System;
using System.Collections.Generic;

namespace PetWalker.UnitTests.BusinessLogic.Managers
{
    [TestClass]
    public class BusinessLogicManagerTests
    {
        [TestMethod]
        public void GetDateCost_NoWalksForDay_ReturnZero()
        {
            //Arrange
            var emptyList = new List<PetWalk>();

            var petWalkManagerMock = MockRepository.GenerateStub<IPetWalkManager>();
            var priceManagerMock = MockRepository.GenerateMock<IPriceManager>();

            petWalkManagerMock.Stub(x => x.GetPetWalkListForDate(Arg<DateTime>.Is.Anything)).Return(emptyList);

            //Act
            var businessLogicManager = new BusinessLogicManager(null, null, petWalkManagerMock, null, priceManagerMock);
            var actualResult = businessLogicManager.GetDateCost(DateTime.Today);

            //Assert
            Assert.AreEqual(0, actualResult);
            priceManagerMock.AssertWasNotCalled(x => x.LoadPrices());
        }

        [TestMethod]
        public void GetDateCost_TwoWalksForDay_ReturnExpectedAmount()
        {
            //Arrange
            var walkList = new List<PetWalk>();

            var firstWalk = new PetWalk
            {
                Pet = new Pet
                {
                    Size = "Small",
                    IsAgressive = true
                }
            };
            walkList.Add(firstWalk);

            var secondWalk = new PetWalk
            {
                PetPack = new PetPack
                {
                    Id = 1
                }
            };
            walkList.Add(secondWalk);

            var petList = new List<Pet>();

            var firstPetInPack = new Pet
            {
                Size = "Large",
                IsAgressive = false
            };
            petList.Add(firstPetInPack);

            var secondPetInPack = new Pet
            {
                Size = "Small",
                IsAgressive = false
            };
            petList.Add(secondPetInPack);


            var petWalkManagerMock = MockRepository.GenerateStub<IPetWalkManager>();
            var priceManagerMock = MockRepository.GenerateMock<IPriceManager>();
            var petManagerMock = MockRepository.GenerateMock<IPetManager>();

            petWalkManagerMock.Stub(x => x.GetPetWalkListForDate(Arg<DateTime>.Is.Anything)).Return(walkList);
            priceManagerMock.Stub(x => x.LoadPrices());
            priceManagerMock.Stub(x => x.GetPriceBySizeAndAgression(Arg<string>.Is.Equal("Small"), Arg<bool>.Is.Equal(true))).Return(10);
            priceManagerMock.Stub(x => x.GetPriceBySizeAndAgression(Arg<string>.Is.Equal("Small"), Arg<bool>.Is.Equal(false))).Return(20);
            priceManagerMock.Stub(x => x.GetPriceBySizeAndAgression(Arg<string>.Is.Equal("Large"), Arg<bool>.Is.Equal(false))).Return(30);

            petManagerMock.Stub(x => x.GetPetsByPackId(Arg<long>.Is.Anything)).Return(petList);

            //Act
            var businessLogicManager = new BusinessLogicManager(null, null, petWalkManagerMock, petManagerMock, priceManagerMock);
            var actualResult = businessLogicManager.GetDateCost(DateTime.Today);

            //Assert
            Assert.AreEqual(60, actualResult);
            priceManagerMock.AssertWasCalled(x => x.LoadPrices());
            petManagerMock.AssertWasCalled(x => x.GetPetsByPackId(Arg<long>.Is.Equal(1)));
            priceManagerMock.AssertWasCalled(x => x.GetPriceBySizeAndAgression(Arg<string>.Is.Equal("Small"), Arg<bool>.Is.Equal(true)));
            priceManagerMock.AssertWasCalled(x => x.GetPriceBySizeAndAgression(Arg<string>.Is.Equal("Small"), Arg<bool>.Is.Equal(false)));
            priceManagerMock.AssertWasCalled(x => x.GetPriceBySizeAndAgression(Arg<string>.Is.Equal("Large"), Arg<bool>.Is.Equal(false)));
        }
    }
}
