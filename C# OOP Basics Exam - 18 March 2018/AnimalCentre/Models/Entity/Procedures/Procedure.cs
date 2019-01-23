using System;
using System.Collections.Generic;
using System.Text;
using AnimalCentre.Models.Contracts;
using AnimalCentre.Models.Entity.Animals;
using System.Linq;
using AnimalCentre.Models.Entity;

namespace AnimalCentre.Models.Entity.Procedures
{
    public abstract class Procedure : IProcedure
    {
        protected IList<IAnimal> ProcedureHistory;

        public Procedure()
        {
            this.ProcedureHistory = new List<IAnimal>();
        }

        public string History()
        {
            var result = string.Empty;

            result += $"{this.GetType().Name}";
            foreach (var item in ProcedureHistory)
            {
                result += $"\n   Animal type: {item.GetType().Name} - {item.Name} - Happiness: {item.Happiness} - Energy: {item.Energy}";
            }

            return result;
        }

        public virtual void DoService(IAnimal animal, int procedureTime)
        {
            if (animal.ProcedureTime < procedureTime)
            {
                throw new ArgumentException("Animal doesn't have enough procedure time");
            }
            this.ProcedureHistory.Add((Animal)animal);
        }
    }
}
