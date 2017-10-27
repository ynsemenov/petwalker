using Microsoft.VisualStudio.TestTools.UnitTesting;
using PetWalker.BusinessLogic.BusinessEntities;
using PetWalker.BusinessLogic.Interfaces;
using PetWalker.Presentation.Managers;
using PetWalker.Presentation.Interfaces;
using Rhino.Mocks;
using System;
using System.Collections.Generic;

namespace PetWalker.UnitTests.Presentation.Managers
{
    [TestClass]
    public class MenuManagerTests
    {
        [TestMethod]
        public void Run_CustomerSubMenu_GetCustomers_Active()
        {
            //Arrange
            var menuHelperMock = MockRepository.GenerateMock<IMenuHelper>();
            var outputInfoHelperMock = MockRepository.GenerateMock<IOutputInfoHelper>();
            var businessLogicManagerMock = MockRepository.GenerateMock<IBusinessLogicManager>();

            var customerList = new List<Customer>();

            menuHelperMock.Stub(x => x.DrawMainMenu()).Return("1");
            menuHelperMock.Stub(x => x.DrawCustomerSubMenu()).Return("1");
            businessLogicManagerMock.Stub(x => x.GetCustomerList()).Return(customerList);
            outputInfoHelperMock.Stub(x=>x.OutputCustomerList(Arg<List<Customer>>.Is.Anything));

            //Act
            var menuManager = new MenuManager(menuHelperMock, outputInfoHelperMock, businessLogicManagerMock);
            menuManager.Run();

            //Assert
            Assert.AreEqual(true, menuManager.IsActive);
            menuHelperMock.AssertWasCalled(x => x.DrawMainMenu());
            menuHelperMock.AssertWasCalled(x => x.DrawCustomerSubMenu());
            businessLogicManagerMock.AssertWasCalled(x => x.GetCustomerList());
            outputInfoHelperMock.AssertWasCalled(x => x.OutputCustomerList(Arg<List<Customer>>.Is.Anything));
        }

        [TestMethod]
        public void Run_PetPacksSubMenu_GetPacks_Active()
        {
            //Arrange
            var menuHelperMock = MockRepository.GenerateMock<IMenuHelper>();
            var outputInfoHelperMock = MockRepository.GenerateMock<IOutputInfoHelper>();
            var businessLogicManagerMock = MockRepository.GenerateMock<IBusinessLogicManager>();

            var packList = new List<PetPack>();

            menuHelperMock.Stub(x => x.DrawMainMenu()).Return("2");
            menuHelperMock.Stub(x => x.DrawPacksSubMenu()).Return("1");
            businessLogicManagerMock.Stub(x => x.GetPetPackList()).Return(packList);
            outputInfoHelperMock.Stub(x => x.OutputPetPackList(Arg<List<PetPack>>.Is.Anything));

            //Act
            var menuManager = new MenuManager(menuHelperMock, outputInfoHelperMock, businessLogicManagerMock);
            menuManager.Run();

            //Assert
            Assert.AreEqual(true, menuManager.IsActive);
            menuHelperMock.AssertWasCalled(x => x.DrawMainMenu());
            menuHelperMock.AssertWasCalled(x => x.DrawPacksSubMenu());
            businessLogicManagerMock.AssertWasCalled(x => x.GetPetPackList());
            outputInfoHelperMock.AssertWasCalled(x => x.OutputPetPackList(Arg<List<PetPack>>.Is.Anything));
        }

        [TestMethod]
        public void Run_ScheduleSubMenu_GetWeekSchedule_Active()
        {
            //Arrange
            var menuHelperMock = MockRepository.GenerateMock<IMenuHelper>();
            var outputInfoHelperMock = MockRepository.GenerateMock<IOutputInfoHelper>();
            var businessLogicManagerMock = MockRepository.GenerateMock<IBusinessLogicManager>();

            var petWalkList = new List<PetWalk>();

            menuHelperMock.Stub(x => x.DrawMainMenu()).Return("3");
            menuHelperMock.Stub(x => x.DrawScheduleSubMenu()).Return("1");
            businessLogicManagerMock.Stub(x => x.GetPetWalkList(Arg<DateTime>.Is.Anything, Arg<DateTime>.Is.Anything)).Return(petWalkList);
            outputInfoHelperMock.Stub(x => x.OutputPetWalkList(Arg<List<PetWalk>>.Is.Anything));

            //Act
            var menuManager = new MenuManager(menuHelperMock, outputInfoHelperMock, businessLogicManagerMock);
            menuManager.Run();

            //Assert
            Assert.AreEqual(true, menuManager.IsActive);
            menuHelperMock.AssertWasCalled(x => x.DrawMainMenu());
            menuHelperMock.AssertWasCalled(x => x.DrawScheduleSubMenu());
            businessLogicManagerMock.AssertWasCalled(x => x.GetPetWalkList(Arg<DateTime>.Is.Anything, Arg<DateTime>.Is.Anything));
            outputInfoHelperMock.AssertWasCalled(x => x.OutputPetWalkList(Arg<List<PetWalk>>.Is.Anything));
        }

        [TestMethod]
        public void Run_ScheduleSubMenu_GetDayCost_Active()
        {
            //Arrange
            var menuHelperMock = MockRepository.GenerateMock<IMenuHelper>();
            var outputInfoHelperMock = MockRepository.GenerateMock<IOutputInfoHelper>();
            var businessLogicManagerMock = MockRepository.GenerateMock<IBusinessLogicManager>();

            var customerList = new List<Customer>();

            menuHelperMock.Stub(x => x.DrawMainMenu()).Return("3");
            menuHelperMock.Stub(x => x.DrawScheduleSubMenu()).Return("2");
            businessLogicManagerMock.Stub(x => x.GetDateCost(Arg<DateTime>.Is.Anything)).Return(100);
            outputInfoHelperMock.Stub(x => x.OutputDayCost(Arg<DayOfWeek>.Is.Anything, Arg<double>.Is.Anything));

            //Act
            var menuManager = new MenuManager(menuHelperMock, outputInfoHelperMock, businessLogicManagerMock);
            menuManager.Run();

            //Assert
            Assert.AreEqual(true, menuManager.IsActive);
            menuHelperMock.AssertWasCalled(x => x.DrawMainMenu());
            menuHelperMock.AssertWasCalled(x => x.DrawScheduleSubMenu());
            businessLogicManagerMock.AssertWasCalled(x => x.GetDateCost(Arg<DateTime>.Is.Anything));
            outputInfoHelperMock.AssertWasCalled(x => x.OutputDayCost(Arg<DayOfWeek>.Is.Anything, Arg<double>.Is.Equal(100)));
        }

        [TestMethod]
        public void Run_Exit_NotActive()
        {
            //Arrange
            var menuHelperMock = MockRepository.GenerateMock<IMenuHelper>();

            menuHelperMock.Stub(x => x.DrawMainMenu()).Return("0");

            //Act
            var menuManager = new MenuManager(menuHelperMock, null, null);
            menuManager.Run();

            //Assert
            Assert.AreEqual(false, menuManager.IsActive);
        }
    }
}
