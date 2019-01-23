namespace AnimalCentre.Models.Contracts
{
    using System.Collections.Generic;
    using AnimalCentre.Models.Entity.Animals;

    public interface IProcedure
    {
        void DoService(IAnimal animal, int procedureTime);
    }
}
