using PetWalker.BusinessLogic.Managers;
using PetWalker.Presentation.Helpers;
using PetWalker.Presentation.Managers;

namespace PetWalker
{
    class Program
    {
        static void Main(string[] args)
        {
            var menuHelper = new MenuHelper();
            var outputInfoHelper = new OutputInfoHelper();
            var businessLogicManager = new BusinessLogicManager();
            var menuManager = new MenuManager(menuHelper, outputInfoHelper, businessLogicManager);

            while(menuManager.IsActive)
            {
                menuManager.Run();
            }
        }
    }
}
