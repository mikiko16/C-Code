using System;
using System.Collections.Generic;
using System.Text;
using AnimalCentre.Models.Contracts;
using AnimalCentre.Models.Entity.Animals;

namespace AnimalCentre.Models.Entity.Procedures
{
    public class Chip : Procedure
    {
        public override void DoService(IAnimal animal, int procedureTime)
        {
            base.DoService(animal, procedureTime);
            Animal a = (Animal)animal;
            animal.Happiness -= 5;
            if (a.IsChipped)
            {
                throw new ArgumentException($"{animal.Name} is already chipped");
            }
            animal.IsChipped = true;
            animal.ProcedureTime -= procedureTime;
            //this.ProcedureHistory.Add(animal);
        }
    }
}
