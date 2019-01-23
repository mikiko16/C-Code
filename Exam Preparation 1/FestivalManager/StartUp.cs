namespace FestivalManager
{
    using System;
    using System.IO;
	using System.Linq;
    using System.Reflection;
    using Core;
	using Core.Contracts;
	using Core.Controllers;
	using Core.Controllers.Contracts;
	using Core.IO;
	using Core.IO.Contracts;
	using Entities;
	using Entities.Contracts;
    using FestivalManager.Entities.Factories;
    using FestivalManager.Entities.Factories.Contracts;

    public static class StartUp
	{
		public static void Main(string[] args)
		{
            Stage stage = new Stage();
            IFestivalController festivalController = new FestivalController(stage,
                new SetFactory(),
                new InstrumentFactory());
            ISetController setController = new SetController(stage);
            var engine = new Engine(festivalController, setController);
			engine.Run();
		}
	}
}