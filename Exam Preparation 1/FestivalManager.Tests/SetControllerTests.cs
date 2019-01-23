// Use this file for your unit tests.
// When you are ready to submit, REMOVE all using statements to your project (entities/controllers/etc)
namespace FestivalManager.Tests
{
    //using FestivalManager.Core.Controllers;
    //using FestivalManager.Core.Controllers.Contracts;
    //using FestivalManager.Entities;
    //using FestivalManager.Entities.Contracts;
    //using FestivalManager.Entities.Instruments;
    //using FestivalManager.Entities.Sets;
    using NUnit.Framework;
    using System;

    [TestFixture]
	public class SetControllerTests
    {

        [Test]
	    public void TestIfEverythingIsOk()
	    {
            IStage stage = new Stage();
            ISetController setController = new SetController(stage);

            IPerformer performer = new Performer("Pepitu", 22);
            stage.AddPerformer(performer);

            ISong song = new Song("Milionerche", new TimeSpan(0, 0, 3, 50));
            stage.AddSong(song);

            ISet set = new Long("MySet");
            set.AddSong(song);
            set.AddPerformer(performer);
            stage.AddSet(set);

            string result = setController.PerformSets();

            Assert.AreEqual("1. MySet:\r\n-- Did not perform", result);
		}

        [Test]
        public void TestLikeBeforeButExtended()
        {
            IStage stage = new Stage();

            ISet set = new Long("BegamBate");
            IPerformer performer = new Performer("Bate", 23);
            performer.AddInstrument(new Guitar());
            set.AddPerformer(performer);

            ISong song = new Song("Happy", new TimeSpan(0, 0, 1, 2));
            set.AddSong(song);
            stage.AddSet(set);
            ISetController setController = new SetController(stage);

            string result = setController.PerformSets();
            Assert.That(result, Is.EqualTo("1. BegamBate:\r\n-- 1. Happy (01:02)\r\n-- Set Successful"));
        }
    }
}