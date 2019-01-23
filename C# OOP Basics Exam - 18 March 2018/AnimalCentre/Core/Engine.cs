using System;
using System.Collections.Generic;
using System.Text;

namespace AnimalCentre.Core
{
    public class Engine
    {
        AnimalCentre animalCenter;

        public Engine()
        {
            animalCenter = new AnimalCentre();
        }
        public void Run()
        {
            var result = string.Empty;

            string command = Console.ReadLine();

            while (command != "End")
            {
                var comm = command.Split();

                try
                {
                    result = this.ProcessCommand(comm);
                }
                catch(ArgumentException ex)
                {
                    result = "ArgumentException: " + ex.Message;
                }
                catch(InvalidOperationException ex)
                {
                    result = "InvalidOperationException: " + ex.Message;
                }
                Console.WriteLine(result);
                command = Console.ReadLine();
            }
            Console.WriteLine(animalCenter.AdoptedAnimals());
        }

        public string ProcessCommand(string[] args)
        {
            string result = string.Empty;

            string command = args[0];

            if(command == "RegisterAnimal")
            {
                string animalType = args[1];
                string name = args[2];
                int energy = int.Parse(args[3]);
                int happiness = int.Parse(args[4]);
                int procedureTime = int.Parse(args[5]);

                result = animalCenter.RegisterAnimal(animalType, name, energy, happiness, procedureTime);
            }
            else if(command == "Chip")
            {
                string name = args[1];
                int time = int.Parse(args[2]);

                result = animalCenter.Chip(name, time);
            }
            else if(command == "Vaccinate")
            {
                string name = args[1];
                int time = int.Parse(args[2]);

                result = animalCenter.Vaccinate(name, time);
            }
            else if(command == "Fitness")
            {
                string name = args[1];
                int time = int.Parse(args[2]);

                result = animalCenter.Fitness(name, time);
            }
            else if(command == "Play")
            {
                string name = args[1];
                int time = int.Parse(args[2]);

                result = animalCenter.Play(name, time);
            }
            else if(command == "DentalCare")
            {
                string name = args[1];
                int time = int.Parse(args[2]);

                result = animalCenter.DentalCare(name, time);
            }
            else if(command == "NailTrim")
            {
                string name = args[1];
                int time = int.Parse(args[2]);

                result = animalCenter.NailTrim(name, time);
            }
            else if(command == "Adopt")
            {
                string animalName = args[1];
                string owner = args[2];
                result = animalCenter.Adopt(animalName, owner);
            }
            else if(command == "History")
            {
                string name = args[1];
                result = animalCenter.History(name);
            }

            return result;
        }
    }
}
