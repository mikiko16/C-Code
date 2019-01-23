using System;
using System.Collections.Generic;
using System.Text;
using AnimalCentre.Models.Contracts;
using AnimalCentre.Models.Entity.Animals;

namespace AnimalCentre.Models.Entity.Procedures
{
    public class NailTrim : Procedure
    {
        public override void DoService(IAnimal animal, int procedureTime)
        {
            Animal a = (Animal)animal;
            base.DoService(animal, procedureTime);
            animal.Happiness -= 7;
            animal.ProcedureTime -= procedureTime;
            //this.ProcedureHistory.Add(animal);
        }
    }
}
