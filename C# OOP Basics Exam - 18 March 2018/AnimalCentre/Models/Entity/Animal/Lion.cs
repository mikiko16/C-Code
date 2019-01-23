using System;
using System.Collections.Generic;
using System.Text;

namespace AnimalCentre.Models.Entity.Animals
{
    public class Lion : Animal
    {
        public Lion(string name, int energy, int happiness, int procedureTime) 
            : base(name, energy, happiness, procedureTime)
        {
        }

        public override string ToString()
        {
            return string.Format(base.ToString(), nameof(Lion), Name, Happiness, Energy);
        }
    }
}
