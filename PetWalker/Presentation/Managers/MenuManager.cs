using PetWalker.Presentation.Interfaces;
using PetWalker.BusinessLogic.Interfaces;
using System;

namespace PetWalker.Presentation.Managers
{
    public class MenuManager
    {
        private readonly IMenuHelper menuHelper;
        private readonly IOutputInfoHelper outputInfoHelper;
        private readonly IBusinessLogicManager businessLogicManager;
        private bool isActive;

        public bool IsActive
        {
            get { return isActive; }
        }

        public MenuManager(IMenuHelper menuHelper, IOutputInfoHelper outputInfoHelper, IBusinessLogicManager businessLogicManager)
        {
            this.menuHelper = menuHelper;
            this.outputInfoHelper = outputInfoHelper;
            this.businessLogicManager = businessLogicManager;

            this.isActive = true;
        }

        public void Run()
        {
            var currentOption = menuHelper.DrawMainMenu();
            
            switch (currentOption)
            {
                case "0":
                    {
                        this.isActive = false;
                        break;
                    };
                case "1":
                    {
                        switch (menuHelper.DrawCustomerSubMenu())
                        {
                            case "1":
                                {
                                    var customers = businessLogicManager.GetCustomerList();
                                    outputInfoHelper.OutputCustomerList(customers);
                                    break;
                                }
                            case "2":
                                {
                                    ///TODO: implement edit of customers
                                    Console.WriteLine("Not implemented...");
                                    break;
                                }
                        }
                        break;
                    }
                case "2":
                    {
                        switch (menuHelper.DrawPacksSubMenu())
                        {
                            case "1":
                                {
                                    var packs = businessLogicManager.GetPetPackList();
                                    outputInfoHelper.OutputPetPackList(packs);
                                    break;
                                }
                            case "2":
                                {
                                    ///TODO: implement edit of packs
                                    Console.WriteLine("Not implemented...");
                                    break;
                                }
                        }
                        break;
                    }
                case "3":
                    {
                        switch (menuHelper.DrawScheduleSubMenu())
                        {
                            case "1":
                                {
                                    var weekWalks = businessLogicManager.GetPetWalkList(DateTime.Today.AddDays(-10), DateTime.Today.AddDays(10));
                                    outputInfoHelper.OutputPetWalkList(weekWalks);
                                    break;
                                }
                            case "2":
                                {
                                    var cost = businessLogicManager.GetDateCost(DateTime.Today);                                    
                                    outputInfoHelper.OutputDayCost(DateTime.Today.DayOfWeek, cost);
                                    break;
                                }
                        }
                        break;
                    }
            }
        }

    }
}
