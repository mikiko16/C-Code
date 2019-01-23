using System;
using System.Collections.Generic;
using System.Text;
using AnimalCentre.Models.Contracts;
using AnimalCentre.Models.Entity.Animals;
using System.Collections.ObjectModel;

namespace AnimalCentre.Models.Entity
{
    public class Hotel : IHotel
    {
        private Dictionary<string, IAnimal> animals;

        public Hotel()
        {
            this.animals = new Dictionary<string, IAnimal>();
        }

        public void Adopt(string animalName, string owner)
        {
            if (this.animals.ContainsKey(animalName))
            {
                IAnimal animal = this.animals[animalName];
                animal.IsAdopt = true;
                animal.Owner = owner;
                this.animals.Remove(animalName);
            }
            else
            {
                throw new ArgumentException($"Animal {animalName} does not exist");
            }
        }

        public IReadOnlyDictionary<string, IAnimal> Animals
        {
            get => new ReadOnlyDictionary<string, IAnimal>(this.animals);

        }
        public void Accommodate(IAnimal animal)
        {
            if (animals.Count == 10)
            {
                throw new InvalidOperationException("Not enough capacity");
            }

            if (!this.animals.ContainsKey(animal.Name))
            {
                this.animals[animal.Name] = animal;
            }
            else
            {
                throw new ArgumentException($"Animal {animal.Name} already exist");
            }
        }
    }
}
