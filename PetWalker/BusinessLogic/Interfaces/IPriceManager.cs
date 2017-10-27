namespace PetWalker.BusinessLogic.Interfaces
{
    public interface IPriceManager
    {
        void LoadPrices();
        double GetPriceBySizeAndAgression(string size, bool isAgressive);
    }
}
