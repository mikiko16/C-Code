namespace AnimalCentre.Models.Contracts
{
    using System.Collections.Generic;
    using AnimalCentre.Models.Entity.Animals;

    public interface IHotel
    {
        IReadOnlyDictionary<string, IAnimal> Animals { get; }
        void Adopt(string animalName, string owner);
        void Accommodate(IAnimal animal);
    }
}
