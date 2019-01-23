
using System;
using System.Linq;
namespace FestivalManager.Core
{
	using System.Reflection;
	using Contracts;
	using Controllers;
	using Controllers.Contracts;
    using FestivalManager.Entities;
    using FestivalManager.Entities.Contracts;
    using IO.Contracts;

	/// <summary>
	/// by g0shk0
	/// </summary>
	class Engine : IEngine
	{
	    private IReader reader;
        static IStage stage;
        private IFestivalController festivalCоntroller;
        private ISetController setCоntroller;
        private IWriter writer;

        public Engine(IFestivalController festivalController, ISetController setController)
        {
            this.festivalCоntroller = festivalController;
            this.setCоntroller = setController;
        }

        public void Run()
		{
			while(true) 
			{
				var input = Console.ReadLine();

				if (input == "END")
                {
                    break;
                }

				try
				{
					var result = this.DoCommand(input);
                    Console.WriteLine(result);
				}
				catch (Exception ex)
				{
					Console.WriteLine("ERROR: " + ex.Message);
				}
			}

			var end = this.festivalCоntroller.ProduceReport();

			Console.WriteLine("Results:");
			Console.WriteLine(end.TrimEnd());
		}

		private string DoCommand(string input)
		{
			var enter = input.Split();

			var command = enter[0];
			var args = enter.Skip(1).ToArray();

            string result = string.Empty;

			if (command == "LetsRock")
			{
				result = this.setCоntroller.PerformSets();
			}
            else
            {
                result = this.ProcessCommand(input);
            }

			//var festivalcontrolfunction = this.festivalCоntroller
            //    .GetType()
			//	.GetMethods()
			//	.FirstOrDefault(x => x.Name == command);
            //
			//result = (string)festivalcontrolfunction.Invoke(this.festivalCоntroller, new object[] { args });

			return result;
		}

        public string ProcessCommand(string input)
        {
            var args = input.Split();
            string command = args[0];
            string result = string.Empty;

            if (command == "RegisterSet")
            {
                result = this.festivalCоntroller.RegisterSet(args.Skip(1).ToArray());
            }
            else if (command == "SignUpPerformer")
            {
                result = this.festivalCоntroller.SignUpPerformer(args.Skip(1).ToArray());
            }
            else if(command == "RegisterSong")
            {
                result = this.festivalCоntroller.RegisterSong(args.Skip(1).ToArray());
            }
            else if(command == "AddSongToSet")
            {
                result = this.festivalCоntroller.AddSongToSet(args.Skip(1).ToArray());
            }
            else if(command == "AddPerformerToSet")
            {
                result = this.festivalCоntroller.AddPerformerToSet(args.Skip(1).ToArray());
            }
            else if(command == "RepairInstruments")
            {
                result = this.festivalCоntroller.RepairInstruments(args.Skip(1).ToArray());
            }
            else if(command == "LetsRock")
            {
                result = this.setCоntroller.PerformSets();
            }
            return result;
        }
    }
}