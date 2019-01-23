using System;
using System.Collections.Generic;
using System.Text;
using AnimalCentre.Models.Contracts;
using AnimalCentre.Models.Entity.Animals;

namespace AnimalCentre.Models.Entity.Procedures
{
    public class Fitness : Procedure
    {
        public override void DoService(IAnimal animal, int procedureTime)
        {
            Animal a = (Animal)animal;
            base.DoService(animal, procedureTime);
            animal.Happiness -= 3;
            animal.Energy += 10;
            animal.ProcedureTime -= procedureTime;
            //this.ProcedureHistory.Add(animal);
        }
    }
}
