namespace FestivalManager.Entities
{
	using System.Collections.Generic;
	using Contracts;
    using System.Linq;

	public class Stage : IStage
	{
		private readonly List<ISet> sets;
		private readonly List<ISong> songs;
		private readonly List<IPerformer> performers;

        public Stage()
        {
            this.sets = new List<ISet>();
            this.songs = new List<ISong>();
            this.performers = new List<IPerformer>();
        }

        public IReadOnlyCollection<ISet> Sets => this.sets.AsReadOnly();

        public IReadOnlyCollection<ISong> Songs => this.songs.AsReadOnly();

        public IReadOnlyCollection<IPerformer> Performers => this.performers.AsReadOnly();

        public void AddPerformer(IPerformer performer)
        {
            performers.Add(performer);
        }

        public void AddSet(ISet set)
        {
            this.sets.Add(set);
        }

        public void AddSong(ISong song)
        {
            this.songs.Add(song);
        }

        public IPerformer GetPerformer(string name)
        {
            IPerformer p = performers.Find(x => x.Name == name);
            return p;
        }

        public ISet GetSet(string name)
        {
            ISet s = sets.Find(x => x.Name == name);
            return s;
        }

        public ISong GetSong(string name)
        {
            ISong s = songs.Find(x => x.Name == name);
            return s;
        }

        public bool HasPerformer(string name)
        {
            if (performers.Exists(x => x.Name == name))
            {
                return true;
            }
            return false;
        }

        public bool HasSet(string name)
        {
            if(sets.Any(x => x.Name == name))
            {
                return true;
            }
            return false;
        }

        public bool HasSong(string name)
        {
            if(songs.Exists(x => x.Name == name))
            {
                return true;
            }
            return false;
        }
    }
}
