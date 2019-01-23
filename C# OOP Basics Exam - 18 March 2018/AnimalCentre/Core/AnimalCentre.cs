using System;
using System.Collections.Generic;
using System.Text;
using AnimalCentre.Models.Entity.Animals;
using AnimalCentre.Models.Entity;
using AnimalCentre.Models.Contracts;
using AnimalCentre.Models.Entity.Procedures;
using System.Linq;

namespace AnimalCentre.Core
{
    public class AnimalCentre
    {
        Hotel hotel;
        Procedure procedure;
        Dictionary<string, Procedure> pros;
        Dictionary<string, List<string>> Adopted;

        public AnimalCentre()
        {
            hotel = new Hotel();
            Adopted = new Dictionary<string, List<string>>();
            pros = new Dictionary<string, Procedure>();
            InitializeServices();
        }

        private void InitializeServices()
        {
            pros.Add("Chip", new Chip());
            pros.Add("DentalCare", new DentalCare());
            pros.Add("Fitness", new Fitness());
            pros.Add("NailTrim", new NailTrim());
            pros.Add("Play", new Play());
            pros.Add("Vaccinate", new Vaccinate());
        }

        public string RegisterAnimal(string type, string name, int energy, int happiness, int procedureTime)
        {
            Animal animal = null;
            if(type == "Dog")
            {
                animal = new Dog(name, energy, happiness, procedureTime);
            }
            else if(type == "Cat")
            {
                animal = new Cat(name, energy, happiness, procedureTime);
            }
            else if(type == "Lion")
            {
                animal = new Lion(name, energy, happiness, procedureTime);
            }
            else if(type == "Pig")
            {
                animal = new Pig(name, energy, happiness, procedureTime);              
            }
            hotel.Accommodate(animal);

            return $"Animal {name} registered successfully";
        }

        public string Chip(string name, int procedureTime)
        {
            if (!hotel.Animals.ContainsKey(name))
            {
                throw new ArgumentException($"Animal {name} does not exist");
            }
            pros["Chip"].DoService(hotel.Animals[name], procedureTime);
            return $"{name} had chip procedure";
        }

        public string Vaccinate(string name, int procedureTime)
        {
            if (!hotel.Animals.ContainsKey(name))
            {
                throw new ArgumentException($"Animal {name} does not exist");
            }
            pros["Vaccinate"].DoService(hotel.Animals[name], procedureTime);
            return $"{name} had vaccination procedure";
        }

        public string Fitness(string name, int procedureTime)
        {
            if (!hotel.Animals.ContainsKey(name))
            {
                throw new ArgumentException($"Animal {name} does not exist");
            }
            IAnimal animal = hotel.Animals[name];
            pros["Fitness"].DoService(hotel.Animals[name], procedureTime);
            return $"{name} had fitness procedure";
        }

        public string Play(string name, int procedureTime)
        {
            if (!hotel.Animals.ContainsKey(name))
            {
                throw new ArgumentException($"Animal {name} does not exist");
            }
            IAnimal animal = hotel.Animals[name];
            pros["Play"].DoService(hotel.Animals[name], procedureTime);
            return $"{name} was playing for {procedureTime} hours";
        }

        public string DentalCare(string name, int procedureTime)
        {
            if (!hotel.Animals.ContainsKey(name))
            {
                throw new ArgumentException($"Animal {name} does not exist");
            }
            IAnimal animal = hotel.Animals[name];
            pros["DentalCare"].DoService(hotel.Animals[name], procedureTime);
            return $"{name} had dental care procedure";
        }

        public string NailTrim(string name, int procedureTime)
        {
            if (!hotel.Animals.ContainsKey(name))
            {
                throw new ArgumentException($"Animal {name} does not exist");
            }
            IAnimal animal = hotel.Animals[name];
            pros["NailTrim"].DoService(hotel.Animals[name], procedureTime);
            return $"{name} had nail trim procedure";
        }

        public string Adopt(string animalName, string owner)
        {
            if (!hotel.Animals.ContainsKey(animalName))
            {
                throw new ArgumentException($"Animal {animalName} does not exist");
            }
            IAnimal animal = hotel.Animals[animalName];
            if (!Adopted.ContainsKey(owner))
            {
                Adopted[owner] = new List<string>();
            }

            if (animal.IsChipped)
            {
                Adopted[owner].Add(animal.Name);
                hotel.Adopt(animalName, owner);
                return $"{owner} adopted animal with chip";
            }
            else
            {
                Adopted[owner].Add(animal.Name);
                hotel.Adopt(animalName, owner);
                return $"{owner} adopted animal without chip";
            }
        }

        public string AdoptedAnimals()
        {
            StringBuilder sb = new StringBuilder();

            foreach (var item in Adopted.OrderBy(x => x.Key))
            {
                sb.AppendLine($"--Owner: {item.Key}");
                sb.AppendLine($"   - Adopted animals: " + string.Join(" ", item.Value));
            }

            return sb.ToString();
        }

        public string History(string type)
        {
            string result = string.Empty;

            if(type == "Chip")
            {
                result = pros["Chip"].History();
            }
            else if(type == "Vaccinate")
            {
                result = pros["Vaccinate"].History();
            }
            else if(type == "Play")
            {
                result = pros["Play"].History();
            }
            else if(type == "NailTrim")
            {
                result = pros["NailTrim"].History();
            }
            else if(type == "Fitness")
            {
                result = pros["Fitness"].History();
            }
            else if(type == "DentalCare")
            {
                result = pros["DentalCare"].History();
            }
            return result;
        }
    }
}
