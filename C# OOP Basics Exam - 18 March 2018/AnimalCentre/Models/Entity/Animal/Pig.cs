using System;
using System.Collections.Generic;
using System.Text;

namespace AnimalCentre.Models.Entity.Animals
{
    public class Pig : Animal
    {
        public Pig(string name, int energy, int happiness, int procedureTime) 
            : base(name, energy, happiness, procedureTime)
        {
        }

        public override string ToString()
        {
            return string.Format(base.ToString(), nameof(Pig), Name, Happiness, Energy);
        }
    }
}
